namespace bookapi.Models.Domain
{
    public class Book_Author
    {

        public int Id { get; set; }

        public int BId { get; set; }
        public Book Book { get; set; }

        public int AId { get; set; }
        public Author Author { get; set; }
    }
}
