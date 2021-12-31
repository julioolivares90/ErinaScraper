using ErinaScraper.src.ErinaScraper.src.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ErinaScraper.src.ErinaScraper.src.MediaFire
{
    public class MediaFieClient
    {
        HttpClient Http = new HttpClient();

        string urlApiMediaFire = "https://www.mediafire.com/api/1.4/folder/";
        public async Task<MediaFireResponse>  GetFilesOfMediaFire(string url)
        {
            var folderKey = StringHelpers.GetFolderKey(url);

            var newUrl = $"{urlApiMediaFire}get_content.php?r=ljch&content_type=files&filter=all&order_by=name&order_direction=asc&chunk=1&version=1.5&folder_key={folderKey}&response_format=json";
            
            var content =  await Http.GetStringAsync(newUrl);

            return JsonConvert.DeserializeObject<MediaFireResponse>(content);

        }
    }
}
