using System.Text.RegularExpressions;

namespace API.Services
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValid(string email)
        {
            ArgumentNullException.ThrowIfNull(email);

            Match m = Regex.Match(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            if (m.Success)
                return true;
            return false;
        }
    }
}
