namespace Celestial
{
    public interface ILogger
    {
        void Log(string userName, string invalidLoginMessage);
        void Log(string userName, int first, int second, int result);
    }
}