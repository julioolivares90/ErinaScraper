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

            httpClient.DefaultRequestHeaders.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
            httpClient.DefaultRequestHeaders.Add("referer", urlfer);

            return httpClient;
        }

    }
}
