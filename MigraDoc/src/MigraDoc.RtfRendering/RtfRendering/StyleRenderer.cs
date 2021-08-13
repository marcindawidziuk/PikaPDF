#region MigraDoc - Creating Documents on the Fly
//
// Authors:
//   Klaus Potzesny
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

using MigraDoc.DocumentObjectModel;

namespace MigraDoc.RtfRendering
{
    /// <summary>
    /// Class to render a Style to RTF.
    /// </summary>
    internal class StyleRenderer : RendererBase
    {
        internal StyleRenderer(DocumentObject domObj, RtfDocumentRenderer docRenderer)
            : base(domObj, docRenderer)
        {
            _style = domObj as Style;
            _styles = DocumentRelations.GetParent(_style) as Styles;
        }

        internal override void Render()
        {
            _rtfWriter.StartContent();
            int currIdx = _styles.GetIndex(_style.Name);
            RendererBase rndrr = null;
            if (_style.Type == StyleType.Character)
            {
                _rtfWriter.WriteControlWithStar("cs", currIdx);
                _rtfWriter.WriteControl("additive");
                rndrr = RendererFactory.CreateRenderer(_style.Font, _docRenderer);
            }
            else
            {
                _rtfWriter.WriteControl("s", currIdx);
                rndrr = RendererFactory.CreateRenderer(_style.ParagraphFormat, _docRenderer);
            }
            if (_style.BaseStyle != "")
            {
                int bsIdx = _styles.GetIndex(_style.BaseStyle);
                _rtfWriter.WriteControl("sbasedon", bsIdx);
            }
            rndrr.Render();
            _rtfWriter.WriteText(_style.Name);
            _rtfWriter.WriteSeparator();
            _rtfWriter.EndContent();
        }
        private readonly Style _style;
        private readonly Styles _styles;
    }
}