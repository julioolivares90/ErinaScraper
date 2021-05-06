using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper
{
    public class ResultadoBusqueda
    {
        public string Title { get; set; }
        public string Score { get; set; }
        public string Type { get; set; }
        public string Demography { get; set; }
        public string MangaUrl { get; set; }
        public string MangaImagen { get; set; }

        public override string ToString()
        {
            return $"title : {Title} - demografia : {Demography}";
        }
    }
}
