using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper.src.MediaFire
{





    public class MediaFireResponse
    {
        [JsonProperty("response")]
        public Response Response { get; set; }
    }


}
