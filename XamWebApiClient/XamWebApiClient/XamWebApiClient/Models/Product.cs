using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace XamWebApiClient.Models
{
    public class Product
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Title")]
        public string Title { get; set; }

        [JsonPropertyName("Prix")]
        public float Prix { get; set; }

        [JsonPropertyName("Description")]
        public string Description { get; set; }
    }
}
