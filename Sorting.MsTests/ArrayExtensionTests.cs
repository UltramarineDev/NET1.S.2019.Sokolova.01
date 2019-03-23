namespace Sorting.MsTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// MsTests for ArrayExtension class
    /// </summary>
    [TestClass]
    public class ArrayExtensionTests
    {
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
    }
}
