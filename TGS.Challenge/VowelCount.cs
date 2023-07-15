using System;

namespace TGS.Challenge
{
    /*
        Devise a function that takes a string & returns the number of 
        vowels (aeiou) in that string.

        "Hi there!" = 3
        "What do you mean?"  = 6

        There are accompanying unit tests for this exercise, ensure all tests pass & make
        sure the unit tests are correct too.
     */
    public class VowelCount
    {
        private readonly string _vowelList = "aeiou";

        public int Count(string value)
        {
            ValidateConstraints(value);

            int vowelCount = 0;
            foreach (var charValue in value.ToLower())
            {
                foreach (var vowelCharValue in _vowelList)
                {
                    if (charValue == vowelCharValue)
                    {
                        vowelCount++;
                    }
                }
            }
            return vowelCount;
        }

        private void ValidateConstraints(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty");
            }
        }
    }
}
