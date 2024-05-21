using System.ComponentModel.DataAnnotations;
namespace bookapi.Models.Domain
{
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }
        public string PublisherName { get; set; }

        public List<Book> Books { get; set; }
    }
}
