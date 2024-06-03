using System.Security.Cryptography;
using System.Text;

namespace VeterinarClinicApi.Another
{
    public class md5
    {
        public static string hashPasswordToMd5(string password)
        {
            MD5 md5 = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
            {
                sb.Append(a.ToString("x2"));
            }

            return Convert.ToString(sb);
        }
    }
}
