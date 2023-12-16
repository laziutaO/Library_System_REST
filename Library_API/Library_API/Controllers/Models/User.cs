namespace Library_API.Controllers.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid AuthId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long Phone { get; set; }
    }
}
