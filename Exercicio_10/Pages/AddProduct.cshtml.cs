using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Exercicio_10.Pages
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public string ProductName { get; set; } = string.Empty;
        
        [BindProperty]
        public decimal ProductPrice { get; set; }
        
        public bool IsSubmitted { get; set; } = false;
        public string SubmittedName { get; set; } = string.Empty;
        public decimal SubmittedPrice { get; set; }

        public void OnGet()
        {
            IsSubmitted = false;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var sessionProducts = HttpContext.Session.GetString("Products");
                List<Product> products;
                
                if (!string.IsNullOrEmpty(sessionProducts))
                {
                    products = JsonSerializer.Deserialize<List<Product>>(sessionProducts) ?? new List<Product>();
                }
                else
                {
                    products = new List<Product>();
                }

                products.Add(new Product 
                { 
                    Name = ProductName, 
                    Price = ProductPrice 
                });

                HttpContext.Session.SetString("Products", JsonSerializer.Serialize(products));
                
                SubmittedName = ProductName;
                SubmittedPrice = ProductPrice;
                
                ProductName = string.Empty;
                ProductPrice = 0;
                
                IsSubmitted = true;
            }
            
            return Page();
        }
    }
}