namespace Exercicio_2

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Boas-Vindas Multilíngue");
            Console.WriteLine();

            Console.Write("Digite seu nome: ");
            string userName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Escolha um idioma:");
            Console.WriteLine("1 - Português");
            Console.WriteLine("2 - Inglês");
            Console.WriteLine("3 - Espanhol");
            Console.Write("Digite sua opção (1-3): ");

            string choice = Console.ReadLine();

            Action<string> welcomeMessage = null;

            switch (choice)
            {
                case "1":
                    welcomeMessage = ShowWelcomePortuguese;
                    break;
                case "2":
                    welcomeMessage = ShowWelcomeEnglish;
                    break;
                case "3":
                    welcomeMessage = ShowWelcomeSpanish;
                    break;
                default:
                    Console.WriteLine("Opção inválida! Usando português como padrão.");
                    welcomeMessage = ShowWelcomePortuguese;
                    break;
            }

            Console.WriteLine();
            welcomeMessage(userName);

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void ShowWelcomePortuguese(string name)
        {
            Console.WriteLine("Bem-vindo(a)!");
            Console.WriteLine($"Olá, {name}!");
            Console.WriteLine("Bem-vindo(a) ao sistema corporativo!");
        }

        static void ShowWelcomeEnglish(string name)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine($"Hello, {name}!");
            Console.WriteLine("Welcome to the corporate system!");
        }

        static void ShowWelcomeSpanish(string name)
        {
            Console.WriteLine("¡Bienvenido!");
            Console.WriteLine($"¡Hola, {name}!");
            Console.WriteLine("¡Bienvenido al sistema corporativo!");
        }
    }
}
