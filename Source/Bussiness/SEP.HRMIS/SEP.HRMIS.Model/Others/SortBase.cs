using System;
using System.Collections.Generic;

namespace SEP.HRMIS.Model
{
    public class SortBase
    {
        public static void InsertionSort<T>(IList<T> list, Comparison<T> comparison)
        {
            int count = list.Count;
            for (int j = 1; j < count; j++)
            {
                T key = list[j];

                int i = j - 1;
                for (; i >= 0 && comparison(list[i], key) > 0; i--)
                {
                    list[i + 1] = list[i];
                }
                list[i + 1] = key;
            }
        }
    }
    public enum SortOrderEnum
    {
        Ascending, Descending, Unspecified
    }

}
