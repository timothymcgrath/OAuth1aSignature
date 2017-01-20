using System;
using System.Collections.Generic;
using System.Linq;

namespace OAuth1aSignature
{
    internal class OAuthUri
    {
        public OAuthUri(Uri uri)
        {
            var baseUri = $"{uri.Scheme}{Uri.SchemeDelimiter}{uri.Authority}{uri.AbsolutePath}";
            EncodedBaseUri = Encoder.Encode(baseUri);

            var queryString = uri.Query;
            queryString = queryString.Remove(0, 1);

            var keyValues = queryString.Split('&');

            Parameters = keyValues
                .Select(x => x.Split('='))
                .Select(x => new OAuthParameter(x[0], x[1], true))
                .ToList();
        }

        public string EncodedBaseUri { get; private set; }
        public IEnumerable<OAuthParameter> Parameters { get; private set; }
    }
}