using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuth1aSignature;

namespace OAuth1aSignatureTests
{
    [TestClass]
    public class EncoderTest
    {
        [TestMethod]
        public void Encode_StringWithPercentEncodedValue_ReturnsInCaps()
        {
            var input = "Test:";
            var expected = "Test%3A";

            var actual = Encoder.Encode(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Encode_StringWithDoublePercentEncodedValue_ReturnsInCaps()
        {
            var input = "Test%3A";
            var expected = "Test%253A";

            var actual = Encoder.Encode(input);

            Assert.AreEqual(expected, actual);
        }
    }
}
