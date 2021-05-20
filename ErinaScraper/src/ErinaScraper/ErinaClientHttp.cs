using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ErinaScraper.src.ErinaScraper
{
    class ErinaClientHttp
    {
        private  HttpClient httpClient;

        public HttpClient InitHttp(string urlfer)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("method", "GET");

            httpClient.DefaultRequestHeaders.Add("authority", "lectortmo.com");
            httpClient.DefaultRequestHeaders.Add("scheme", "https");
            httpClient.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.Add("referer", urlfer);
            httpClient.DefaultRequestHeaders.Add("accept-language", "es-SV,es-419;q=0.9,es;q=0.8");
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");


            return httpClient;
        }

        public static HttpClient HttpClientForLibrary()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("method", "GET");

            httpClient.DefaultRequestHeaders.Add("authority", "lectortmo.com");
            httpClient.DefaultRequestHeaders.Add("method", "GET");
            httpClient.DefaultRequestHeaders.Add("path", "/library");
            httpClient.DefaultRequestHeaders.Add("scheme", "https");


            httpClient.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.Add("referer", "https://lectortmo.com/");
            httpClient.DefaultRequestHeaders.Add("accept-language", "es-SV,es-419;q=0.9,es;q=0.8");
            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36");

            return httpClient;
        }

    }
}
