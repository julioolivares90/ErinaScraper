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
    }
}