namespace Core.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }

        private Customer() { }

        public Customer(string id, string name, string? email, string? phoneNumber, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public Customer(string name, string password, string? email, string? phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
