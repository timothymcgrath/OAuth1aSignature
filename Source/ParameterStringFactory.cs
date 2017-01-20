using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAuth1aSignature
{
    public static class ParameterStringFactory
    {
        internal static string Create(List<OAuthParameter> parameters)
        {
            parameters.Sort();

            var builder = new StringBuilder();

            foreach (var parameter in parameters)
            {
                if (parameter != parameters.First())
                    builder.Append("&");

                builder.Append(parameter);
            }

            return Encoder.Encode(builder.ToString());
        }
    }
}