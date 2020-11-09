using System;
using System.Collections.Generic;
using System.Text;
using ErinaScraper.src.ErinaScraper;

namespace ErinaScraper.src.Samples
{
    class GetMangasPopulares
    {
        public async static void Main(string[] args)
        {

            var scraperMangasPopulares = new ScraperMangas();

            var type = MangaType.Populars;
            var mangas = await scraperMangasPopulares.GetMangasAsync(type);

            foreach (var item in mangas)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
