﻿using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace ProductivityTools.SeleniumExtensions
{
    public static class Extensions
    {
        public static IWebElement GetElementByInnerText(this IWebElement parent, string tag, string text)
        {
            var tags = parent.FindElements(By.TagName(tag));
            foreach (var item in tags)
            {
                var x = item.GetAttribute("innerHTML");
                if (x == text)
                {
                    return item;
                }
            }
            return null;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByIdPart(this IWebElement parent, string idPart)
        {
            var result= parent.FindElements(By.CssSelector($"[id*='{idPart}']"));
            return result;
        }
    }
}
