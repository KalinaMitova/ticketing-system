
namespace TicketingSystem.Web.Infrastructure.Security
{
    using System;
    using System.ComponentModel.DataAnnotations;

    [AttributeUsage(AttributeTargets.Property)]
    public class DoesNotContainAtribute : ValidationAttribute
    {
        private string word;

        public DoesNotContainAtribute(string word)
        {
            this.word = word;
            this.ErrorMessage = "{0} should not contain the word " + word;
        }

        public override bool IsValid(object value)
        {
            string valueAsString = value as string;
            if (valueAsString == null)
            {
                throw new ArgumentException("Does not contain attribute not set on string property!");
            }

            if (!valueAsString.Contains(this.word))
            {
                return true;
            }

            return false;
        } 
    }
}