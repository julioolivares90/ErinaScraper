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

    }
}
