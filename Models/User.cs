namespace TaskAuthenticationAuthorization.Models
{
    public enum BuyerType { None, Regular, Golden, Wholesale }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public BuyerType BuyerType { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public Customer Customer { get; set; }
    }
}