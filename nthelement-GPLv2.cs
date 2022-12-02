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

using System;
using System.Collections.Generic;

namespace NthElementGPLv2
{
	public static class PartialSort
	{
		// Default comparer. nthSmallest is zero base index
		public static void nth_element<T>(IList<T> indexable, int startIndex, int nthSmallest, int endIndex)
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
					if ( l == k + 1 && Comparer<T>.Default.Compare(indexable[l], indexable[k]) < 0 )
					{
						Swap(indexable, k, l);
					}

					return;
				} 
				else 
				{
					m = (k + l) >> 1; 
					Swap(indexable, m, k + 1);

					if (Comparer<T>.Default.Compare(indexable[k], indexable[l]) > 0)
					{
						Swap(indexable, k, l);
					}
							
					if (Comparer<T>.Default.Compare(indexable[k + 1], indexable[l]) > 0)
					{
						Swap(indexable, k + 1, l);
					}
									
					if (Comparer<T>.Default.Compare(indexable[k], indexable[k + 1]) > 0)
					{
						Swap(indexable, k, k + 1);
					}
											
					i = k + 1; 
					j = l;
					a = indexable[k + 1]; 
					
					for ( ; ; ) 
					{
						do i++; while ( Comparer<T>.Default.Compare(indexable[i], a) < 0 ); 
						do j--; while ( Comparer<T>.Default.Compare(indexable[j], a) > 0 ); 
						if ( j < i ) break;
						Swap(indexable, i, j);
					} 
					
					indexable[k+1] = indexable[j]; 
					indexable[j] = a;
					if (j >= nthSmallest) l = j - 1; 
					if (j <= nthSmallest) k = i; 
				}
			}
		}


		// Custom comparer. nthToSeek is zero base index
		public static void nth_element<T>(IList<T> indexable, int startIndex, int nthToSeek, int endIndex, Comparison<T> comparison)
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
					if ( l == k + 1 && comparison(indexable[l], indexable[k]) < 0 )
					{
						Swap(indexable, k, l);
					}
					
					return;
				} 
				else 
				{
					m = (k + l) >> 1; 
					Swap(indexable, m, k + 1);
					
					if (comparison(indexable[k], indexable[l]) > 0)
					{
						Swap(indexable, k, l);
					}
					
					if (comparison(indexable[k + 1], indexable[l]) > 0)
					{
						Swap(indexable, k + 1, l);
					}
					
					if (comparison(indexable[k], indexable[k + 1]) > 0)
					{
						Swap(indexable, k, k + 1);
					}
					
					i = k + 1; 
					j = l;
					a = indexable[k + 1]; 
					
					for ( ; ; ) 
					{
						do i++; while ( comparison(indexable[i], a) < 0 ); 
						do j--; while ( comparison(indexable[j], a) > 0 ); 
						if ( j < i ) break;
						Swap(indexable, i, j);
					} 
					
					indexable[k+1] = indexable[j]; 
					indexable[j] = a;
					if (j >= nthToSeek) l = j - 1; 
					if (j <= nthToSeek) k = i; 
				}
			}
		}

		private static void Swap<T>(IList<T> indexable, int index1, int index2)
		{
			T temp = indexable[index1];
			indexable[index1] = indexable[index2];
			indexable [index2] = temp;
		}
	}
}