using System;
using System.Collections.Generic;
using System.Linq;

namespace OAuth1aSignature
{
    public class SignatureGenerator
    {
        private const string Separator = "&";

        private const string OAuthConsumerKeyHeader = "oauth_consumer_key";
        private const string OAuthSignatureMethodHeader = "oauth_signature_method";
        private const string OAuthTokenHeader = "oauth_token";
        private const string OAuthVersionHeader = "oauth_version";
        private const string OAuthNonceHeader = "oauth_nonce";
        private const string OAuthTimestampHeader = "oauth_timestamp";

        public string Generate(string httpMethod,
                               Uri uri,
                               string oauthConsumerKey,
                               string oauthSignatureMethod,
                               string oauthToken,
                               string oauthVersion,
                               string oauthNonce,
                               string oauthTimeStamp
        )
        {
            var oauthUri = new OAuthUri(uri);

            var oauthConsumerKeyParameter = new OAuthParameter(OAuthConsumerKeyHeader, oauthConsumerKey, false);
            var oauthSignatureMethodParameter = new OAuthParameter(OAuthSignatureMethodHeader, oauthSignatureMethod, false);
            var oauthTokenParameter = new OAuthParameter(OAuthTokenHeader, oauthToken, false);
            var oauthVersionParameter = new OAuthParameter(OAuthVersionHeader, oauthVersion, false);
            var oauthNonceParameter = new OAuthParameter(OAuthNonceHeader, oauthNonce, false);
            var oauthTimeStampParameter = new OAuthParameter(OAuthTimestampHeader, oauthTimeStamp, false);

            var oauthParameters = new List<OAuthParameter>
                                  {
                                      oauthConsumerKeyParameter,
                                      oauthSignatureMethodParameter,
                                      oauthTokenParameter,
                                      oauthVersionParameter,
                                      oauthNonceParameter,
                                      oauthTimeStampParameter
                                  };

            var parameters = oauthUri.Parameters
                                     .Concat(oauthParameters)
                                     .ToList();

            var parameterString = ParameterStringFactory.Create(parameters);

            return $"{httpMethod.ToUpper()}" +
                   $"{Separator}" +
                   $"{oauthUri.EncodedBaseUri}" +
                   $"{Separator}" +
                   $"{parameterString}";
        }
    }
}