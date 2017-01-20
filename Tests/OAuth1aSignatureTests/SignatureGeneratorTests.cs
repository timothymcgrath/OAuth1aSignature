using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuth1aSignature;

namespace OAuth1aSignatureTests
{
    [TestClass]
    public class SignatureGeneratorTests
    {
        private const string POST = "POST";

        [TestMethod]
        public void Generate_TwitterGetRequest_ReturnsCorrectSignatureBaseString()
        {
            var target = new SignatureGenerator();

            var expected = "POST&https%3A%2F%2Fapi.twitter.com%2F1%2Fstatuses%2Fupdate.json&include_entities%3Dtrue%26oauth_consumer_key%3Dxvz1evFS4wEEPTGEFPHBog%26oauth_nonce%3DkYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg%26oauth_signature_method%3DHMAC-SHA1%26oauth_timestamp%3D1318622958%26oauth_token%3D370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb%26oauth_version%3D1.0%26status%3DHello%2520Ladies%2520%252B%2520Gentlemen%252C%2520a%2520signed%2520OAuth%2520request%2521";

            var result = target.Generate(POST, 
                new Uri("https://api.twitter.com/1/statuses/update.json?include_entities=true&status=Hello%20Ladies%20%2b%20Gentlemen%2c%20a%20signed%20OAuth%20request%21"),
                "xvz1evFS4wEEPTGEFPHBog",
                "HMAC-SHA1",
                "370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb",
                "1.0",
                "kYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg",
                "1318622958");

            Assert.AreEqual(expected, result);
        }
    }
}
