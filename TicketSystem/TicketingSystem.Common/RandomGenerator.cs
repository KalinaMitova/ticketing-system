
namespace TicketingSystem.Common
{
    using System;
    using System.Text;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        public string RandomString (int minLength = 6, int maxLength = 20)
        {
            StringBuilder result = new StringBuilder();
            int length = this.random.Next(minLength, maxLength);

            for (int i = 0; i < length; i++)
            {               
                result.Append(Letters[this.random.Next(0, Letters.Length)]);
            }

            return result.ToString();
        }

        public int RandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }
    }
}
