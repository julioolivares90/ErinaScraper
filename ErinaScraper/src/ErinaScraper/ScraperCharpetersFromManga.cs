﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using AngleSharp;

namespace ErinaScraper.src.ErinaScraper
{
    public class ScraperCharpetersFromManga
    {
        private readonly HttpClient httpClient = new HttpClient();

        public async Task<List<string>> GetImagenesOfCharpeter(string urlRefer, string urlCapitulo)
        {
            var imagenes = new List<string>();

            var newUrl = getUrlFromScrape(urlCapitulo);

            var content = await GetBodyFromPageAsync(urlRefer, newUrl);

            var urls = await GetUrlOfImagesAsync(content);


            if (urls != null && urls.Count > 0)
            {
                imagenes.AddRange(urls);
            }
            return imagenes;
        }


        private string getUrlFromScrape(string urlCapitulo)
        {
            var newUrl = "";
            if (urlCapitulo.Contains("/paginated"))
            {
                if (urlCapitulo.Contains("/paginated/1"))
                {
                    newUrl = urlCapitulo.Replace("/paginated/1", "/cascade");
                    return newUrl;
                }
                newUrl = urlCapitulo.Replace("/paginated", "/cascade");
                return newUrl;
            }
            return urlCapitulo;
        }


        private async Task<string> GetBodyFromPageAsync(string urlRefer, string urlCapitulo)
        {
            httpClient.DefaultRequestHeaders.Add("method", "GET");

            httpClient.DefaultRequestHeaders.Add("authority", "lectortmo.com");

            httpClient.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.Add("referer", urlRefer);

            var response = await httpClient.GetStringAsync(urlCapitulo);

            return response;
        }

        private async Task<List<string>> GetUrlOfImagesAsync(string content)
        {
            var context = ScraperMangas.GetBrowsingContext();

            var imagenes = new List<string>();

            var containMainContainer = await ContainMainContainer(content);

            var document = await context.OpenAsync((req) => { req.Content(content); });

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
                catch (Exception ex)
                {

                    return imagenes;
                }
            }
            else
            {
                try
                {
                    var divViewContainer = document.QuerySelector("#viewer-container");
                    var divImagenes = divViewContainer.QuerySelectorAll(".viewer-image-container");

                    foreach (var item in divImagenes)
                    {
                        var imagen = item.QuerySelector("img").Attributes["data-src"].Value;
                        imagenes.Add(imagen);
                    }
                }
                catch (Exception ex)
                {

                    return imagenes;
                }
            }

            return imagenes;
        }

        private async Task<bool> ContainMainContainer(string content)
        {
            var context = ScraperMangas.GetBrowsingContext();
            var document = await context.OpenAsync(req => { req.Content(content); });

            try
            {
                var divMainContainer = document.QuerySelector("#main-container");
                if (divMainContainer != null)
                {
                    var htmlPage = divMainContainer.TextContent;
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
            return false;
        }
    }
}
