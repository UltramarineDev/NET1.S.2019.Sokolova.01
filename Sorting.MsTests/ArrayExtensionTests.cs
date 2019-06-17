using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting.MsTests
{
    /// <summary>
    /// MsTests for ArrayExtension class
    /// </summary>
    [TestClass]
    public class ArrayExtensionTests
    {
        #region Tests for Sorting methods
        /// <summary>
        /// Method tests MergeSort Method for Ordinary Array
        /// </summary>
        [TestMethod]
        public void MergeSortMethod_OrdinaryArray_SortAscending()
        {
            // Arrange
            int[] array = RandomArrayGenerating.GenerateArray(100);

            // Act
            int[] actual = ArrayExtension.MergeSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests MergeSort Method for Ordinary Array With Negative Integers
        /// </summary>
        [TestMethod]
        public void MergeSortMethod_OrdinaryArrayWithNegativeInt_SortAscending()
        {
            // Arrange
            int[] array = new int[] { -18, 0, int.MaxValue, int.MinValue, 6, -1000 };

            // Act
            int[] actual = ArrayExtension.MergeSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests QuickSort Method for Ordinary Array With Negative Integers
        /// </summary>
        [TestMethod]
        public void QuickSortMethod_OrdinaryArrayWithNegativeInt_SortAscending()
        {
            // Arrange
            int[] array = new int[] { -18, 0, int.MaxValue, int.MinValue, 6, -1000 };

            // Act
            int[] actual = ArrayExtension.QuickSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests QuickSort Method for Ordinary Array
        /// </summary>
        [TestMethod]
        public void QuickSortMethod_OrdinaryArray_SortAscending()
        {
            // Arrange
            int[] array = RandomArrayGenerating.GenerateArray(100);

            // Act
            int[] actual = ArrayExtension.QuickSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests MergeSort Method for Large Array
        /// </summary>
        [TestMethod]
        public void MergeSortMethod_LargeArray_SortAscending()
        {
            // Arrange
            int[] array = RandomArrayGenerating.GenerateArray(1000);

            // Act
            int[] actual = ArrayExtension.MergeSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests QuickSort Method for Large Array 
        /// </summary>
        [TestMethod]
        public void QuickSortMethod_LargeArray_SortAscending()
        {
            // Arrange
            int[] array = RandomArrayGenerating.GenerateArray(1000);

            // Act
            int[] actual = ArrayExtension.QuickSort(array);
            bool result = SortedArrayChecker.CheckSortedArray(array);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Method tests MergeSort Method for Empty Array
        /// </summary> 
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeSortMethod_EmptyArray_ThrowArgumentException()
        {
            ArrayExtension.MergeSort(new int[] { });
        }

        /// <summary>
        /// Method tests QuickSort Method for Empty Array
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSortMethod_EmptyArray_ThrowArgumentException()
        {
            ArrayExtension.QuickSort(new int[] { });
        }
        #endregion
        #region NET.S.2019.Sokolova.02 - task 4
        [TestMethod]
        public void FilterArrayByKeyMethod_OrdinaryArrayKey7_FilteredArray()
        {
            int[] array = new int[] { 7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int key = 7;
            int[] expected = new int[] { 7, 7, 70, 17 };

            int[] actual = ArrayExtension.FilterArrayByKey(array, key);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestMethod]
        public void FilterArrayByKeyMethod_OrdinaryArrayKey3_FilteredArray()
        {
            int[] array = new int[] { 3, 315, 9, 0, 45, 0, 32, -98, -535 };
            int key = 3;
            int[] expected = new int[] { 3, 315, 32, -535 };

            int[] actual = ArrayExtension.FilterArrayByKey(array, key);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestMethod]
        public void FilterArrayByKeyMethod_OrdinaryArrayKey4_FilteredArray()
        {
            int[] array = new int[] { 14, 64, 98, 0, -3, 87, 43, 64, 99, 52, 87 };
            int key = 4;
            int[] expected = new int[] { 14, 64, 43, 64 };

            int[] actual = ArrayExtension.FilterArrayByKey(array, key);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestMethod]
        public void FilterArrayByKeyMethod_ArrayWithoutKeyValue_EmptyArray()
        {
            int[] array = new int[] { -678, 7, 3, 9, 1, 9, -56 };
            int key = 0;
            int[] expected = new int[] { };

            int[] actual = ArrayExtension.FilterArrayByKey(array, key);

            Assert.AreEqual(string.Join(",", expected), string.Join(",", actual));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterArrayByKeyMethod_EmptyArray_ThrowArgumentException()
        {
            ArrayExtension.FilterArrayByKey(new int[] { }, 8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FilterArrayByKeyMethod_ArrayIsNull_ThrowArgumentNullException()
        {
            ArrayExtension.FilterArrayByKey(null, 8);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FilterArrayByKeyMethod_KeyNotADigit_ThrowArgumentException()
        {
            ArrayExtension.FilterArrayByKey(new int[] { 4, 2, 7, 9, 12 }, 11);
        }
        #endregion
    }
}
