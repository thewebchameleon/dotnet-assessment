using System;

namespace TGS.Challenge
{
    /*
          Devise a function that checks if 1 word is an anagram of another, if the words are anagrams of
          one another return true, else return false

          "Anagram": An anagram is a type of word play, the result of rearranging the letters of a word or
          phrase to produce a new word or phrase, using all the original letters exactly once; for example
          orchestra can be rearranged into carthorse.

          areAnagrams("horse", "shore") should return true
          areAnagrams("horse", "short") should return false

          NOTE: Punctuation, including spaces should be ignored, e.g.

          horse!! shore = true
          horse  !! shore = true
            horse? heroes = true

          There are accompanying unit tests for this exercise, ensure all tests pass & make
          sure the unit tests are correct too.
       */
    public class Anagram
    {
        public bool AreAnagrams(string word1, string word2)
        {
            ValidateConstraints(word1, word2);

            word1 = RemovePunctuationAndSpaces(word1);
            word2 = RemovePunctuationAndSpaces(word2);

            var word1Sorted = SortLettersAscending(word1);
            var word2Sorted = SortLettersAscending(word2);

            return word1Sorted == word2Sorted;
        }

        private void ValidateConstraints(string word1, string word2)
        {
            if (string.IsNullOrEmpty(word1))
            {
                throw new ArgumentException("Word 1 is required");
            }

            if (string.IsNullOrEmpty(word2))
            {
                throw new ArgumentException("Word 2 is required");
            }
        }

        private string RemovePunctuationAndSpaces(string value)
        {
            var result = string.Empty;
            foreach (var charValue in value)
            {
                if (!char.IsPunctuation(charValue) && charValue != ' ')
                {
                    result += charValue;
                }
            }
            return result;
        }

        private string SortLettersAscending(string value)
        {
            char[] charArray = value.ToLower().ToCharArray();
            Array.Sort(charArray);

            var result = string.Empty;
            foreach (var charValue in charArray)
            {
                result += charValue;
            }
            return result;
        }
    }
}
