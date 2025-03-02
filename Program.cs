using System;
using System.IO;
using System.Threading;
using System.Globalization;

// Simulação de coleta de dados de sensores em C#
// O código gera dados aleatórios de temperatura, pressão, umidade, entre outros, e grava esses dados em um arquivo CSV.
// A data de início é gerada aleatoriamente, e o tempo é simulado para avançar a cada iteração do loop a cada 100 minutos.

// Interface que define o método para leitura de dados do sensor
public interface ISensor
{
    (double Temperature, double Pressure, double Humidity, double Altitude,
     double WindDirection, double WindSpeed, double Rainfall, double UVIndex) ReadData();
}

// Implementação simulada do sensor, gerando valores aleatórios
public class SimulatedSensor : ISensor
{
    private Random _random = new Random();

    public (double Temperature, double Pressure, double Humidity, double Altitude,
            double WindDirection, double WindSpeed, double Rainfall, double UVIndex) ReadData()
    {
        double temp = _random.NextDouble() * 40;         // 0 a 40 °C
        double pressure = 950 + _random.NextDouble() * 100; // 950 a 1050 hPa
        double humidity = _random.NextDouble() * 100;        // 0 a 100%
        double altitude = _random.NextDouble() * 1000;       // 0 a 1000 m
        double windDirection = _random.NextDouble() * 360;   // 0 a 360° (direção do vento)
        double windSpeed = _random.NextDouble() * 100;       // 0 a 100 km/h
        double rainfall = _random.NextDouble() * 100;        // 0 a 100 mm (chuva)
        double uvIndex = _random.NextDouble() * 11;          // Índice UV de 0 a 11+

        return (temp, pressure, humidity, altitude, windDirection, windSpeed, rainfall, uvIndex);
    }
}

// Classe para gerar uma data aleatória
public class DateTimeSimulator
{
    private Random _random = new Random();

    // Simula uma data entre um ano específico e a data atual
    public DateTime GenerateRandomDate()
    {
        int year = 2023; // Define o ano base
        int month = _random.Next(1, 13); // Mês entre 1 e 12
        int day = _random.Next(1, DateTime.DaysInMonth(year, month) + 1); // Dia válido para o mês
        return new DateTime(year, month, day);
    }
}

class Program
{
    static void Main()
    {
        ISensor sensor = new SimulatedSensor();
        DateTimeSimulator dateSimulator = new DateTimeSimulator();
        string filePath = "01_Sjc.csv";

        // Se o arquivo não existe, cria, com cabeçalho
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Timestamp,UTCTime,Temperature,Pressure,Humidity,Altitude,WindDirection,WindSpeed,Rainfall,UVIndex\n");
        }

        DateTime startTime = dateSimulator.GenerateRandomDate();

        // Loop para 24 horas (de 0000 até 2300)
        for (int setOfHour = 0; setOfHour < 2400; setOfHour += 100)
        {
            DateTime currentTime = startTime.AddHours(setOfHour / 100); // Avança o tempo em 1 hora a cada iteração
            string timestamp = currentTime.ToString("yyyy-MM-dd");
            string day = currentTime.Day.ToString("00");
            string month = currentTime.Month.ToString("00");
            string utcTime = setOfHour.ToString("0000"); // Formato HH:mm (ex: 00:00, 01:00, etc.)

            Console.Clear();
            var data = sensor.ReadData();

            Console.WriteLine($"Data/Hora: {timestamp} {utcTime}");
            Console.WriteLine($"Temperatura: {data.Temperature:0.#}°C");
            Console.WriteLine($"Pressão atmosférica: {data.Pressure:#.##} hPa");
            Console.WriteLine($"Umidade: {data.Humidity:#.##}%");
            Console.WriteLine($"Altitude: {data.Altitude:#} m");
            Console.WriteLine($"Direção do vento: {data.WindDirection:#.##}°");
            Console.WriteLine($"Velocidade do vento: {data.WindSpeed:#.##} km/h");
            Console.WriteLine($"Pluviômetro: {data.Rainfall:#.##} mm");
            Console.WriteLine($"Radiação UV: {data.UVIndex:#.##}");

            // Formata números corretamente para não misturar separadores decimais
            string csvLine = string.Format(CultureInfo.InvariantCulture,
                "{0},{1},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8:0.00},{9:0.00}\n",
                timestamp, utcTime,
                data.Temperature, data.Pressure, data.Humidity, data.Altitude,
                data.WindDirection, data.WindSpeed, data.Rainfall, data.UVIndex
            );

            // Escreve no arquivo
            File.AppendAllText(filePath, csvLine);

            // "Espera 1 hora antes da próxima leitura" (simulado com 100 ms)
            Thread.Sleep(1000); // 1s
        }

        Console.Clear();
        Console.WriteLine("Coleta de dados concluída para 24 horas.");
    }
}
