using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoviesApi.Model
{
    public class Movie
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("plot")]
        public string Plot { get; set; }

        [JsonPropertyName("poster")]
        public string Poster { get; set; }

        [JsonPropertyName("soundEffects")]
        public List<string> SoundEffects { get; set; }

        [JsonPropertyName("stills")]
        public List<string> Stills { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("imdbID")]
        public string ImdbID { get; set;}

        [JsonPropertyName("listingType")]
        public string  ListingType { get; set; }

        [JsonPropertyName("imdbRating")]
        public string ImdbRating { get; set; }
    }

    public class MoviesDTO
    {
        [JsonPropertyName("movies")]
        public List<Movie> Movies { get; set; }
    }
}

