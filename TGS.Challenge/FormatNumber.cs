using System;

namespace TGS.Challenge
{
    /*
        Devise a function that takes an input 'n' (integer) and returns a string that is the
        decimal representation of that number grouped by commas after every 3 digits. 
        
        NOTES: You cannot use any built-in formatting functions to complete this task.

        Assume: 0 <= n < 1000000000

        1 -> "1"
        10 -> "10"
        100 -> "100"
        1000 -> "1,000"
        10000 -> "10,000"
        100000 -> "100,000"
        1000000 -> "1,000,000"
        35235235 -> "35,235,235"

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class FormatNumber
    {
        private readonly string _separator;
        private readonly int _separatorInterval;

        public FormatNumber(string separator = ",", int separatorInterval = 3)
        {
            _separator = separator;
            _separatorInterval = separatorInterval;
        }

        public string Format(int value)
        {
            ValidateConstraints(value);

            var stringValue = value.ToString();
            if (stringValue.Length > _separatorInterval)
            {
                var reversedStringValue = ReverseText(stringValue);
                var reversedOutput = string.Empty;

                foreach (var charValue in reversedStringValue)
                {
                    reversedOutput += charValue;
                    var reversedOutputRaw = reversedOutput.Replace(_separator, string.Empty);
                    if (
                        reversedOutputRaw.Length != stringValue.Length
                        && reversedOutputRaw.Length % _separatorInterval == 0
                    )
                    {
                        reversedOutput += _separator;
                    }
                }
                stringValue = ReverseText(reversedOutput);
            }
            return stringValue;
        }

        private void ValidateConstraints(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value must be a positive number");
            }

            if (value >= 1000000000)
            {
                throw new ArgumentOutOfRangeException("Value must be less than 1000000000");
            }
        }

        private string ReverseText(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);

            var result = string.Empty;
            foreach (var charValue in charArray)
            {
                result += charValue;
            }
            return result;
        }
    }
}
