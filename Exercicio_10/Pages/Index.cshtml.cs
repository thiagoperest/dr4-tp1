using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Exercicio_10.Pages
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
            Products = new List<Product>
            {
                new Product { Name = "Notebook Dell", Price = 7500.00m },
                new Product { Name = "Mouse Gamer", Price = 600.00m },
                new Product { Name = "Teclado Mecânico", Price = 1500.00m }
            };

            var sessionProducts = HttpContext.Session.GetString("Products");
            if (!string.IsNullOrEmpty(sessionProducts))
            {
                var userProducts = JsonSerializer.Deserialize<List<Product>>(sessionProducts);
                if (userProducts != null)
                {
                    Products.AddRange(userProducts);
                }
            }
        }
    }
}