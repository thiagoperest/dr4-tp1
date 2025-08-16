namespace Exercicio_4

{
    public class TemperatureSensor
    {
        public event Action<double> TemperatureExceeded;
        
        private double currentTemperature;
        private const double TEMPERATURE_LIMIT = 100.0;
        
        public double CurrentTemperature
        {
            get { return currentTemperature; }
            set
            {
                currentTemperature = value;
                CheckTemperature();
            }
        }
        
        private void CheckTemperature()
        {
            if (currentTemperature > TEMPERATURE_LIMIT)
            {
                TemperatureExceeded?.Invoke(currentTemperature);
            }
        }
        
        public void ReadTemperature(double temperature)
        {
            Console.WriteLine($"Leitura atual do sensor: {temperature:F1}°C");
            CurrentTemperature = temperature;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sistema de Monitoramento de Temperatura");
            Console.WriteLine("Limite de segurança: 100°C");
            Console.WriteLine();
            
            TemperatureSensor sensor = new TemperatureSensor();
            
            sensor.TemperatureExceeded += ShowTemperatureAlert;
            
            string input;
            do
            {
                Console.Write("Digite a temperatura (ou 'sair' para finalizar): ");
                input = Console.ReadLine();
                
                if (input.ToLower() != "sair")
                {
                    if (double.TryParse(input, out double temperature))
                    {
                        sensor.ReadTemperature(temperature);
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido! Digite um número válido, para prosseguir!");
                    }
                    Console.WriteLine();
                }
                
            } while (input.ToLower() != "sair");
            
            Console.WriteLine("Sistema de monitoramento finalizado.");
        }
        
        static void ShowTemperatureAlert(double temperature)
        {
            Console.WriteLine("ALERTA DE TEMPERATURA!!!");
            Console.WriteLine($"ATENÇÃO: Temperatura de {temperature:F1}°C excede o limite de segurança!");
        }
    }
}
