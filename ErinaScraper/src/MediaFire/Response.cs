using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper.src.MediaFire
{
    public class Response
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("asynchronous")]
        public string Asynchronous { get; set; }

        [JsonProperty("folder_content")]
        public FolderContent FolderContent { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("current_api_version")]
        public string CurrentApiVersion { get; set; }
    }
}
