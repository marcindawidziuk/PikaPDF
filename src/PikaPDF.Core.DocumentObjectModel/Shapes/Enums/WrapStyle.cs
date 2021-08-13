#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Stefan Lange
//   Klaus Potzesny
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

namespace PikaPDF.DocumentObjectModel.Shapes.Enums
{
    /// <summary>
    /// Specifies how the shape object should be placed between the other elements.
    /// </summary>
    public enum WrapStyle
    {
        /// <summary>
        /// The object will be placed between its predecessor and its successor.
        /// </summary>
        TopBottom,

        /// <summary>
        /// The object will be ignored when the other elements are placed.
        /// </summary>
        None,

        /// <summary>
        /// The object will be ignored when the other elements are placed.
        /// </summary>
        Through,
    }
}