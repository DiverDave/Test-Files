using System;
using Xunit;
using SmsKeyPressDecoder;
using FluentAssertions;

namespace SmsKeyPressDecoderTests
{
    public class DecorderTests
    {

        [Fact]
        public void Test_DecodeKeyPress_WithEachNumberPressedOnce_ReturnsCorrectValue()
        {
            var inputKeys = "023456789";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo(" ADGJMPTW");
        }


        [Fact]
        public void Test_DecodeKeyPress_WithInputForCAT_Returns_CAT()
        {
            var inputKeys = "222028";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("CAT");
        }

        [Fact]
        public void Test_DecodeKeyPress_WithInputForA_CAT_Returns_A_CAT()
        {
            var inputKeys = "200222028";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("A CAT");
        }

        [Fact]
        public void Test_DecodeKeyPress_WithExcessiveKeyPress_ReturnsKey()
        {
            var inputKeys = "2222";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("A");
        }

        [Fact]
        public void Test_DecodeKeyPress_WithInputForAspeqMessage_ReturnsCorrectValue()
        {
                          // The   Aspeq      coding         challenge            is      to   decode         this        message 
            var inputKeys = "8443302777707337702226663444664022244255505553366433044477770866603033222666303308440444777706337777077772433";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("THE ASPEQ CODING CHALLENGE IS TO DECODE THIS MESSAGE");
        }

    }
}
