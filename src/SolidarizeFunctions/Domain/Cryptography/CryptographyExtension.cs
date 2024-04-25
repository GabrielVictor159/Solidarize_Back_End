using BCrypt.Net;

namespace Solidarize.Domain.Cryptography
{
    public static class CryptographyExtension
    {
        public static (string Result, string Method) PasswordEncryption(this string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
            return (encryptedPassword, "BCrypt");
        }

        public static int PasswordComplexityIndex(this string password)
        {
            int complexityIndex = 0;

            complexityIndex += password.Length;

            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[A-Z]")) complexityIndex += 5;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[a-z]")) complexityIndex += 5;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[0-9]")) complexityIndex += 5;
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "[^a-zA-Z0-9]")) complexityIndex += 5;

            if (System.Text.RegularExpressions.Regex.IsMatch(password, "(.)\\1{2,}")) complexityIndex -= 10; 
            if (System.Text.RegularExpressions.Regex.IsMatch(password, "123|321|abc|cba")) complexityIndex -= 10;

            return complexityIndex;
        }
    }
}
