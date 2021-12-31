using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper.src.MediaFire
{
    public class Permissions
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("explicit")]
        public string Explicit { get; set; }

        [JsonProperty("read")]
        public string Read { get; set; }

        [JsonProperty("write")]
        public string Write { get; set; }
    }
}
