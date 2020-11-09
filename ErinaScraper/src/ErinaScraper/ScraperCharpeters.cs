using AngleSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ErinaScraper.src.ErinaScraper
{
    class ScraperCharpeters
    {
        private readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// retorna una lista con las url de las imagenes de un manga
        /// </summary>
        /// <param name="urlRefer">la url del capitululo que se esta consultando</param>
        /// <param name="urlCapitulo">url del capitulo que se desea leer</param>
        /// <returns>Task<List<string>></returns>
        /// 
        public async Task<List<string>> GetImagesFromChapterAsync(string urlRefer,string urlCapitulo)
        {
          
            var newUrl = await GetUrlFromRedirection(urlRefer, urlCapitulo);
            var HTML = await GetHTMLFromPAGEAsync(urlRefer,newUrl);
            var  mangas = await GetUrlOfImagesAsync(HTML);
            return mangas;
        }

        /// <summary>
        /// retorna el html enforma de string 
        /// </summary>
        /// <param name="urlRefer">url del capitululo que se esta consultando</param>
        /// <param name="urlCapitulo">url del capitulo que se desea leer</param>
        /// <returns>Task<string></returns>
        private async Task<string> GetHTMLFromPAGEAsync(string urlRefer,string urlCapitulo)
        {
            httpClient.DefaultRequestHeaders.Add("method", "GET");

            httpClient.DefaultRequestHeaders.Add("authority", "lectortmo.com");

            httpClient.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.Add("referer",urlRefer);

            var response = await httpClient.GetAsync(urlCapitulo);

            //var responseUri = response.RequestMessage.RequestUri.ToString();

            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        private async Task<string> GetUrlFromRedirection(string urlRefer, string urlCapitulo)
        {
            string newUrl = "";
            httpClient.DefaultRequestHeaders.Add("method", "GET");

            httpClient.DefaultRequestHeaders.Add("authority", "lectortmo.com");

            httpClient.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.Add("referer", urlRefer);

            var response = await httpClient.GetAsync(urlCapitulo);

            var responseUri = response.RequestMessage.RequestUri.ToString();

            if (responseUri.Contains("/paginated") || responseUri.Contains("/paginated/1"))
            {
                newUrl = responseUri.Replace("/paginated", "/cascade");
                if (newUrl.Contains("/cascade/1"))
                {
                    newUrl = newUrl.Replace("/cascade/1","cascade");
                }
            }
            return newUrl;
        }



        private async Task<List<string>> GetUrlOfImagesAsync(string content)
        {
            var context = ScraperMangas.GetBrowsingContext();

            var imagenes = new List<string>();

            var containMainContainer = await ContainMainContainer(content);

            var document = await context.OpenAsync((req)=> { req.Content(content); });

            if (containMainContainer)
            {
                try
                {
                    var divMain = document.QuerySelector("#main-container");
                    var divImagenes = divMain.QuerySelectorAll(".img-container");
                    foreach (var item in divImagenes)
                    {
                        var imagen = item.QuerySelector("img").Attributes["data-src"].Value;
                        imagenes.Add(imagen);
                    }
                }
                catch (Exception)
                {

                    return imagenes;
                }
            }
            else
            {
                try
                {
                    var divViewContainer = document.QuerySelector("#viewer-container");
                    var divImagenes = divViewContainer.QuerySelectorAll("viewer-image-container");

                    foreach (var item in divImagenes)
                    {
                        var imagen = item.QuerySelector("img").Attributes["data-src"].Value;
                        imagenes.Add(imagen);
                    }
                }
                catch (Exception)
                {

                    return imagenes;
                }
            }

            return imagenes;
        }

        private async Task<bool> ContainMainContainer(string content)
        {
            var context = ScraperMangas.GetBrowsingContext();
            var document = await context.OpenAsync(req=> { req.Content(content); });

            try
            {
                var divMainContainer = document.QuerySelector("#main-container");
                if (divMainContainer != null)
                {
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return false;
        }

    }
}
