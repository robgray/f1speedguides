using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace atomicf1
{
    public static class ImageHelpers
    {
        public static string GetImage(this string imageUri, int width)
        {
            return string.Format("/ImageGen.ashx?image={0}&width={1}", imageUri, width);
        }
    }
}