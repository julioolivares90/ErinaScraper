using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper
{
    public class ListaManga
    {
        
        public string Url { get; set; }

        public string Title { get; set; }

        public string Descripcion { get; set; }

        public string CantidadDeSeguidoresLista { get; set; }

        public string ImagenLista { get; set; }

        public string DataSRC { get; set; }


        public override string ToString()
        {
            return $"title -> {Title} - descripcion -> {Descripcion} - cantidad de seguidores lista -> {CantidadDeSeguidoresLista}";
        }
    }
}
