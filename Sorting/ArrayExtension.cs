using System;
using System.Collections.Generic;

namespace Sorting
{
    /// <summary>
    /// Sort array of integers in ascending order. Has 2 sorting options.
    /// </summary>
    public static class ArrayExtension
    {
        #region NET.S.2019.Sokolova.01 - task 1
        /// <summary>
        /// generate random number
        /// </summary>
        private static Random random = new Random();

        /// <summary>
        /// Sort array of integers using merge sort algorithm
        /// </summary>
        /// <param name="items">array of integers</param>
        /// <returns>array of integers sorted in ascending order</returns>
        /// <exception cref="System.ArgumentException">Thrown when array is empty</exception>
        public static int[] MergeSort(int[] items)
        {
            if (items.Length == 0)
            {
                throw new ArgumentException();
            }

            MergeSortMain(items);
            return items;
        }

        /// <summary>
        /// Sort array of integers using quick sort algorithm
        /// </summary>
        /// <param name="items">array of integers</param>
        /// <returns>array of integers sorted in ascending order</returns>
        /// <exception cref="System.ArgumentException">Thrown when array is empty</exception>
        public static int[] QuickSort(int[] items)
        {
            if (items.Length == 0)
            {
                throw new ArgumentException();
            }

            QuicksortHelper(items, 0, items.Length - 1);
            return items;
        }

        /// <summary>
        /// Method implement the way for recursively dividing an array into groups
        /// </summary>
        /// <param name="items">array of items</param>
        private static void MergeSortMain(int[] items)
        {
            if (items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;
            int rightSize = items.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];
            Array.Copy(items, 0, left, 0, leftSize);
            Array.Copy(items, leftSize, right, 0, rightSize);
            MergeSortMain(left);
            MergeSortMain(right);
            Merge(items, left, right);
        }

        /// <summary>
        /// Method merges items in the right order
        /// </summary>
        /// <param name="items">array of items</param>
        /// <param name="left">array of items on the left side</param>
        /// <param name="right">array of items on the right side</param>
        private static void Merge(int[] items, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length;
            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remaining--;
            }
        }

        /// <summary>
        /// swap items
        /// </summary>
        /// <param name="items">array of integers</param>
        /// <param name="left">left item</param>
        /// <param name="right">right item</param>
        private static void Swap(int[] items, int left, int right)
        {
            if (left != right)
            {
                int temp = items[left];
                items[left] = items[right];
                items[right] = temp;
            }
        }

        /// <summary>
        /// Method is used for recursion call left and right parts of array 
        /// </summary>
        /// <param name="items">array of items</param>
        /// <param name="left">array of items on the left side</param>
        /// <param name="right">array of items on the right side</param>
        private static void QuicksortHelper(int[] items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = random.Next(left, right);
                int newPivot = Partition(items, left, right, pivotIndex);

                QuicksortHelper(items, left, newPivot - 1);
                QuicksortHelper(items, newPivot + 1, right);
            }
        }

        /// <summary>
        /// Method transfer values using special condition
        /// </summary>
        /// <param name="items">array of items</param>
        /// <param name="left">array of items on the left side</param>
        /// <param name="right">array of items on the right side</param>
        /// <param name="pivotIndex">key element that generate randomly</param>
        /// <returns> index stored</returns>
        private static int Partition(int[] items, int left, int right, int pivotIndex)
        {
            int pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (items[i].CompareTo(pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }
        #endregion
        #region NET.S.2019.Sokolova.02 - task 2
        /// <summary>
        /// Method finds maximum element in array of integers using recursive search algorithm.
        /// </summary>
        /// <param name="array">source array of integers</param>
        /// <returns>maximum value</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the input array is epmty.</exception>
        public static int FindMaxElement(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }
            
            return FindMaxElementHelp(array);
        }

        private static int FindMaxElementHelp(int[] array)
        {
            if (array.Length <= 10000)
            {
                return FindMax(array);
            }

            int leftSize = array.Length / 2;
            int rightSize = array.Length - leftSize;
            int[] left = new int[leftSize];
            int[] right = new int[rightSize];
            Array.Copy(array, 0, left, 0, leftSize);
            Array.Copy(array, leftSize, right, 0, rightSize);

            return Math.Max(FindMaxElementHelp(left),FindMaxElementHelp(right));
        }

        private static int FindMax(int[] array, int index = 0)
        {
            if (index == array.Length)
            {
                return array[0];
            }

            return Math.Max(array[index], FindMax(array, index + 1));
        }

        #endregion
        #region NET.S.2019.Sokolova.02 - task 3
        /// <summary>
        /// Method finds index of element in array of double for which the sum 
        /// of the elements on the left of it is equal to the sum of the elements on the right.
        /// </summary>
        /// <param name="array">Source array of double.</param>
        /// <returns>index of element or null if no such element exist</returns>
        /// <exception cref = "ArgumentNullException" > Thrown when the input array is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the input array is epmty.</exception>
        public static int? FindIndex(double[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }

            double sumLeft = 0;
            double sumRight = 0;

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    sumLeft += array[j];
                }

                for (int j = i + 1; j < array.Length; j++)
                {
                    sumRight += array[j];
                }

                if (sumLeft == sumRight)
                {
                    return i;
                }

                sumLeft = 0;
                sumRight = 0;
            }

            return null;
        }
        #endregion
        #region NET.S.2019.Sokolova.02 - task 4
        /// <summary>
        /// Method filters input array by removing elements without input digit
        /// </summary>
        /// <param name="array">input array of integers</param>
        /// <param name="key">integer digit</param>
        public static int[] FilterArrayByKey(int[] array, int key)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Source array can not be null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Source array can not be empty.", nameof(array));
            }

            if (key > 9 || key < 0)
            {
                throw new ArgumentException("Input number is not a digit.", nameof(key));
            }

            List<int> resultValuesList = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                string t = array[i].ToString();
                if (t.Contains(key.ToString()))
                {
                    resultValuesList.Add(Convert.ToInt32(t));
                }
            }

            return resultValuesList.ToArray();
        }
        #endregion
    }
}