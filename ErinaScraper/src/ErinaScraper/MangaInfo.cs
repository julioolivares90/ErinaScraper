using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper
{
    public class MangaInfo
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Demografia { get; set; }

        public string Tipo { get; set; }

        public double Score { get; set; }

        public string Description { get; set; }

        public List<string> Generos { get; set; }

        public string Estado { get; set; }

        public List<Capitulo> Capitulos { get; set; }

        public override string ToString()
        {
            return string.Format(" Title : {0} ImageUrl : {1} Demografia : {2} Tipo : {3} Score : {4} Description : {5} Estado : {6} ",Title,ImageUrl,Demografia,Tipo,Score,Description,Estado);
        }
    }
}
