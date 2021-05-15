using ErinaScraper.src.ErinaScraper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErinaScraper
{
    public class ErinaScraper
    {
        ScraperMangas Scraper = new ScraperMangas();
        ScraperCharpetersFromManga ScraperCharpeters = new ScraperCharpetersFromManga();

        /// <summary>
        /// get list of mangas from page lectortmo.com
        /// </summary>
        /// <param name="type">manga genre type</param>
        /// <returns></returns>
        public async Task<List<Manga>> GetMangasAsync(MangaType type)
        {
            var mangas = await Scraper.GetMangasAsync(type);

            return mangas;
        }

        /// <summary>
        /// get the information of a manga
        /// </summary>
        /// <param name="urlManga">
        /// url of the manga that you want to obtain information
        /// </param>
        /// <returns></returns>
        public async Task<MangaInfo> GetMangaInfoAsync(string urlManga)
        {
            var mangaInfo = await Scraper.GetMangaInfoAsync(urlManga);

            return mangaInfo;
        }


        /// <summary>
        /// get the images of each manga chapter
        /// </summary>
        /// <param name="urlRefer">manga info url</param>
        /// <param name="urlCapitulo">
        /// url of the chapter that you want to obtain your images
        /// </param>
        /// <returns></returns>
        public async Task<List<string>> GetCapitulosManga(string urlRefer,string urlCapitulo)
        {
            try
            {
                var capitulos = await ScraperCharpeters.GetImagenesOfCharpeter(urlRefer, urlCapitulo);
                return capitulos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<string>();
                
            }
            
        }


        /// <summary>
        /// search for a manga
        /// </summary>
        /// <param name="title">manga title </param>
        /// <param name="order_item">order by item </param>
        /// <param name="order_dir">prder</param>
        /// <param name="_page">page number</param>
        /// <param name="filter_by">filter by</param>
        /// <param name="type">maga type</param>
        /// <param name="demography">manga demography</param>
        /// <param name="status">manga status</param>
        /// <param name="translation_status">translation status</param>
        /// <param name="webcomic">webcomic</param>
        /// <param name="yonkoma"></param>
        /// <param name="amateur"></param>
        /// <param name="erotic">erotic</param>
        /// <returns>returns a list of mangas according to the search made</returns>
        public async Task<List<ResultadoBusqueda>> BusquedaManga(string title = "", string order_item = "", string order_dir = "",
           string _page = "1", string filter_by = "", string type = "", string demography = "",
           string status = "", string translation_status = "", string webcomic = "", string yonkoma = "", string amateur = "", string erotic = "")
        {
            try
            {
                var resultadoBusqueda = await Scraper
                    .BuscarMangas(title, order_item,
                    order_dir,
                    _page,
                    filter_by,
                    type,
                    demography,
                    status, 
                    translation_status,
                    webcomic,
                    yonkoma,
                    amateur,
                    erotic);
                return resultadoBusqueda;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<ResultadoBusqueda>();
            }
        }
        
        public async Task<List<ListaManga>> GetListaMangasAsync(int pageNumber)
        {
            var listaMangas = new List<ListaManga>();

            try
            {
                listaMangas = await Scraper.GetListaMangasAsync(pageNumber);
                return listaMangas;
            }
            catch (Exception ex)
            {

                return listaMangas;
            }
        }

    }
}
