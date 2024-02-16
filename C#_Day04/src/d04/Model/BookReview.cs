using System.Text.Json;

namespace s21_d04_Model
{
    public class Book : ISearchable
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public int Rank { get; set; }
        public string? ListName { get; set; }
        public string? Url { get; set; }

        public static List<Book> LoadBooksFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            JsonDocument doc = JsonDocument.Parse(json);

            List<Book> books = new List<Book>();

            foreach (JsonElement result in doc.RootElement.GetProperty("results").EnumerateArray())
            {
                JsonElement bookDetails = result.GetProperty("book_details")[0];

                Book book = new Book
                {
                    Title = bookDetails.GetProperty("title").GetString(),
                    Author = bookDetails.GetProperty("author").GetString(),
                    Description = bookDetails.GetProperty("description").GetString(),
                    Rank = result.GetProperty("rank").GetInt32(),
                    ListName = result.GetProperty("list_name").GetString(),
                    Url = result.GetProperty("amazon_product_url").GetString()
                };

                books.Add(book);
            }

            return books;
        }

        public string GetTitle()
        {
            return Title ?? "";
        }

        public override string ToString()
        {
            return $"{Title} by {Author} [{Rank} on NYT’s {ListName}]\n{Description}\n{Url}\n";
        }
    }
}