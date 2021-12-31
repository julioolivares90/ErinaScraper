using System;
using System.Collections.Generic;
using System.Text;
using ErinaScraper.src.ErinaScraper.src.Exceptions;

namespace ErinaScraper.src.ErinaScraper.src.Utilities
{
    public static class StringHelpers
    {
        public static string GetFolderKey (string url)
        {
            if (!url.Contains("folder"))
            {
                throw new MediaFireExepcion("la url no es valida");
            }

            var urlSplit = url.Split('/');

            return urlSplit[4];
        }
    }
}
