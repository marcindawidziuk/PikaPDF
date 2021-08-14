using System;
using PikaPDF.DocumentObjectModel;
using PikaPDF.DocumentObjectModel.Enums;
using PikaPDF.DocumentObjectModel.Shapes;
using PikaPDF.DocumentObjectModel.Shapes.Enums;
using PikaPDF.DocumentObjectModel.Tables;
using PikaPDF.DocumentObjectModel.Tables.Enums;

namespace PikaPDF.Fluent
{
    public static class TableExtensions
    {
        public static Cell CellAt(this Table shape, int row, int column)
        {
            return shape[row, column];
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

    public static class ParagraphExtensions
    {
        public static T WithFormat<T>(this T paragraph, Action<ParagraphFormat> action) where T : IHasParagraphFormat
        {
            action(paragraph.Format);
            return paragraph;
        }
        
        public static T WithFontSize<T>(this T paragraph, Unit size) where T : IHasParagraphFormat
        {
            paragraph.Format.Font.Size = size;
            return paragraph;
        }
        
        public static T WithFontBold<T>(this T paragraph) where T : IHasParagraphFormat
        {
            paragraph.Format.Font.Bold = true;
            return paragraph;
        }
        
        public static T WithFontColour<T>(this T paragraph, Color color) where T : IHasParagraphFormat
        {
            paragraph.Format.Font.Color = color;
            return paragraph;
        }
        
        public static T WithParagraphAligment<T>(this T paragraph, ParagraphAlignment paragraphAlignment) where T : IHasParagraphFormat
        {
            paragraph.Format.Alignment = paragraphAlignment;
            return paragraph;
        }
    }

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
        
        public static Row WithVerticalAligment(this Row row, VerticalAlignment verticalAlignment)
        {
            row.VerticalAlignment = verticalAlignment;
            return row;
        }
        
        public static Row WithFormat(this Row row, Action<ParagraphFormat> action)
        {
            action(row.Format);
            return row;
        }
    }
    
    public static class ShapeExtensions
    {
        public static T WithWrapFormat<T>(this T shape, WrapFormat wrapFormat) where T : Shape
        {
            shape.WrapFormat = wrapFormat;
            return shape;
        }
        
        public static T WithRelativeVertical<T>(this T shape, RelativeVertical relativeVertical) where T : Shape
        {
            shape.RelativeVertical = relativeVertical;
            return shape;
        }
        
        public static T WithLockedAspectRatio<T>(this T shape) where T : Image
        {
            shape.LockAspectRatio = true;
            return shape;
        }

        //     /// <summary>
        //     /// Gets or sets the reference point of the Top property.
        //     /// </summary>
        //     public RelativeVertical RelativeVertical
        //     {
        //         get { return (RelativeVertical)_relativeVertical.Value; }
        //         set { _relativeVertical.Value = (int)value; }
        //     }
        //     [DV(Type = typeof(RelativeVertical))]
        //     internal NEnum _relativeVertical = NEnum.NullValue(typeof(RelativeVertical));
        //
        //     /// <summary>
        //     /// Gets or sets the reference point of the Left property.
        //     /// </summary>
        //     public RelativeHorizontal RelativeHorizontal
        //     {
        //         get { return (RelativeHorizontal)_relativeHorizontal.Value; }
        //         set { _relativeHorizontal.Value = (int)value; }
        //     }
        //     [DV(Type = typeof(RelativeHorizontal))]
        //     internal NEnum _relativeHorizontal = NEnum.NullValue(typeof(RelativeHorizontal));
        //
        //     /// <summary>
        //     /// Gets or sets the position of the top side of the shape.
        //     /// </summary>
        //     public TopPosition Top
        //     {
        //         get { return _top; }
        //         set { _top = value; }
        //     }
        //     [DV]
        //     internal TopPosition _top = TopPosition.NullValue;
        //
        //     /// <summary>
        //     /// Gets or sets the position of the left side of the shape.
        //     /// </summary>
        //     public LeftPosition Left
        //     {
        //         get { return _left; }
        //         set { _left = value; }
        //     }
        //     [DV]
        //     internal LeftPosition _left = LeftPosition.NullValue;
        //
        //     /// <summary>
        //     /// Gets the line format of the shape's border.
        //     /// </summary>
        //     public LineFormat LineFormat
        //     {
        //         get { return _lineFormat ?? (_lineFormat = new LineFormat(this)); }
        //         set
        //         {
        //             SetParent(value);
        //             _lineFormat = value;
        //         }
        //     }
        //     [DV]
        //     internal LineFormat _lineFormat;
        //
        //     /// <summary>
        //     /// Gets the background filling format of the shape.
        //     /// </summary>
        //     public FillFormat FillFormat
        //     {
        //         get { return _fillFormat ?? (_fillFormat = new FillFormat(this)); }
        //         set
        //         {
        //             SetParent(value);
        //             _fillFormat = value;
        //         }
        //     }
        //     [DV]
        //     internal FillFormat _fillFormat;
        //
        //     /// <summary>
        //     /// Gets or sets the height of the shape.
        //     /// </summary>
        //     public Unit Height
        //     {
        //         get { return _height; }
        //         set { _height = value; }
        //     }
        //     [DV]
        //     internal Unit _height = Unit.NullValue;
        //
        //     /// <summary>
        //     /// Gets or sets the width of the shape.
        //     /// </summary>
        //     public Unit Width
        //     {
        //         get { return _width; }
        //         set { _width = value; }
        //     }
        // }
    }

}