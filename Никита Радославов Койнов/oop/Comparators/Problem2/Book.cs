using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Problem2
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, IReadOnlyList<string> authors)
        {
            Title = title;
            Year = year;
            Authors = authors;
        }

        public string Title { get; private set; }
        public int Year { get; private set; }
        public IReadOnlyList<string> Authors { get; private set; }

        public int CompareTo(Book other)
        {
            int comparedByYear = this.Year - other.Year;
            if (comparedByYear != 0)
            {
                return comparedByYear;
            }

            return this.Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
