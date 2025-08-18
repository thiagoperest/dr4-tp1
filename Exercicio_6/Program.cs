namespace Exercicio_6

{
    public class Logger
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine($"[CONSOLE] {message}");
        }
        
        public void LogToFile(string message)
        {
            Console.WriteLine($"[ARQUIVO] {message}");
        }
        
        public void LogToDatabase(string message)
        {
            Console.WriteLine($"[BANCO DE DADOS] {message}");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Registro de Logs");
            Console.WriteLine();
            
            Logger logger = new Logger();
            
            Action<string> multicastDelegate = logger.LogToConsole;
            multicastDelegate += logger.LogToFile;
            multicastDelegate += logger.LogToDatabase;
            
            Console.Write("Digite a mensagem de log: ");
            string message = Console.ReadLine();
            
            Console.WriteLine();
            Console.WriteLine("Registrando log...");
            multicastDelegate(message);
            
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
