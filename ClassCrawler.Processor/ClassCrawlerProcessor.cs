using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ClassCrawler.Data.Models;
using System.Reflection;
using ClassCrawler.Data.Attributes;
using System.Linq;

namespace ClassCrawler.Processor
{
    public class ClassCrawlerProcessor
    {
        public UscClass Process(HtmlDocument document, string rootUrl)
        {
            var entityExpression = (typeof(UscClass)).GetCustomAttribute<ClassCrawlerEntityAttribute>().XPath;
            var entityNode = document.DocumentNode.SelectSingleNode(entityExpression);

            var nameHtmlValueDictionary = new Dictionary<string, object>();
            var attributeDictionary = GetColumnNameValuePairsFromHtml(document);

            foreach (var expression in attributeDictionary)
            {
                var columnName = expression.Key;
                object columnValue = "";
                var fieldExpression = expression.Value.Item2;

                switch (expression.Value.Item1)
                {
                    case SelectorType.XPath:
                        var nodeHtml = entityNode.SelectSingleNode(fieldExpression);
                        if (nodeHtml != null)
                            if (fieldExpression.Contains("img"))
                            {  //表示圖檔link
                                columnValue = rootUrl + nodeHtml.Attributes[0].Value;
                            }
                            else
                            {

                                if (decimal.TryParse(nodeHtml.InnerText, out var result))
                                    columnValue = result;
                                else
                                {
                                    columnValue = nodeHtml.InnerText;
                                }
                            }
                        break;
                    case SelectorType.FixedValue:
                        //var expression = document.DocumentNode.SelectSingleNode(entityExpression + "/p/text()[3]");
                        int i = 0;
                        nodeHtml = document.DocumentNode.SelectSingleNode(entityExpression + $"/p/text()[{i}]");
                        //string nodeHtmlAsString = nodeHtml.InnerText.Trim();
                        do
                        {
                            if (nodeHtml != null && nodeHtml.InnerText.Trim().Contains(fieldExpression))
                            {
                                columnValue = nodeHtml.InnerText
                                                .Substring(nodeHtml.InnerText.IndexOf("：") + 1, nodeHtml.InnerText.Length - (nodeHtml.InnerText.IndexOf("：") + 1));
                                if (fieldExpression == "開課時段" || fieldExpression == "學費")
                                {
                                    columnValue = columnValue.ToString().Replace("\"", "");
                                }
                                break;
                            }
                            else
                            {
                                i++;
                                nodeHtml = document.DocumentNode.SelectSingleNode(entityExpression + $"/p/text()[{i}]");
                            }
                        } while (i <= 8);
                        break;
                    default:
                        break;
                }
                nameHtmlValueDictionary.Add(columnName, columnValue);
            }

            UscClass processorEntity = (UscClass)Activator.CreateInstance(typeof(UscClass));

            foreach (var pair in nameHtmlValueDictionary)
            {
                var prop = processorEntity.GetType().GetProperty(pair.Key, BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.CanWrite)
                    prop.SetValue(processorEntity, pair.Value, null);
            }
            //return nameHtmlValueDictionary;
            return processorEntity;
        }

        private Dictionary<string, Tuple<SelectorType, string>> GetColumnNameValuePairsFromHtml(HtmlDocument document)
        {
            var attributeDictionary = new Dictionary<string, Tuple<SelectorType, string>>();

            PropertyInfo[] props = typeof(UscClass).GetProperties();
            var propList = props.Where(p => p.CustomAttributes.Count() > 0);

            foreach(PropertyInfo prop in propList)
            {
                var attr = prop.GetCustomAttribute<ClassCrawlerFieldAttributes>();
                if(attr!=null)
                {
                    attributeDictionary.Add(prop.Name, Tuple.Create(attr.SelectorType, attr.XpathExpression));
                }
            }
            return attributeDictionary;
        }

        private Dictionary<string, Tuple<SelectorType, string>> GetColumnNameValuePairs(HtmlDocument document)
        {
            var attributeDictionary = new Dictionary<string, Tuple<SelectorType, string>>();

            PropertyInfo[] props = typeof(UscClass).GetProperties();
            var propList = props.Where(p => p.CustomAttributes.Count() > 0);

            foreach (PropertyInfo prop in propList)
            {
                var attr = prop.GetCustomAttribute<ClassCrawlerFieldAttributes>();
                if (attr != null)
                {
                    attributeDictionary.Add(prop.Name, Tuple.Create(attr.SelectorType, attr.XpathExpression));
                }
            }
            return attributeDictionary;
        }
    }
}
