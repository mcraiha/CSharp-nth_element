# CSharp-nth_element
CSharp (C#) versions of std::nth_element (or almost)

## Introduction to this project
Since C# doesn't have build-in replacement for std::nth_element, I created few versions from existing implementations. **WARNING** All error handling code has been stripped away, so YMMV

## Introduction to std::nth_element
[std::nth_element](http://www.cplusplus.com/reference/algorithm/nth_element/) does two things if you use it to **array** with index **K**:

1. item in index K is same as it would be if array was sorted
2. Items before index K are <= or >= and items after K are >= or <= based on your sorting method

e.g. we have input array of ints (5 4 8 9 1 6 3 2 7) and we want to find out the 4th smallest number from that array. With std::nth_element using 4 as K, the output array would be (2 1 3 **4** 9 6 8 5 7). Fourth element is 4, and elements before it are smaller than 4, elements after it are larger than 4. 

Since there are multiple ways to implement std::nth_element, the outputs can vary. e.g. for our earlier example (5 4 8 9 1 6 3 2 7) with K as 4, another valid output would be (1 2 3 **4** 9 7 8 5 6). Output can also be fully sorted (1 2 3 **4** 5 6 7 8 9), but that is **NEVER** guaranteed for non trival sized arrays.

There two main uses for std::nth_element:
* Find nth largest/smallest item from array (useful if you need e.g. find the median value from array)
* Give helping hand to sorting algorithms by splitting their work

## Differences between C++ and C# versions
C++ version uses iterators. C# versions presented in here use zero based indexes (e.g. [0] means first item in array).

## Implementations
First version comes from **Adam Horvath**. His [blog](http://blog.teamleadnet.com/2012/07/quick-select-algorithm-find-kth-element.html) has an Java example which uses Quick select algorithm.

Second one follows the [C source code](http://sourcecodebrowser.com/cdo/1.4.0.1~dfsg/nth__element_8c_source.html) given in CDO project.

## Examples
You have following C++ line of code
```
std::nth_element (myvector.begin(), myvector.begin()+4, myvector.end());
```
you would replace it with
```
nth_element(myArray, 0, 4, myArray.Length - 1);
```

If you want to use custom comparer (like descending order), follow this example
```
nth_element(arr, 0, 10, arr.Length - 1, (i1, i2) => i2.CompareTo(i1));
```

## Licenses
This text file (**README.md**) is licensed under Creative Commons Zero (CC0 1.0 Universal), see [LICENSE](https://github.com/mcraiha/CSharp-nth_element/blob/master/LICENSE) file

**nthelement-GPLv2.cs** is licensed under GPLv2, see [COPYING](https://github.com/mcraiha/CSharp-nth_element/blob/master/COPYING) file
