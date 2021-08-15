using System;
using JetBrains.Annotations;
using PikaPDF.DocumentObjectModel;
using PikaPDF.DocumentObjectModel.Tables;

namespace PikaPDF.Extensions
{
    [PublicAPI]
    public static class TableExtensions
    {
        public static Cell CellAt(this Table shape, int row, int column)
        {
            return shape[row, column];
        }
        
        public static Cell CellAt(this Table shape, Row row, Column column)
        {
            return shape[row.Index, column.Index];
        }
        
        public static Row RowAt(this Table shape, int row)
        {
            return shape.Rows[row];
        }
        
        public static Column WithWidth(this Column column, Unit width)
        {
            column.Width = width;
            return column;
        }

        public static Border Hide(this Border border)
        {
            border.Visible = false;
            return border;
        }
        
        public static Border Show(this Border border)
        {
            border.Visible = true;
            return border;
        }
        
        public static T WithBorders<T>(this T column, Action<Border> action) where T : IHasBorders
        {
            action(column.Borders.Left);
            action(column.Borders.Right);
            action(column.Borders.Top);
            action(column.Borders.Bottom);
            return column;
        }

        public static T WithBottomBorder<T>(this T column, Action<Border> action) where T : IHasBorders
        {
            action(column.Borders.Bottom);
            return column;
        }
        
    }
}