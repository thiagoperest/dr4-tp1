namespace Exercicio_5

{
    public class DownloadManager
    {
        public event Action<string> DownloadCompleted;
        
        public void StartDownload(string fileName)
        {
            Console.WriteLine($"Iniciando download de {fileName}...");
            
            Thread.Sleep(3000);
            
            DownloadCompleted?.Invoke(fileName);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Download");
            Console.WriteLine();
            
            DownloadManager downloadManager = new DownloadManager();
            downloadManager.DownloadCompleted += ShowDownloadCompleted;
            
            Console.Write("Digite o nome do arquivo para download: ");
            string fileName = Console.ReadLine();
            
            downloadManager.StartDownload(fileName);
            
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
        
        static void ShowDownloadCompleted(string fileName)
        {
            Console.WriteLine($"Download de {fileName} concluído com sucesso!");
        }
    }
}
