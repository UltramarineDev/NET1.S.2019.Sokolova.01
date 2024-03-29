﻿namespace Sorting.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    /// <summary>
    /// NUnitTests for ArrayExtension class
    /// </summary>
    [TestFixture]
    public class ArrayExtensionTests
    {
        #region Tests for Sorting methods
        /// <summary>
        /// Method tests MergeSort Method for Ordinary Array
        /// </summary>
        [TestCase(new int[] { -18, 0, int.MaxValue, int.MinValue, 6, -1000 })]
        public void MergeSortMethod_OrdinaryArray_SortAscending(int[] array)
        {
            int[] actual = ArrayExtension.MergeSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests QuickSort Method for Ordinary Array
        /// </summary>
        [TestCase(new int[] { -18, 0, int.MaxValue, int.MinValue, 6, -1000 })]
        public void QuickSortMethod_OrdinaryArray_SortAscending(int[] array)
        {
            int[] actual = ArrayExtension.QuickSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests MergeSort Method for Empty Array
        /// </summary> 
        [Test]
        public void MergeSortMethod_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.MergeSort(new int[] { }));
        }

        /// <summary>
        /// Method tests QuickSort Method for Empty Array
        /// </summary>
        [Test]
        public void QuickSortMethod_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.QuickSort(new int[] { }));
        }

        /// <summary>
        /// Method tests QuickSort Method for Large Array 
        /// </summary>
        [Test]
        public void QuickSortMethod_LargeArray_SortAscending()
        {
            int[] array = RandomArrayGenerating.GenerateArray(1000);

            int[] actual = ArrayExtension.QuickSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests MergeSort Method for Large Array
        /// </summary>
        [Test]
        public void MergeSortMethod_LargeArray_SortAscending()
        {
            int[] array = RandomArrayGenerating.GenerateArray(1000);

            int[] actual = ArrayExtension.MergeSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            Assert.IsTrue(result);
        }
        #endregion
        #region Tests for NET.S.2019.Sokolova.02 - task 2
        [TestCase(new int[] { 0, int.MaxValue, 80, 890000, 12, 0, 64 }, ExpectedResult = int.MaxValue)]
        [TestCase(new int[] { 65, 3, 1, 7, 432, 7563, 55, -431, -78, 0 }, ExpectedResult = 7563)]
        [TestCase(new int[] { -1000, -567, int.MinValue, -98, -6, -67, -67 }, ExpectedResult = -6)]
        [TestCase(new int[] { 9, 9, 9, 9, 9, 9, 9 }, ExpectedResult = 9)]
        public int FindMaxElementTests(int[] array)
           => ArrayExtension.FindMaxElement(array);

        [Test]
        public void FindMaxElement_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.FindMaxElement(new int[] { }));
        }

        [Test]
        public void FindMaxElement_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindMaxElement(null));
        }

        [Test]
        public void FindMaxElement_ArrayWith1000Elements_MaxElement()
        {
            int[] array = RandomArrayGenerating.GenerateArray(1000);
            int actual = ArrayExtension.FindMaxElement(array);

            int expected = array.Max();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMaxElement_ArrayWith1000000Elements_MaxElement()
        {
            int[] array = RandomArrayGenerating.GenerateArray(1000000);

            int actual = ArrayExtension.FindMaxElement(array);

            int expected = array.Max();

            Assert.AreEqual(expected, actual);
        }

        #endregion
        #region Tests for NET.S.2019.Sokolova.02 - task 3

        [TestCase(new double[] { -0.02, 3.42, 0.26, 0.98, 3.06, 0.6 }, ExpectedResult = 3)]
        [TestCase(new double[] { 0.462, 0.334, 0.67, 0.1, 0.098, -0.002, 0.6 }, ExpectedResult = 2)]
        [TestCase(new double[] { 1.0001, 1.0002, -3.0003, 1, 0.0003, 8.9, -0.0003, 0.901 }, ExpectedResult = null)]
        [TestCase(new double[] { 0.0001, 1.0002, -0.0003, 1, 0.0003, 1, -0.0003 }, ExpectedResult = 3)]
        [TestCase(new double[] { 0.657, 9.23, 1.0, 8.333, 0, -10.2, 0.4 }, ExpectedResult = null)]
        public int? FindIndexTests(double[] array)
            => ArrayExtension.FindIndex(array);

        [Test]
        public void FindIndex_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.FindIndex(new double[] { }));
        }

        [Test]
        public void FindIndex_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindIndex(null));
        }

        #endregion
        #region Tests for NET.S.2019.Sokolova.02 - task 4
        [TestCase(new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, ExpectedResult = new int[] { 7, 7, 70, 17 })]
        [TestCase(new int[] { -678, 7, 3, 9, 1, 9, -56 }, 0, ExpectedResult = new int[] { })]
        [TestCase(new int[] { 3, 315, 9, 0, 45, 0, 32, -98, -535 }, 3, ExpectedResult = new int[] { 3, 315, 32, -535 })]
        [TestCase(new int[] { 14, 64, 98, 0, -3, 87, 43, 64, 99, 52, 87 }, 4, ExpectedResult = new int[] { 14, 64, 43, 64 })]
        [TestCase(new int[] { 6, 76, 87, 09, -546, 6, 76, 0, 0, 3 }, 1, ExpectedResult = new int[] { })]
        public int[] FilterArrayByKeyTests(int[] array, int key)
            => ArrayExtension.FilterArrayByKey(array, key);

        [Test]
        public void FilterArrayByKey_EmptyArray_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.FilterArrayByKey(new int[] { }, 8));
        }

        [Test]
        public void FilterArrayByKey_ArrayIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayExtension.FindIndex(null));
        }

        [Test]
        public void FilterArrayByKey_KeyNotADigit_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => ArrayExtension.FilterArrayByKey(new int[] { 4, 7, 1, }, 10));
        }

        [Test]
        public void FilterArrayByKey_ArrayWith1000Elements_()
        {
            int[] array = RandomArrayGenerating.GenerateArray(1000);
            int key = 0;

            int[] actual = ArrayExtension.FilterArrayByKey(array, 0);
            
            List<int> expected = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                string t = array[i].ToString();
                if (t.Contains(key.ToString()))
                {
                    expected.Add(Convert.ToInt32(t));
                }
            }

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterArrayByKey_ArrayWith1000000Elements_()
        {
            int[] array = RandomArrayGenerating.GenerateArray(1000000);
            int key = 3;

            int[] actual = ArrayExtension.FilterArrayByKey(array, 3);

            List<int> expected = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                string t = array[i].ToString();
                if (t.Contains(key.ToString()))
                {
                    expected.Add(Convert.ToInt32(t));
                }
            }

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
