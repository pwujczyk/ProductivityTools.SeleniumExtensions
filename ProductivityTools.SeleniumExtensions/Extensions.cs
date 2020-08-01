using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProductivityTools.SeleniumExtensions
{
    public static class Extensions
    {
        public static IWebElement FindElementByInnerText(this IWebElement parent, string tag, string text, bool printInnerHtml=false)
        {
            var tags = parent.FindElements(By.TagName(tag));
            foreach (var item in tags)
            {
                var x = item.GetAttribute("innerHTML");
                if (printInnerHtml)
                {
                    Console.WriteLine(x);
                }

                if (x == text)
                {
                    return item;
                }
            }
            return null;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByMultipleClass(this IWebElement parent, string @class, bool printInnerHtml = false)
        {
            var r=parent.FindElements(By.XPath($"//*[@class='{@class}']"));
            return r; 
        }

        public static IWebElement FindElementByMultipleClass(this IWebElement parent, string @class, bool printInnerHtml = false)
        {
            var r = parent.FindElement(By.XPath($"//*[@class='{@class}']"));
            return r;
        }

        public static string InnerHtml(this IWebElement parent)
        {
            var r = parent.GetAttribute("innerHTML");
            return r;
        }

        public static string InnerText(this IWebElement parent)
        {
            var r = parent.GetAttribute("innerText");
            return r;
        }

        public static string InnersText(this ReadOnlyCollection<IWebElement> parent)
        {
            var result = string.Empty;
            foreach (var item in parent)
            {
                result += item.InnerText().Trim()+" ";
            }
            return result;
        }

        public static IWebElement Parent(this IWebElement element)
        {
            var r=element.FindElement(By.XPath(".."));
            return r;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByIdPart(this IWebElement parent, string idPart)
        {
            var result= parent.FindElements(By.CssSelector($"[id*='{idPart}']"));
            return result;
        }
    }
}
