namespace GameStore.Services
{
    public class Console_Logger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine($"[CONSOLE LOGGER] - {message}");
        }
    }
}