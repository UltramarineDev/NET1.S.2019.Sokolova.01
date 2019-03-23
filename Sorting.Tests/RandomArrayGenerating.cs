namespace Sorting.Tests
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
            var array = new int[size];
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next();
            }

            return array;
        }
    }
}
