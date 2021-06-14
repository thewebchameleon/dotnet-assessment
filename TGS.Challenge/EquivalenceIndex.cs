using System;

namespace TGS.Challenge
{
    /*
         Given a zero-based integer array of length N, the equivalence index (i) is the index where the sum of all the items to the left of the index
         are equal to the sum of all the items to the right of the index.

         Constraints: 0 <= N <= 100 000

         Example: Given the following array [1, 2, 3, 4, 5, 7, 8, 10, 12]
         Your program should output "6" because 1 + 2 + 3 + 4 + 5 + 7 = 10 + 12

         If no index exists then output -1

         There are accompanying unit tests for this exercise, ensure all tests pass & make
          sure the unit tests are correct too.
       */

    public class EquivalenceIndex
    {
        public int Find(int[] numbers)
        {
            ValidateConstraints(numbers);

            var result = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                var leftArray = 0;
                for (int l = 0; l < i; l++)
                {
                    leftArray += numbers[l];
                }

                var rightArray = 0;
                for (int r = numbers.Length - 1; r > i; r--)
                {
                    rightArray += numbers[r];
                }

                if (leftArray == rightArray)
                {
                    return i;
                }
            }
            return result;
        }

        private void ValidateConstraints(int[] numbers)
        {
            if (numbers.Length > 100000)
            {
                throw new ArgumentOutOfRangeException("Array length must be less than than 100 000");
            }
        }
    }
}
