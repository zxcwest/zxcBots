namespace TwitchChatBot
{
    internal class Program
    {

        public static TwitchClientContainer clientContainer = new TwitchClientContainer();
        static async Task Main(string[] args)
        {
            clientContainer.LoadConfig("config.json");
            await clientContainer.Initialize();
            Console.ReadLine();
        }
    }
}
