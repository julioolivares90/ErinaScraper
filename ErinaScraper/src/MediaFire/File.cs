using Newtonsoft.Json;
using System;

namespace ErinaScraper.src.ErinaScraper.src.MediaFire
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class File
    {
        [JsonProperty("quickkey")]
        public string Quickkey { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("password_protected")]
        public string PasswordProtected { get; set; }

        [JsonProperty("mimetype")]
        public string Mimetype { get; set; }

        [JsonProperty("filetype")]
        public string Filetype { get; set; }

        [JsonProperty("view")]
        public string View { get; set; }

        [JsonProperty("edit")]
        public string Edit { get; set; }

        [JsonProperty("revision")]
        public string Revision { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("permissions")]
        public Permissions Permissions { get; set; }

        [JsonProperty("downloads")]
        public string Downloads { get; set; }

        [JsonProperty("views")]
        public string Views { get; set; }

        [JsonProperty("links")]
        public Links Links { get; set; }

        [JsonProperty("created_utc")]
        public DateTime CreatedUtc { get; set; }
    }


}
