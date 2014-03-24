using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ogsysCRM.Utils
{
    public class GravatarUtil
    {
        private const string GRAVATAR_IMG_URL = @"http://www.gravatar.com/avatar/";
        public static string GetGravatarImgUrl(string EmailAddress)
        {
            string preppedEmail = EmailAddress.Trim().ToLower();

            string url = String.Format("{0}{1}?r=pg",
                GRAVATAR_IMG_URL,
                GetHash(preppedEmail));

            return url;
        }

        public static string GetHash(string preppedEmail)
        {
            byte[] hash;
            using (MD5 md5 = MD5.Create())
            {
                hash = md5.ComputeHash(Encoding.UTF8.GetBytes(preppedEmail));
            }

            //http://www.danesparza.net/2010/10/using-gravatar-images-with-c-asp-net/
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}