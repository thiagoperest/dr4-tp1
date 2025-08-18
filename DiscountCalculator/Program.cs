namespace DiscountCalculator
{
    public delegate decimal CalculateDiscount(decimal originalPrice);
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Cálculo de Desconto");
            Console.WriteLine();
            
            Console.Write("Informe o preço original do produto: R$ ");
            
            if (decimal.TryParse(Console.ReadLine(), out decimal originalPrice))
            {
                CalculateDiscount discountDelegate = ApplyTenPercentDiscount;
                
                decimal finalPrice = discountDelegate(originalPrice);
                
                Console.WriteLine();
                Console.WriteLine($"Preço original: R$ {originalPrice:F2}");
                Console.WriteLine($"Desconto aplicado de 10%");
                Console.WriteLine($"Valor do desconto: R$ {(originalPrice - finalPrice):F2}");
                Console.WriteLine($"Preço final: R$ {finalPrice:F2}");
            }
            else
            {
                Console.WriteLine("Valor inválido! Por favor, digite um número válido para prosseguir!");
            }
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
        
        static decimal ApplyTenPercentDiscount(decimal price)
        {
            return price * 0.90m;
        }
    }
}
