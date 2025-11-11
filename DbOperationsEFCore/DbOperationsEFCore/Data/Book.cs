namespace DbOperationsEFCore.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string description { get; set; }
        public int noofPages { get; set; }
        public bool isactive { get; set; }
        public DateTime createdon { get; set; }

        public int LanguageId { get; set; } // Foreign key property

        public Language? Language { get; set; } // Navigation property
    }
}