using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorShop.Api.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string IconCss { get; set; } = string.Empty;

        public Collection<Product> Produtos { get; set; }
        = new Collection<Product>();
    }
}
