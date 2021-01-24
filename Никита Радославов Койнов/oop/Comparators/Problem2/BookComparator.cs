using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Problem2
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x is null || y is null)
            {
                return -1;
            }

            int orederedByTitle = x.Title.CompareTo(y.Title);

            if (orederedByTitle != 0)
            {
                return orederedByTitle;
            }

            return y.Year - x.Year;
        }
    }
}
