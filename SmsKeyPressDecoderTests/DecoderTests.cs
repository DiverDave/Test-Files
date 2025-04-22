using Xunit;
using SmsKeyPressDecoder;
using FluentAssertions;

namespace SmsKeyPressDecoderTests
{
    public class DecorderTests
    {
        [Theory]
        [InlineData("0", " ")]
        [InlineData("2", "A")]
        [InlineData("22", "B")]
        [InlineData("222", "C")]
        [InlineData("3", "D")]
        [InlineData("33", "E")]
        [InlineData("333", "F")]
        [InlineData("4", "G")]
        [InlineData("44", "H")]
        [InlineData("444", "I")]
        [InlineData("5", "J")]
        [InlineData("55", "K")]
        [InlineData("555", "L")]
        [InlineData("6", "M")]
        [InlineData("66", "N")]
        [InlineData("666", "O")]
        [InlineData("7", "P")]
        [InlineData("77", "Q")]
        [InlineData("777", "R")]
        [InlineData("7777", "S")]
        [InlineData("8", "T")]
        [InlineData("88", "U")]
        [InlineData("888", "V")]
        [InlineData("9", "W")]
        [InlineData("99", "X")]
        [InlineData("999", "Y")]
        [InlineData("9999", "Z")]
        public void Test_Decode_WithEveryKeyPressSequence_ReturnsTheCorrectLetter(string inputKeys, string expected)
        {
            var actual = new KeyPressDecoder().Decode(inputKeys);

            actual.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void Test_Decode_WithInputForCAT_ReturnsCAT()
        {
            var inputKeys = "222028";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("CAT");
        }

        [Fact]
        public void Test_Decode_WithInputForA_CAT_ReturnsA_CAT()
        {
            var inputKeys = "200222028";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("A CAT");
        }

        [Fact]
        public void Test_Decode_WithExcessiveKeyPress_ReturnsCorrectLetter()
        {
            var inputKeys = "2222";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("A");
        }

        [Fact]
        public void Test_Decode_WithExcessiveTraillingSpaces_ReturnsCorrectMessage()
        {
            var inputKeys = "200";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("A  ");
        }

        [Fact]
        public void Test_Decode_WithExcessiveLeadingSpaces_ReturnsCorrectMessage()
        {
            var inputKeys = "002";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("  A");
        }


        [Fact]
        public void Test_Decode_WithInputForAspeqMessage_ReturnsCorrectValue()
        {
            var inputKeys = "8443302777707337702226663444664022244255505553366433044477770866603033222666303308440444777706337777077772444433";

            var message = new KeyPressDecoder().Decode(inputKeys);

            message.Should().BeEquivalentTo("THE ASPEQ CODING CHALLENGE IS TO DECODE THIS MESSAGE");
        }

    }
}
