using NUnit.Framework;
using ErinaScraper.src.ErinaScraper;
using System.Threading.Tasks;
using System;

namespace ErinaScraper.test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test1()
        {
            ErinaScraper scraper = new ErinaScraper();

            var  type = MangaType.Populars;
            var mangas = await scraper.GetMangasAsync(type);
            foreach (var item in mangas)
            {
                Console.WriteLine(item.MangaImagen);
            }
            Assert.IsNotNull(mangas);
        }

        [Test]
        public async Task Test2()
        {
            ErinaScraper scraper = new ErinaScraper();

            var resultadoBusqueda = await scraper.BusquedaManga(title: "naruto");

            Assert.IsNotNull(resultadoBusqueda);
        } 

        [Test]
        public async Task Test3()
        {
            ScraperMangas scraperMangas = new ScraperMangas();
            var result = await scraperMangas.BuscarMangas(title:"naruto");

            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Test4()
        {
            ErinaScraper scraper = new ErinaScraper();

            var result = await scraper.GetCapitulosManga(urlRefer: "https://lectortmo.com/library/manhwa/41512/solo-leveling",
                urlCapitulo: "https://lectortmo.com/view_uploads/757022");

            Assert.IsNotNull(result);
        }
    }
}