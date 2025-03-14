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

        /// <summary>
        /// Starts the TCP server and awaits a client to be connected. Will run multiple async clients since the
        /// task result is discarded and will return to the await of a new TcpClient.
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {
            TcpListener server = new TcpListener(_ip, _portNumber);
            server.Start();
            Console.WriteLine($"JSON Server Started on port: {_portNumber}");

            while(true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        /// <summary>
        /// Handles the logic for handling a client. Does various input validations to check for a valid input
        /// and redirects to the ProcessRequest method if input checks are valid.
        /// </summary>
        /// <param name="client">The connected client that is to be handled</param>
        /// <returns></returns>
        private async Task HandleClientAsync(TcpClient client)
        {
            Console.WriteLine("Client connected to TCP json server");

            using var reader = new StreamReader(client.GetStream());
            using var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };

            while (client.Connected)
            {
                // Instructions to help the client
                await Task.Delay(1000);
                await writer.WriteLineAsync("\nWelcome to the TCP Json server. Your now have 4 options:");
                await writer.WriteLineAsync("Method choice: random, add, subtract or close");
                await writer.WriteLineAsync("Your request must be in json format");
                await writer.WriteLineAsync("Example of a valid request:  {\"Method\": \"random\", \"Value1\": 1, \"Value2\": 20} \r\n");
                await writer.WriteLineAsync("Typing: {\"Method\": \"close\"} , will close the connection");

                // Reads the input from the client
                var jsonLineInput = await reader.ReadLineAsync();

                // Validation and handling of the clients request
                if (string.IsNullOrWhiteSpace(jsonLineInput))
                {
                    var errorResponse = ErrorMessage("Empty input", "Your input did not contain anything. Pleaes input a valid JSON command");
                    await writer.WriteLineAsync(errorResponse);

                    continue;
                }

                JsonRequest? request = SerializeRequest(jsonLineInput);

                if (request == null || !ValidRequestCheck(request))
                {
                    var errorResponse = ErrorMessage("Invalid JSON", "The command is in incorrect Json format");
                    await writer.WriteLineAsync(errorResponse);

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

        // Helper methods

        /// <summary>
        /// Takes a string input in JSON format, deserializes it to a JsonRequest object.
        /// </summary>
        /// <param name="jsonLine">String input in JSON format</param>
        /// <returns>The request in a JsonRequest object. Null if the JSON could not be serialized </returns>
        private JsonRequest? SerializeRequest(string jsonLine)
        {
            try
            {
                return JsonSerializer.Deserialize<JsonRequest>(jsonLine);
            }
            catch(JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// Validates whether the JsonRequest object contains a valid command and if the given values are null
        /// </summary>
        /// <param name="request">Request to be validated</param>
        /// <returns>True if the command and values are valid, otherwise false</returns>
        private bool ValidRequestCheck(JsonRequest request)
        {
            if (request.Method.Trim().ToLower() == "close")
                return true;

            if (request.Method == null || request.Value1 == null || request.Value2 == null)
            {
                return false;
            }

            return request.Method.Trim().ToLower() switch
            {
                "random" or "add" or "subtract" => true,
                _ => false
            };
        }

        /// <summary>
        /// Handles the request and processes it into and JsonResponse object.
        /// </summary>
        /// <param name="request">JsonRequest to be processed</param>
        /// <returns>A JsonResponse object containing data from the request and a result</returns>
        private JsonResponse ProcessRequest(JsonRequest request)
        {
            JsonResponse response = new() { Method = request.Method, Value1 = request.Value1.Value, Value2 = request.Value2.Value };

            
            switch (response.Method.Trim().ToLower())
            {
                case "random":
                    response.Result = GenerateRandomNumber(response.Value1, response.Value2);
                    break;
                case "add":
                    response.Result = response.Value1 + response.Value2;
                    break;
                case "subtract":
                    response.Result = response.Value1 - response.Value2;
                    break;
                default:
                    break;
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

        /// <summary>
        /// Generates an errormessage to be sent to the client
        /// </summary>
        /// <param name="errorType">Type of the error</param>
        /// <param name="message">More information regarding the error</param>
        /// <returns>A string containing the error information in Json format</returns>
        private string ErrorMessage(string errorType, string message)
        {
            JsonErrorMessage error = new(errorType, message);
            var errorResponse = JsonSerializer.Serialize(error, new JsonSerializerOptions { WriteIndented = true });

            return errorResponse;
        }
    }
}
