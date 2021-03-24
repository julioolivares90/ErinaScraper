using AngleSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Text;
using System.Linq;
using System;

namespace ErinaScraper.src.ErinaScraper
{
   public class ScraperMangas
    {
        /// <summary>
        /// metodo para configurar un brwoserContext
        /// </summary>
        /// <returns>IBrowsingContext</returns>
        public static IBrowsingContext GetBrowsingContext()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);

            return context;
        }

        /// <summary>
        /// retorna una lista de mangas populares desde el sitio de lectortmo.com
        /// </summary>
        /// <param name="numberPage">numero de pagina que necesitas obtener informacion</param>
        /// <returns></returns>
       public async Task<List<Manga>> GetMangasAsync(MangaType mangaType,int numberPage = 1)
        {

            var mangas = new List<Manga>();

            var context = GetBrowsingContext();

            var url = GetUrlToScrape(mangaType,numberPage);

            var document = await context.OpenAsync(url);

            var divPrincipal = document.QuerySelector("#app > main > div:nth-child(2) > div.col-12.col-lg-8.col-xl-9 > div:nth-child(1)");

           var elements =  divPrincipal.QuerySelectorAll("div.element");

            foreach (var item in elements)
            {
                var mangaIdentificador = item.Attributes["data-identifier"].Value;
                var manga = new Manga
                {
                    Title = item.QuerySelector("a > div > div > h4").TextContent,

                    MangaUrl = item.QuerySelector("a").Attributes["href"].Value,

                    Type = item.QuerySelector("a > div > span.book-type").TextContent,

                    Demography = item.QuerySelector("a > div > span.demography").TextContent,

                    Score = item.QuerySelector("a > div > span.score > span").TextContent,

                    MangaImagen = Utilities.GetImagenFromMangaUrl(item.QuerySelector("a > div > style").TextContent,mangaIdentificador),
                };

                mangas.Add(manga);
            }

            return mangas;
        }

      
 
        /// <summary>
        /// retorna una url segun el tipo de manga solicitado
        /// </summary>
        /// <param name="mangaType"></param>
        /// <param name="numberPage"></param>
        /// <returns>string</returns>
        private string GetUrlToScrape(MangaType mangaType,int numberPage=1)
        {
            string MangaUrl;
            switch (mangaType)
            {
                case MangaType.Populars:
                    MangaUrl = $"{Utilities.BASE_URL}/populars?page={numberPage}";
                    break;
                case MangaType.Seinen:
                    MangaUrl = $"{Utilities.BASE_URL}/populars-boys";
                    break;
                case MangaType.Josei:
                    MangaUrl = $"{Utilities.BASE_URL}/populars-girls";
                    break;
                default:
                    MangaUrl = $"{Utilities.BASE_URL}/populars?page={numberPage}";
                    break;
            }
            return MangaUrl;
        }

        /// <summary>
        /// retorna la informacion de un manga 
        /// </summary>
        /// <param name="url">url del manga que se desea obtener la informacion</param>
        /// <returns></returns>
        public async Task<MangaInfo> GetMangaInfoAsync(string url)
        {
            var context = GetBrowsingContext();
            var document = await context.OpenAsync(url);

            var sectionInfo = document.QuerySelector("#app > section");


            var title = sectionInfo.QuerySelector(Utilities.MangaInfoTitle).TextContent;

            var imagen = sectionInfo.QuerySelector(Utilities.MangaInfoImagen).Attributes["src"].Value;

            var tipo = sectionInfo.QuerySelector(Utilities.MangaInfoTipo).TextContent;

            var score = sectionInfo.QuerySelector(Utilities.MangaInfoScore).TextContent;

            var demografia = sectionInfo.QuerySelector(Utilities.MangaInfoDemografia).TextContent;

            var descripcion = sectionInfo.QuerySelector(Utilities.MangaInfoDescripcion).TextContent;

            var estado = sectionInfo.QuerySelector(Utilities.MangaInfoEstado).TextContent;

            var generosSection = sectionInfo.QuerySelectorAll(Utilities.MANGAINFO_GENEROS);

            var generosList = new List<string>();
            foreach (var item in generosSection)
            {
                var genero = item.TextContent;

                generosList.Add(genero);
            }

            var capitulosList = new List<Capitulo>();

            //obtiene los capitulos que no estan en collapse
            var capitulosSection = document.QuerySelectorAll(Utilities.CAPITULOS_MANGAINFO_SIN_COLLAPSE);

            foreach (var item in capitulosSection)
            {
                var capitulo = new Capitulo
                {
                    Name = item.QuerySelector(Utilities.MANGA_INFO_NOMBRE_CAPITULO).TextContent,
                    UrlLeer = item.QuerySelector(Utilities.MANGA_INFO_URL).Attributes["href"].Value
                };
                capitulosList.Add(capitulo) ;
            }

            //obteniendo los capitulos que  estan en collapse
            var capitulosCollapsed = document.QuerySelectorAll(Utilities.CAPITULOS_MANGAINFO_COLLAPSE);

            
            foreach (var item in capitulosCollapsed)
            {
                var capitulo = new Capitulo
                {
                    Name = item.QuerySelector(Utilities.MANGA_INFO_NOMBRE_CAPITULO).TextContent,
                    UrlLeer = item.QuerySelector(Utilities.MANGA_INFO_URL).Attributes["href"].Value
                };
                capitulosList.Add(capitulo);
            }


            var mangaInfo = new MangaInfo
            {
                Title =title,
                ImageUrl = imagen,
                Demografia = demografia,
                Tipo = tipo,
                Score = Convert.ToDouble(score) ,
                Description = descripcion,
                Generos = generosList,
                Estado = estado ,
                Capitulos = capitulosList

            };


            return mangaInfo;

        }



    }


    
    /// <summary>
    /// Enum para tipo de manga
    /// </summary>
    public enum MangaType
    {
        Populars,
        Seinen,
        Josei
    }
}
