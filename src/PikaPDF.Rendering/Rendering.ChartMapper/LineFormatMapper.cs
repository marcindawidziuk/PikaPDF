#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   David Stephensen
//
// Copyright (c) 2001-2019 empira Software GmbH, Cologne Area (Germany)
//
// http://www.pdfsharp.com
// http://www.migradoc.com
// http://sourceforge.net/projects/pdfsharp
//
// Permission is hereby granted, free of charge, to any person obtaining a
// copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included
// in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using PikaPDF.Charting.Charting;
using PikaPDF.Core.Drawing;
using PikaPDF.Core.Drawing.enums;
using PikaPDF.DocumentObjectModel.DocumentObjectModel.Shapes.enums;

namespace PikaPDF.Rendering.Rendering.ChartMapper
{
    /// <summary>
    /// The LineFormatMapper class.
    /// </summary>
    public class LineFormatMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineFormatMapper"/> class.
        /// </summary>
        public LineFormatMapper()
        { }

        void MapObject(LineFormat lineFormat, DocumentObjectModel.DocumentObjectModel.Shapes.LineFormat domLineFormat)
        {
            if (domLineFormat.Color.IsEmpty)
                lineFormat.Color = XColor.Empty;
            else
            {
#if noCMYK
                lineFormat.Color = XColor.FromArgb(domLineFormat.Color.Argb);
#else
                lineFormat.Color = ColorHelper.ToXColor(domLineFormat.Color, domLineFormat.Document.UseCmykColor);
#endif
            }
            switch (domLineFormat.DashStyle)
            {
                case DashStyle.Dash:
                    lineFormat.DashStyle = XDashStyle.Dash;
                    break;
                case DashStyle.DashDot:
                    lineFormat.DashStyle = XDashStyle.DashDot;
                    break;
                case DashStyle.DashDotDot:
                    lineFormat.DashStyle = XDashStyle.DashDotDot;
                    break;
                case DashStyle.Solid:
                    lineFormat.DashStyle = XDashStyle.Solid;
                    break;
                case DashStyle.SquareDot:
                    lineFormat.DashStyle = XDashStyle.Dot;
                    break;
                default:
                    lineFormat.DashStyle = XDashStyle.Solid;
                    break;
            }
            switch (domLineFormat.Style)
            {
                case LineStyle.Single:
                    lineFormat.Style = Charting.Charting.enums.LineStyle.Single;
                    break;
            }
            lineFormat.Visible = domLineFormat.Visible;
            if (domLineFormat.IsNull("Visible"))
                lineFormat.Visible = true;
            lineFormat.Width = domLineFormat.Width.Point;
        }

        internal static void Map(LineFormat lineFormat, DocumentObjectModel.DocumentObjectModel.Shapes.LineFormat domLineFormat)
        {
            LineFormatMapper mapper = new LineFormatMapper();
            mapper.MapObject(lineFormat, domLineFormat);
        }
    }
}
