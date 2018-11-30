namespace Celestial
{
    public interface IAuthenticator
    {
        bool IsAuthenticated(string userName, string password);
    }
}