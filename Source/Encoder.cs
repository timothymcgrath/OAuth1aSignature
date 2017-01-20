using System.Text.RegularExpressions;
using System.Web;

namespace OAuth1aSignature
{
    public static class Encoder
    {
        public static string Encode(string input)
        {
            var encodedUrl = HttpUtility.UrlEncode(input);
            return UpperEscapes(encodedUrl);
        }
        
        private static string UpperEscapes(string input)
        {
            var reg2Digit = new Regex(@"%[a-f0-9]{2}");
            var uppercase = reg2Digit.Replace(input, i => i.Value.ToUpperInvariant());

            var reg4Digit = new Regex(@"%25[a-f0-9]{2}");
            return reg4Digit.Replace(uppercase, i => i.Value.ToUpperInvariant());
        }
    }
}