using AngleSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Text;
using System.Linq;

namespace ErinaScraper.src.ErinaScraper
{
    class ScraperMangas
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

                    MangaImagen = Utilities.GetImageFromMangaUrl(item.QuerySelector("a > div > style").TextContent,mangaIdentificador),
                };

                mangas.Add(manga);
            }

            return mangas;
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

            var manga = new MangaInfo();

            var title = document.QuerySelector(Utilities.GetTitle)
                        .TextContent.TrimEnd();

            var imagenUrl = document.QuerySelector(Utilities.GetImage).Attributes["src"].Value;

            var demografia = document.QuerySelector(Utilities.GetDemografia).TextContent.Trim();

            var score = document.QuerySelector(Utilities.GetScore).TextContent.Trim();

            var descripcion = document.QuerySelector(Utilities.GetDescripcion).TextContent.Trim();

            var tipo = document.QuerySelector(Utilities.GetTipo).TextContent.Trim();

            var generos = document.QuerySelectorAll(Utilities.GetGeneros).ToList();

            var estado = document.QuerySelector(Utilities.GetStado).TextContent.Trim();

            var generos2 = new List<string>();

            foreach (var item in generos)
            {
                generos2.Add(item.TextContent.Trim());
            }


            var ulCapitulos = document.QuerySelector("#chapters > ul.list-group > div"); //obtengo el div de los capitulos escondidos


            var lis2 = ulCapitulos.QuerySelectorAll("#chapters > ul.list-group > div > li").ToList();

            var capitulos = new List<Capitulo>();
            foreach (var li in lis2)
            {
                var nombreCap = li.QuerySelector("h4 > div.row > div > a.btn-collapse").TextContent.Trim();

                var urlCap = li.QuerySelector("div > div > ul > li  > div.row > div.col-2 > a").Attributes["href"].Value;

                var capitulo = new Capitulo();
                capitulo.Name = nombreCap;
                capitulo.UrlLeer = urlCap;

                capitulos.Add(capitulo);
            }
            //objeto manga con todos los datos

            manga.Title = title;
            manga.Capitulos.AddRange(capitulos);
            manga.Tipo = tipo;
            manga.Score = score.ToDouble();
            manga.ImageUrl = imagenUrl;
            manga.Generos.AddRange(generos2);
            manga.Demografia = demografia;
            manga.Estado = estado;
            manga.Description = descripcion;

            return manga;
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
