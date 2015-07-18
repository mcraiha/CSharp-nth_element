/*
  This file implements derivate version of nth_element function in C#. Original C implementation (nth_element.c) is from CDO. 
  CDO is a collection of Operators to manipulate and analyse Climate model Data.

  Copyright (C) 2015 Kaarlo Räihä
  Copyright (C) 2006 Brockmann Consult
  See COPYING file for copying and redistribution conditions.

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; version 2 of the License.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.
*/

// Default comparer. nthSmallest is zero base index
public static void nth_element<T>(T[] array, int startIndex, int nthSmallest, int endIndex)
{
	int i, j;
	int k = startIndex;
	int l = endIndex;
	int m;
	T a;

	for ( ; ; )
	{
		if ( l <= k + 1 )
		{
			if ( l == k + 1 && System.Collections.Generic.Comparer<T>.Default.Compare(array[l], array[k]) < 0 )
			{
				Swap(array, k, l);
			}

			return;
		} 
		else 
		{
			m = (k + l) >> 1; 
			Swap(array, m, k + 1);

			if (System.Collections.Generic.Comparer<T>.Default.Compare(array[k], array[l]) > 0)
			{
				Swap(array, k, l);
			}
					
			if (System.Collections.Generic.Comparer<T>.Default.Compare(array[k + 1], array[l]) > 0)
			{
				Swap(array, k + 1, l);
			}
							
			if (System.Collections.Generic.Comparer<T>.Default.Compare(array[k], array[k + 1]) > 0)
			{
				Swap(array, k, k + 1);
			}
									
			i = k + 1; 
			j = l;
			a = array[k + 1]; 
			
			for ( ; ; ) 
			{
				do i++; while ( System.Collections.Generic.Comparer<T>.Default.Compare(array[i], a) < 0 ); 
				do j--; while ( System.Collections.Generic.Comparer<T>.Default.Compare(array[j], a) > 0 ); 
				if ( j < i ) break;
				Swap(array, i, j);
			} 
			
			array[k+1] = array[j]; 
			array[j] = a;
			if (j >= nthSmallest) l = j - 1; 
			if (j <= nthSmallest) k = i; 
		}
	}
}


// Custom comparer. nthToSeek is zero base index
public static void nth_element<T>(T[] array, int startIndex, int nthToSeek, int endIndex, Comparison<T> comparison)
{
	int i, j;
	int k = startIndex;
	int l = endIndex;
	int m;
	T a;
	
	for ( ; ; )
	{
		if ( l <= k + 1 )
		{
			if ( l == k + 1 && comparison(array[l], array[k]) < 0 )
			{
				Swap(array, k, l);
			}
			
			return;
		} 
		else 
		{
			m = (k + l) >> 1; 
			Swap(array, m, k + 1);
			
			if (comparison(array[k], array[l]) > 0)
			{
				Swap(array, k, l);
			}
			
			if (comparison(array[k + 1], array[l]) > 0)
			{
				Swap(array, k + 1, l);
			}
			
			if (comparison(array[k], array[k + 1]) > 0)
			{
				Swap(array, k, k + 1);
			}
			
			i = k + 1; 
			j = l;
			a = array[k + 1]; 
			
			for ( ; ; ) 
			{
				do i++; while ( comparison(array[i], a) < 0 ); 
				do j--; while ( comparison(array[j], a) > 0 ); 
				if ( j < i ) break;
				Swap(array, i, j);
			} 
			
			array[k+1] = array[j]; 
			array[j] = a;
			if (j >= nthToSeek) l = j - 1; 
			if (j <= nthToSeek) k = i; 
		}
	}
}

private static void Swap<T>(T[] arr, int index1, int index2)
{
	T temp = arr[index1];
	arr[index1] = arr[index2];
	arr [index2] = temp;
}
