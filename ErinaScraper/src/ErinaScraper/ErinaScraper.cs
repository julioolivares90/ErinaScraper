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
        public async Task<List<Manga>> GetMangasAsync(MangaType type)
        {
            var mangas = await Scraper.GetMangasAsync(type);

            return mangas;
        }

        public async Task<MangaInfo> GetMangaInfoAsync(string urlManga)
        {
            var mangaInfo = await Scraper.GetMangaInfoAsync(urlManga);

            return mangaInfo;
        }

    }
}
