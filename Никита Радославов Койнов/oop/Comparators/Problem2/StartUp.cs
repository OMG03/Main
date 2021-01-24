﻿using System;
using System.Collections.Generic;

namespace Problem2
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book("Animal Farm", 2003, null),
                new Book("The Documents in the Case", 2002, null),
                new Book("The Documents in the Case", 1930, null)
            };

            books.Sort(new BookComparator());
            books.ForEach(Console.WriteLine);
        }
    }
}
