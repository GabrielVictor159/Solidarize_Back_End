using BCrypt.Net;

namespace Solidarize.Domain.Cryptography
{
    public static class CryptographyExtension
    {
        public static (string Result, string Method) PasswordEncryption(this string password)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                string encryptedPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                return (encryptedPassword, "MD5");
            }
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
