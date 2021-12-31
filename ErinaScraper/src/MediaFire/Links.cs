using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper.src.MediaFire
{
    public class Links
    {
        [JsonProperty("normal_download")]
        public string NormalDownload { get; set; }
    }
}
