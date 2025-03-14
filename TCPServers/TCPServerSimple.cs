using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TCPServers
{
    public class TCPServerSimple
    {
        private IPAddress _ip = IPAddress.Any;
        private const int _portNumber = 4000;

        /// <summary>
        /// Starts the TCP server and awaits a client to be connected. Will run multiple async clients since the
        /// task result is discarded and will return to the await of a new TcpClient.
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {
            TcpListener server = new TcpListener(_ip, _portNumber);
            server.Start();
            Console.WriteLine($"Simple Server Started on port: {_portNumber}");

            while (true)
            {
                TcpClient client = await server.AcceptTcpClientAsync();
                _ = HandleClientAsync(client);
            }
        }

        /// <summary>
        /// Handles the logic for handling a client. Does various input validations to check for a valid input
        /// and redirects to the ProcessCommand method if input checks are valid.
        /// </summary>
        /// <param name="client">The connected client that is to be handled</param>
        /// <returns></returns>
        private async Task HandleClientAsync(TcpClient client)
        {
            Console.WriteLine("Client connected to TCP simple server");

            using var reader = new StreamReader(client.GetStream());
            using var writer = new StreamWriter(client.GetStream()) { AutoFlush = true };

            while (client.Connected)
            {
                await Task.Delay(1000);

                await writer.WriteLineAsync("Choose an action:'random' , 'add' , 'subtract' or 'close'");

                // Reads the input from the client
                string? lineInput = await reader.ReadLineAsync();

                // Validates and handles the actions for the inputLine
                if (string.IsNullOrWhiteSpace(lineInput))
                {
                    await writer.WriteLineAsync("Invalid input");
                    continue;
                }

                string input = lineInput.Trim().ToLower();

                if (!ValidCommandCheck(input))
                {
                    await writer.WriteLineAsync("Invalid input");
                    continue;
                }

                //Closes the client if the input is "close"
                if (input == "close")
                {
                    await writer.WriteLineAsync("Connection to the server has been closed");
                    break;
                }

                await Task.Delay(500);

                var response = await ProcessCommand(input, reader, writer);
                await writer.WriteLineAsync(response);
            }

            client.Close();
            Console.WriteLine("Client Disconnected");
        }


        // Helper methods
        private bool ValidCommandCheck(string input)
        {
            return input switch
            {
                "close" or "random" or "add" or "subtract" => true,
                _ => false
            };
        }

        private async Task<string> ProcessCommand(string command, StreamReader reader, StreamWriter writer)
        {
            await writer.WriteLineAsync("Input values in the format: value1 value2");
            string? valueInput = await reader.ReadLineAsync();

            int[]? numbers = ParseInput(valueInput);
            if (numbers == null || numbers.Length != 2) return ("Bad input, please try again");

            return command switch
            {
                "random" => GenerateRandomNumber(numbers[0], numbers[1]),
                "add" => $"The result of {numbers[0]} + {numbers[1]} = {numbers[0] + numbers[1]}",
                "subtract" => $"The result of {numbers[0]} - {numbers[1]} = {numbers[0] - numbers[1]}",
                _ => "Unknown command"
            };
        }

        private int[]? ParseInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            try
            {
                return input.Split().Select(int.Parse).ToArray();
            }
            catch
            {
                return null;
            }
        }

        private string GenerateRandomNumber(int value1, int value2)
        {
            Random randomizer = new();

            int lowValue = Math.Min(value1, value2);
            int highValue = Math.Max(value1, value2);
            int randomNumber = randomizer.Next(lowValue, highValue);

            return $"Your random number between {lowValue} and {highValue} is {randomNumber}";
        }
    }
}
