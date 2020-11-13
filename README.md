# ErinaScraper

## **:package: Principales herramientas usadas**

- [x] anglesharp
- [x] c#

## ejemplos de uso
```c#
   class Program
    {
        static async Task Main(string[] args)
        {
            var scraper = new ErinaScraper();

            //Obtenemos los mangas populares 
            var mangasPopulares = await scraper.GetMangasAsync(MangaType.Populars);

            foreach (var item in mangasPopulares)
            {
                Console.WriteLine(item.ToString());
            }

            //Obtenemos los mangas seinen 
            var mangasSeinen = await scraper.GetMangasAsync(MangaType.Seinen);

            foreach (var item in mangasSeinen)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
```
