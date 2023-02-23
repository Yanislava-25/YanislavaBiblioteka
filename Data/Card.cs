namespace Biblioteka.Data
{
    public class Card
    {
        public int Id { get; set; }
        //M:1
        public int BookId { get; set; }
        public Book Books { get; set; }

        //M:1
        public string ReaderId { get; set; }
        public Reader Readers { get; set; }

        public string Description { get; set; }
        public DateTime DateReceive { get; set; }
        public DateTime DateGive { get; set; }

        public DateTime RegisterOn { get; set; }
    }
}
