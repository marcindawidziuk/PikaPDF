using System;
using JetBrains.Annotations;
using PikaPDF.DocumentObjectModel;
using PikaPDF.DocumentObjectModel.Tables;

namespace PikaPDF.Extensions
{
    [PublicAPI]
    public static class RowExtensions
    {
        public static Cell CellAt(this Row row, int columnIndex)
        {
            return row.Cells[columnIndex];
        }
        
        public static Cell CellAt(this Row row, Column column)
        {
            if (row.Table != column.Table)
                throw new InvalidOperationException("Row and column are not part of the same table");
            
            return row.Cells[column.Index];
        }
        
        public static Row WithHeight(this Row row, Unit height)
        {
            row.Height = height;
            return row;
        }
        
        public static Row WithFormat(this Row row, Action<ParagraphFormat> action)
        {
            action(row.Format);
            return row;
        }
    }
}