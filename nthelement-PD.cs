/*
  This file implements derivate version of nth_element function in C#. Original Java source code is made by 
  Adam Horvath and you can find it from
  http://blog.teamleadnet.com/2012/07/quick-select-algorithm-find-kth-element.html
  
  This is free and unencumbered software released into the public domain.
*/
using System;
using System.Collections.Generic;

namespace NthElementPD
{
	public static class PartialSort
	{
		// Nth_element made with Quick select algorithm. Custom comparer. nthToSeek is zero base index
		public static void nth_element<T>(IList<T> indexable, int startIndex, int nthToSeek, int endIndex, Comparison<T> comparison)
		{
			int from = startIndex; 
			int to = endIndex;
			
			// if from == to we reached the kth element
			while (from < to) 
			{
				int r = from, w = to;
				T mid = indexable[(r + w) / 2];
				
				// stop if the reader and writer meets
				while (r < w) 
				{
					if (comparison(indexable[r], mid) > -1) 
					{ // put the large values at the end
						T tmp = indexable[w];
						indexable[w] = indexable[r];
						indexable[r] = tmp;
						w--;
					} 
					else 
					{ // the value is smaller than the pivot, skip
						r++;
					}
				}
				
				// if we stepped up (r++) we need to step one down
				if (comparison(indexable[r], mid) > 0)
				{
					r--;
				}
				
				// the r pointer is on the end of the first k elements
				if (nthToSeek <= r) 
				{
					to = r;
				} 
				else 
				{
					from = r + 1;
				}
			}
			
			return;
		}


		// Nth_element made with Quick select algorithm. Default comparer. nthSmallest is zero base index
		public static void nth_element<T>(IList<T> indexable, int startIndex, int nthSmallest, int endIndex) 
		{
			int from = startIndex; 
			int to = endIndex;
			
			// if from == to we reached the kth element
			while (from < to) 
			{
				int r = from, w = to;
				T mid = indexable[(r + w) / 2];
				
				// stop if the reader and writer meets
				while (r < w) 
				{
					if (System.Collections.Generic.Comparer<T>.Default.Compare(indexable[r], mid) > -1) 
					{ // put the large values at the end
						T tmp = indexable[w];
						indexable[w] = indexable[r];
						indexable[r] = tmp;
						w--;
					} 
					else 
					{ // the value is smaller than the pivot, skip
						r++;
					}
				}
				
				// if we stepped up (r++) we need to step one down
				if (System.Collections.Generic.Comparer<T>.Default.Compare(indexable[r], mid) > 0)
				{
					r--;
				}
				
				// the r pointer is on the end of the first k elements
				if (nthSmallest <= r) 
				{
					to = r;
				} 
				else 
				{
					from = r + 1;
				}
			}
			
			return;
		}
	}
}