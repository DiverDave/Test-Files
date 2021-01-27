using Xunit;
using SmsKeyPressDecoder;
using FluentAssertions;

namespace SmsKeyPressDecoderTests
{
    public class DecorderTests
    {

        [Fact]
        public void Test_DecodeKeyPress_WithInputForAspeqMessage_ReturnsCorrectValue()
        {
            var inputKeys = "8443302777707337702226663444664022244255505553366433044477770866603033222666303308440444777706337777077772433";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("THE ASPEQ CODING CHALLENGE IS TO DECODE THIS MESSAGE");
        }

    }
}
