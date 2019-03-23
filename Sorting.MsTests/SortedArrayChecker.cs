namespace Sorting.MsTests
{
    /// <summary>
    /// Class contain method for check array
    /// </summary>
    public static class SortedArrayChecker
    {
        /// <summary>
        /// Method check if array is sorted in ascending order
        /// </summary>
        /// <param name="array">input array</param>
        /// <returns>true - if array is sorted in ascending order</returns>
        public static bool CheckSortedArray(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
