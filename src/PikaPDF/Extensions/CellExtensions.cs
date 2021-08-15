using System;
using JetBrains.Annotations;
using PikaPDF.DocumentObjectModel.Tables;

namespace PikaPDF.Extensions
{
    [PublicAPI]
    public static class CellExtensions
    {
        public static void MergeRight(this Cell cell, int merge)
        {
            var mergeTo = cell.Column.Index + merge;
            var maxColumnIndex = cell.Table.Columns.Count - 1;
            if (mergeTo > maxColumnIndex)
            {
                throw new InvalidOperationException($"Trying to merge cell {cell.Row.Index}x{cell.Column.Index} to the right {merge} cells. Table has only {maxColumnIndex} columns.");
            }

            cell.MergeRight = merge;
        }
    }
}