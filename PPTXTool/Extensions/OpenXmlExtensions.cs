using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPTXTool.Extensions
{
    internal static class OpenXmlExtensions
    {
        public static string Attribute(this OpenXmlElement element, string attributeName)
        {
            return element.GetAttribute(attributeName, "").Value;
        }
    }
}
