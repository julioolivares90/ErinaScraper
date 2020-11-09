using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper
{
    public class Utilities
    {
        public readonly static string  BASE_URL = "https://lectortmo.com/";

        public readonly static string GetTitle = "#app > section > header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-9.element-header-content-text > h1";
        public readonly static string GetImage = "#app > section > header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-3.text-center > div > img";

        public readonly static string GetTipo = "#app > section > header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-3.text-center > h1";

        public readonly static string GetScore = "#app > section > header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-3.text-center > div > div.score > a > span";

        public readonly static string GetDemografia = "#app > section > header > section.element-header-content > div.container > div.row > div.col-12 > div.element-image > div.demography";

        public readonly static string GetGeneros = "h6";

        public readonly static string GetCapitulosColapsed = "#chapters > ul.list-group > div > li";

        public readonly static string GetDescripcion = "#app > section > header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-9.element-header-content-text > p.element-description";

        public readonly static string GetStado = "#app > section > header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-9.element-header-content-text > span.book-status";

        public static string GetImageFromMangaUrl(string imagen, string mangaIdentificador)
        {
            var formatoParaCadenaABorrar = string.Format(".book-thumbnail-{0}::before "+"{background-image: url(' ');}", mangaIdentificador);
            var cadSinBackground = imagen.Replace(imagen.Trim(), formatoParaCadenaABorrar);
            return cadSinBackground;
        }
    }
}
