using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace atomicf1.web
{
    /// <summary>
    /// Scans outgoing HTML for img elements and updates the src path to use parallelization of images
    /// </summary>
    public class StaticHostsFilter : MemoryStream
    {
        private Stream _filter;
        private bool _filtered = false;

        private IList<ElementFilter> _filters;

        public StaticHostsFilter(System.IO.Stream filter)
        {
            _filter = filter;
            _filters = new List<ElementFilter> { new ImageElementFilter(), new ScriptElementFilter(), new LinkElementFilter() };
        }

        public override void Close()
        {            
            if (_filtered)
            {
                if (Length > 0)
                {
                    byte[] bytes;
                    string content = System.Text.Encoding.UTF8.GetString(this.ToArray());

                    foreach (var elementFilter in _filters)
                        content = elementFilter.Filter(content);

                    bytes = System.Text.Encoding.UTF8.GetBytes(content);
                    _filter.Write(bytes, 0, bytes.Length);
                }
                _filter.Close();
            }
            base.Close();
        }


        public override void Write(byte[] buffer, int offset, int count)
        {
            if ((System.Web.HttpContext.Current != null)
                && ("text/html" == System.Web.HttpContext.Current.Response.ContentType))
            {
                base.Write(buffer, offset, count);
                _filtered = true;
            }
            else
            {
                _filter.Write(buffer, offset, count);
                _filtered = false;
            }
        }
    }
}