namespace TCPServers
{
    internal class Program
    {
        // Instantiates new instances of a simple TCP server and a JSON tcp server.
        // Runs both and waits for both to "close" before exiting the program.
        static async Task Main(string[] args)
        {
            TCPServerSimple server = new();
            TCPServerJson serverJson = new();

            await Task.WhenAll(server.StartAsync(), serverJson.StartAsync());
        }
    }
}
