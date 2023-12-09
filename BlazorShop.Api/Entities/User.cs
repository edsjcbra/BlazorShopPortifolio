using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;

        public Cart? Cart { get; set; }
    }
}
