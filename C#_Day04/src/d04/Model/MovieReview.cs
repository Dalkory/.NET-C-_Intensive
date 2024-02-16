using System.Text.Json;

namespace s21_d04_Model
{
    public class Movie : ISearchable
    {
        public string? Title { get; set; }
        public string? SummaryShort { get; set; }
        public bool IsCriticsPick { get; set; }
        public string? Url { get; set; }

        public static List<Movie> LoadMoviesFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            JsonDocument doc = JsonDocument.Parse(json);

            List<Movie> movies = new List<Movie>();

            foreach (JsonElement result in doc.RootElement.GetProperty("results").EnumerateArray())
            {
                Movie movie = new Movie
                {
                    Title = result.GetProperty("title").GetString(),
                    SummaryShort = result.GetProperty("summary_short").GetString(),
                    IsCriticsPick = result.GetProperty("critics_pick").GetInt32() == 1,
                    Url = result.GetProperty("link").GetProperty("url").GetString()
                };

                movies.Add(movie);
            }

            return movies;
        }
        
        public string GetTitle()
        {
            return Title ?? "";
        }

        public override string ToString()
        {
            string criticsPick = IsCriticsPick ? "[NYT critic’s pick]" : "";
            return $"{Title} {criticsPick}\n{SummaryShort}\n{Url}\n";
        }
    }
}