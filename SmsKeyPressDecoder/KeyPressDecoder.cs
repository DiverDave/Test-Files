using System;
using System.Collections.Generic;
using System.Net.Http;

namespace SmsKeyPressDecoder
{
    public class KeyPressDecoder
    {
        public KeyPressDecoder()
        {
            this.KeyPressDictionary = new Dictionary<string, string>
            {
                {"2", "ABC"},
                {"3", "DEF"},
                {"4", "GHI"},
                {"5", "JKL"},
                {"6", "MNO"},
                {"7", "PQRS"},
                {"8", "TUV"},
                {"9", "WXYZ"},
                {"0", " "}
            };
        }

        Dictionary<string, string> KeyPressDictionary { get; }

        /// <summary>
        /// Decodes a string representing key presses on a multi tap feature phone. See read me for more information.
        /// </summary>
        /// <param name="inputKeys">A string containing the numbers 0 to 9 representing key presses</param>
        /// <returns>The decoded message</returns>
        public string Decode(string inputKeys)
        {
            string message = null;
            var index = 0;
            var lastKey = "";
            while (index < inputKeys.Length)
            {
                var keyChar = inputKeys[index];
                var keyCount = 1;
                while (index < inputKeys.Length-1 && keyChar == inputKeys[index + 1])
                {
                    keyCount++;
                    index++;
                }

                var key = keyChar.ToString();
                if (key  == "0")
                {
                    message += DecodeZero(inputKeys, index, keyCount, lastKey);
                }
                else
                {
                    var keyIndex = (keyCount -1) % this.KeyPressDictionary[key].Length;
                    message += this.KeyPressDictionary[key][keyIndex];
                    lastKey = key;
                }

                index++;
            }

            // add your code here
            // create as many unit tests or other functions as you like
            // tests are not case sensitive
            ///.....
            return message;
        }

        private string DecodeZero(string inputKeys, in int index, int keyCount, string lastKey)
        {
            string nextKey = inputKeys.Length > index + 1 ? inputKeys[index + 1].ToString() : null;
            var spaceCount = keyCount;
            if (nextKey == lastKey)
            {
                spaceCount-= 1;
            }

            return string.Empty.PadLeft(spaceCount, ' ');
        }


    }
}
