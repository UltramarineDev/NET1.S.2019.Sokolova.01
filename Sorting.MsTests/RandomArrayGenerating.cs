namespace Sorting.MsTests
{
    using System;

    /// <summary>
    /// Class for generating random array
    /// </summary>
    public static class RandomArrayGenerating
    {
        /// <summary>
        /// generate random array
        /// </summary>
        /// <param name="size">size of array</param>
        /// <returns>randomly generated array</returns>
        public static int[] GenerateArray(int size)
        {
            int[] array = new int[size];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            return ArrayShuffle(array);
        }

        private static int[] ArrayShuffle(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                SwapIndexes(array, i, random.Next(array.Length - i));
            }

            return array;
        }

        private static void SwapIndexes(int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
