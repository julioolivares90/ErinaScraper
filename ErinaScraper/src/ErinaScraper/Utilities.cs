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


        public readonly static string MangaInfoTitle = "header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-9.element-header-content-text > h1";
        public readonly static string MangaInfoImagen = "header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-3.text-center > div > img";

        public readonly static string MangaInfoTipo = "header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-3.text-center > h1";
        public readonly static string MangaInfoScore = "header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-3.text-center > div > div.score > a > span";

        public readonly static string MangaInfoDemografia = "header > section.element-header-content > div.container > div.row > div.col-12 > div.element-image > div.demography";
        public readonly static string MangaInfoDescripcion = "header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-9.element-header-content-text > p.element-description";
        public readonly static string MangaInfoEstado = "header > section.element-header-content > div.container.h-100 > div > div.col-12.col-md-9.element-header-content-text > span.book-status";

        public readonly static string MANGAINFO_GENEROS = "header > section > div.container > div.row > div.col-12 > h6";


        public readonly static string CAPITULOS_MANGAINFO_SIN_COLLAPSE = "#chapters > ul.list-group > li";
        public readonly static string CAPITULOS_MANGAINFO_COLLAPSE = "#chapters > ul.list-group > div > li";


        public readonly static string MANGA_INFO_NOMBRE_CAPITULO = "h4 > div.row > div > a.btn-collapse";
        public readonly static string MANGA_INFO_URL = "div > div > ul > li  > div.row > div.col-2 > a";
        /*
        public static string GetImageFromMangaUrl(string imagen, string mangaIdentificador)
        {
            var formatoImagenBackground = "{background-image: url('";
            var formato = "');}";
            var formatoParaCadenaABorrar = string.Format(".book-thumbnail-{0}::before ", mangaIdentificador);

            var cadSinBackground = imagen.Replace(formatoImagenBackground,"");
            //Console.WriteLine("Cad Sin Background =>",cadSinBackground);
            var cad1 = cadSinBackground.Replace(formatoParaCadenaABorrar,"");

            //var cad2 = cad1.Replace(formato,"");
           // var cadSinBackground = imagen.Remove(1,70);
            return cad1.Trim();
        }
        */

        public static string GetImagenFromMangaUrl(string imagen ,string mangaIdentificador)
        {
            //var formato1 = string.Format(".book-thumbnail-{0}::before{", mangaIdentificador);

            var cad1 = imagen.Remove(1,90);
            Console.WriteLine(cad1.Length);
            var cad2 = cad1.Replace("');"," ");
            var cad3 = cad2.Replace("}", " ");
            return cad3.Trim();
        }

        public static string GetDataSRC(string url,string nombreLista)
        {
            var nombreList = "";
            var cadenaFinal = "";
            var cadenaSinLectorTMO = "";

            if (nombreLista.Contains(" "))
            {
                nombreList = nombreLista.Replace(" ", "-");
                cadenaSinLectorTMO = url.Replace(nombreList," ");
            }else
            {
                nombreList = nombreLista;
                cadenaSinLectorTMO = url.Replace(nombreList, "");
            }

            cadenaFinal = cadenaSinLectorTMO;

            return cadenaFinal;
        }
    }
}
