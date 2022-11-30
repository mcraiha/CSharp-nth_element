namespace tests;
using NthElementGPLv2;

public class TestsGPLv2
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void SimpleTest()
	{
		// Arrange
		int[] numberArray = new int[] { 12, 20, 16, -5, 8, 15, 19, -13, 11 }; // Sorted order -13 -5 8 11 12 15 16 19 20
		int[] copyArray = (int[])numberArray.Clone();

		// Act
		PartialSort.nth_element(array: numberArray, startIndex: 0, nthSmallest: 4, endIndex: numberArray.Length - 1);

		// Assert
		Assert.AreEqual(11, numberArray[3]);
		CollectionAssert.AreNotEqual(numberArray, copyArray);
	}
}