using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper
{
    public class Manga
    {
        public string Title { get; set; }

        public string MangaUrl { get; set; }

        public string Type { get; set; }

        public string Demography { get; set; }

        public string Score { get; set; }

        public string MangaImagen { get; set; }

        public override string ToString()
        {
            return string.Format("Title : {0} ,\n MangaUrl: {1} ,\n Type : {2} , \n Demography: {3},\n Score: {4}, \n MangaImagen: {5}", Title,MangaUrl,Type,Demography,Score,MangaImagen);
        }
    }
}
