namespace WebAPIForHPP.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }
}
