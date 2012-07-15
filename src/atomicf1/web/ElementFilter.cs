using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.common;


namespace atomicf1.web
{
    public abstract class ElementFilter
    {
        protected abstract string AttributeToken { get; }
        protected abstract string ElementToken { get; }
        protected abstract string ElementEndToken { get; }

        private static StaticFileParallelization _helper = new StaticFileParallelization();

        public string Filter(string content)
        {
            string filteredContent = content;
            
            var occurrence = filteredContent.IndexOf(ElementToken, 0);
            while (occurrence >= 0)
            {
                int occurrenceEnd = filteredContent.IndexOf(ElementEndToken, occurrence + ElementToken.Length);
                if (occurrenceEnd <= occurrence)
                    break;

                int srcPos = filteredContent.IndexOf(AttributeToken, occurrence + ElementToken.Length) + AttributeToken.Length;
                string srcDelim = filteredContent.Substring(srcPos, 1);
                int srcPosEnd = filteredContent.IndexOf(srcDelim, srcPos + 1);
                string oldUrl = filteredContent.Substring(srcPos + 1, srcPosEnd - srcPos - 1);

                string newUrl = _helper.GetStaticUrl(oldUrl.Replace(HttpContext.Current.Request.GetBaseUrl(), ""));

                if (!newUrl.Equals(oldUrl))
                    filteredContent = filteredContent.ReplaceAt(srcPos + 1, oldUrl, newUrl);

                occurrence = filteredContent.IndexOf(ElementToken, occurrenceEnd + 2);
            }
            return filteredContent;
        }
    }
}