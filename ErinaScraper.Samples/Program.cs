using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using ErinaScraper.src.ErinaScraper;

namespace ErinaScraper.Samples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var scraper = new ErinaScraper();

            //Obtenemos los mangas populares del sitio
            var mangasPopulares = await scraper.GetMangasAsync(MangaType.Populars);

            Console.WriteLine("Mangas Populares");
            foreach (var item in mangasPopulares)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine(item.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------------");
            }

            //Obtenemos los mangas seinen del sitio
            var mangasSeinen = await scraper.GetMangasAsync(MangaType.Seinen);

            Console.WriteLine("Mangas seinen");
            foreach (var item in mangasSeinen)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine(item.ToString());
                Console.WriteLine("-------------------------------------------------------------------------------------");
            }

            Console.WriteLine("---------------Manga info-------------");

            var mangaInfo = await scraper.GetMangaInfoAsync("https://lectortmo.com/library/manga/49890/shonen-no-abyss");
            Console.WriteLine(mangaInfo.ToString());
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("---------------Manga info Capitulos -------------");

            //var mangaCapitulos = await scraper.GetCapitulosManga(urlRefer: "https://lectortmo.com/library/manga/49890/shonen-no-abyss", urlCapitulo: "https://anitoc.com/news/943785a80d0ba8316c5f894406cc406e/paginated/1");
            var mangaCapitulos = await scraper.GetCapitulosManga(urlRefer: "https://lectortmo.com/library/manga/30388/kanojo-okarishimasu", urlCapitulo: "https://lectortmo.com/view_uploads/250923");
            mangaCapitulos.ForEach((capitulo) => Console.WriteLine(capitulo));
            Console.WriteLine("---------------------------------------");
        }
    }

   
}
