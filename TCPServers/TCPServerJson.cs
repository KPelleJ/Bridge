using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TCPServers
{
    public class TCPServerJson
    {
        private IPAddress _ip = IPAddress.Any;
        private const int _portNumber = 5000;

        public async Task StartAsync()
        {
            TcpListener server = new TcpListener(_ip, _portNumber);
            server.Start();
            Console.WriteLine("JSON Server Started");

            while(true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            Console.WriteLine("Client connected to TCP json server");

            using var reader = new StreamReader(client.GetStream());
            using var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };

            while (client.Connected)
            {
                await Task.Delay(1000);
                await writer.WriteLineAsync("\nWelcome to the TCP Json server. Your now have 4 options:");
                await writer.WriteLineAsync("Method choice: random, add, subtract or close");
                await writer.WriteLineAsync("Your request must be in json format");
                await writer.WriteLineAsync("Example of a valid request:  {\"Method\": \"random\", \"Value1\": 1, \"Value2\": 20} \r\n");
                await writer.WriteLineAsync("Typing: {\"Method\": \"close\"} , will close the connection");

                var jsonLineInput = await reader.ReadLineAsync();

                if (string.IsNullOrWhiteSpace(jsonLineInput))
                {
                    await writer.WriteLineAsync("Your input was empty please input a valid Json command");
                    continue;
                }

                JsonRequest? request = SerializeRequest(jsonLineInput);

                if (request == null || !ValidRequestCheck(request))
                {
                    await writer.WriteLineAsync("The command is in incorrect Json format");
                    continue;
                }

                if (request.Method.ToLower() == "close")
                {
                    await writer.WriteLineAsync("Connection to the server has been closed");
                    break;
                }

                var JsonResponse = JsonSerializer.Serialize(ProcessRequest(request), new JsonSerializerOptions { WriteIndented = true });
                await writer.WriteLineAsync(JsonResponse);
            }

            client.Close();
            Console.WriteLine("Client disconnected");
        }

        private JsonRequest? SerializeRequest(string jsonLine)
        {
            try
            {
                return JsonSerializer.Deserialize<JsonRequest>(jsonLine);
            }
            catch
            {
                return null;
            }
        }

        private bool ValidRequestCheck(JsonRequest request)
        {
            if (request.Method == "close")
                return true;

            if (request.Method == null || request.Value1 == null || request.Value2 == null)
            {
                return false;
            }

            return request.Method.ToLower() switch
            {
                "random" or "add" or "subtract" => true,
                _ => false
            };
        }

        private JsonResponse ProcessRequest(JsonRequest request)
        {
            JsonResponse response = new() { Method = request.Method, Value1 = request.Value1, Value2 = request.Value2 };

            if (response.Value1.HasValue && response.Value2.HasValue)
            {
                switch (response.Method.Trim().ToLower())
                {
                    case "random":
                        response.Result = GenerateRandomNumber(response.Value1.Value, response.Value2.Value);
                        break;
                    case "add":
                        response.Result = response.Value1.Value + response.Value2.Value;
                        break;
                    case "subtract":
                        response.Result = response.Value1.Value - response.Value2.Value;
                        break;
                    default:
                        break;
                }
            }
            return response;
        }

        private int GenerateRandomNumber(int value1, int value2)
        {
            Random randomizer = new();

            int lowValue = Math.Min(value1, value2);
            int highValue = Math.Max(value1, value2);
            return randomizer.Next(lowValue, highValue);
        }
    }
}
