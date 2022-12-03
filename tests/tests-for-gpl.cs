namespace tests;
using NthElementGPLv2;
using System.Linq;

public class TestsGPLv2
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

	[Test]
	public void CheckAllListTest()
	{
		// Arrange
		List<int> numberList = new List<int>() { -3, -12, -8, -19, 17, 1, 11, -9, -20, 12 }; // Sorted order -20 -19 -12 -9 -8 -3 1 11 12 17
		List<int> copyList1 = new List<int>(numberList);
		List<int> copyList2 = new List<int>(numberList);
		List<int> copyList3 = new List<int>(numberList);
		List<int> copyList4 = new List<int>(numberList);
		List<int> copyList5 = new List<int>(numberList);
		List<int> copyList6 = new List<int>(numberList);
		List<int> copyList7 = new List<int>(numberList);
		List<int> copyList8 = new List<int>(numberList);
		List<int> copyList9 = new List<int>(numberList);

		// Act
		PartialSort.nth_element(indexable: copyList1, startIndex: 0, nthSmallest: 1, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList2, startIndex: 0, nthSmallest: 2, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList3, startIndex: 0, nthSmallest: 3, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList4, startIndex: 0, nthSmallest: 4, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList5, startIndex: 0, nthSmallest: 5, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList6, startIndex: 0, nthSmallest: 6, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList7, startIndex: 0, nthSmallest: 7, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList8, startIndex: 0, nthSmallest: 8, endIndex: numberList.Count - 1);
		PartialSort.nth_element(indexable: copyList9, startIndex: 0, nthSmallest: 9, endIndex: numberList.Count - 1);

		// Assert
		Assert.AreEqual(-20, copyList1[0], "First item should be the smallest");
		CollectionAssert.AreEqual(new List<int>() { -20, -19 }, copyList2.Take(2), "Second item should be the second smallest");// .DoesNotContain(copyList1.Take(1))
		Assert.True(copyList3.Take(3).ToList().TrueForAll(i => i < copyList3[3]));
		Assert.True(copyList4.Take(4).ToList().TrueForAll(i => i < copyList4[4]));
		Assert.True(copyList5.Take(5).ToList().TrueForAll(i => i < copyList5[5]));
		Assert.True(copyList6.Take(6).ToList().TrueForAll(i => i < copyList6[6]));
		Assert.True(copyList7.Take(7).ToList().TrueForAll(i => i < copyList7[7]));
		Assert.True(copyList8.Take(8).ToList().TrueForAll(i => i < copyList8[8]));
		Assert.AreEqual(17, copyList9[9], "Last item should be the largest");
	}

	
}