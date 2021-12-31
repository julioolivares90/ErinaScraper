using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErinaScraper.src.ErinaScraper.src.MediaFire
{
    public class FolderContent
    {
        [JsonProperty("chunk_size")]
        public string ChunkSize { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }

        [JsonProperty("chunk_number")]
        public string ChunkNumber { get; set; }

        [JsonProperty("folderkey")]
        public string Folderkey { get; set; }

        [JsonProperty("files")]
        public List<File> Files { get; set; }

        [JsonProperty("more_chunks")]
        public string MoreChunks { get; set; }

        [JsonProperty("revision")]
        public string Revision { get; set; }
    }
}
