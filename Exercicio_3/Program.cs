namespace Exercicio_3

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Cálculo de Área");
            Console.WriteLine();

            Console.Write("Digite a base do retângulo: ");
            if (!double.TryParse(Console.ReadLine(), out double baseValue))
            {
                Console.WriteLine("Valor inválido para a base!");
                return;
            }

            Console.Write("Digite a altura do retângulo: ");
            if (!double.TryParse(Console.ReadLine(), out double height))
            {
                Console.WriteLine("Valor inválido para a altura!");
                return;
            }

            Func<double, double, double> calculateArea = CalculateRectangleArea;

            double area = calculateArea(baseValue, height);

            Console.WriteLine();
            Console.WriteLine("Resultado do Cálculo");
            Console.WriteLine($"Base: {baseValue}");
            Console.WriteLine($"Altura: {height}");
            Console.WriteLine($"Área do retângulo: {area}");

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static double CalculateRectangleArea(double baseValue, double height)
        {
            return baseValue * height;
        }
    }
}
