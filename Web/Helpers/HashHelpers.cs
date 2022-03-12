using System.Text;

namespace Web.Helpers
{
    public static class HashHelpers
    {
        public static string MD5Hash(string text)
        {
            using (System.Security.Cryptography.MD5 md5 =
                   System.Security.Cryptography.MD5.Create())
            {
                byte[] retVal = md5.ComputeHash(Encoding.Unicode.GetBytes(text));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
