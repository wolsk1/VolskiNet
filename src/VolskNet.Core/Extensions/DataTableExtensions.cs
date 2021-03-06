﻿using System.Collections.Generic;
using System.Data;

namespace VolskSoft.Bibliotheca
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// Converts datatable to IList of type T
        /// </summary>
        /// <typeparam name="T">Type of List</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>IList of type T</returns>
        public static IEnumerable<T> ConvertTo<T>(this DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            IList<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return rows.ConvertTo<T>();
        }
    }
}