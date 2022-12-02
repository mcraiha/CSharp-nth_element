namespace tests;
using NthElementPD;

public class TestsPD
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void SimpleArrayTest()
	{
		// Arrange
		int[] numberArray = new int[] { 12, 20, 16, -5, 8, 15, 19, -13, 11 }; // Sorted order -13 -5 8 11 12 15 16 19 20
		int[] copyArray = (int[])numberArray.Clone();

		// Act
		PartialSort.nth_element(indexable: numberArray, startIndex: 0, nthSmallest: 4, endIndex: numberArray.Length - 1);

		// Assert
		Assert.AreEqual(11, numberArray[3]);
		CollectionAssert.AreNotEqual(numberArray, copyArray);
	}

	[Test]
	public void SimpleListTest()
	{
		// Arrange
		List<int> numberList = new List<int>() { 11, 21, 17, -6, 9, 14, 18, -14, 12 }; // Sorted order -14 -6 9 11 12 14 17 18 21
		List<int> copyList = new List<int>(numberList);

		// Act
		PartialSort.nth_element(indexable: numberList, startIndex: 0, nthSmallest: 4, endIndex: numberList.Count - 1);

		// Assert
		Assert.AreEqual(11, numberList[3]);
		CollectionAssert.AreNotEqual(numberList, copyList);
	}
}