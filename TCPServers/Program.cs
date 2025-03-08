namespace TCPServers
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            TCPServerSimple server = new();
            TCPServerJson serverJson = new();

            await Task.WhenAll(server.StartAsync(), serverJson.StartAsync());
        }
    }
}
