using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace s21_d04_Model
{
    public interface ISearchable
    {
        string GetTitle();
    }

    public static class SearchExtensions
    {
        public static T[] Search<T>(this IEnumerable<T> list, string search)
            where T : ISearchable
        {
            return list.Where(item => item.GetTitle().IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                    .OrderBy(item => item is Book book ? book.Rank : 0)
                    .ToArray();
        }
    }
}