﻿#region MigraDoc - Creating Documents on the Fly
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

using PikaPDF.DocumentObjectModel.DocumentObjectModel.Internals;

namespace PikaPDF.DocumentObjectModel.DocumentObjectModel
{
    /// <summary>
    /// Represents the collection of embedded files.
    /// </summary>
    public class EmbeddedFiles : DocumentObjectCollection
    {
        /// <summary>
        /// Initializes a new instance of the EmbeddedFiles class.
        /// </summary>
        public EmbeddedFiles()
        { }

        /// <summary>
        /// Gets an embedded file by its index. First embedded file has index 0.
        /// </summary>
        public new EmbeddedFile this[int index] => base[index] as EmbeddedFile;

        #region Methods

        /// <summary>
        /// Adds a new EmbeddedFile.
        /// </summary>
        /// <param name="name">The name used to refer and to entitle the embedded file.</param>
        /// <param name="path">The path of the file to embed.</param>
        public EmbeddedFile Add(string name, string path)
        {
            var section = new EmbeddedFile(name, path);
            Add(section);
            return section;
        }
        #endregion

        #region Internal
        /// <summary>
        /// Converts Sections into DDL.
        /// </summary>
        internal override void Serialize(Serializer serializer)
        {
            var count = Count;
            for (var index = 0; index < count; ++index)
            {
                var embeddedFile = this[index];
                embeddedFile.Serialize(serializer);
            }
        }

        /// <summary>
        /// Returns the meta object of this instance.
        /// </summary>
        internal override Meta Meta => _meta ?? (_meta = new Meta(typeof(EmbeddedFiles)));

        static Meta _meta;
        #endregion
    }
}
