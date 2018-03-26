namespace TicketingSystem.Common
{
    public interface IRandomGenerator
    {
        string RandomString(int minLength = 6, int maxLength = 20);

        int RandomNumber(int min, int max);
    }
}