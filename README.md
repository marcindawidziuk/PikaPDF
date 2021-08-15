# PikaPDF

This project is mainly just a .NET 5 port of [MigraDoc](https://github.com/empira/MigraDoc). To make things more managable some of the features might be dropped.

Few key differences:
- Dropped support for WPF and GDI renderer - just want to focus on generating PDF, to display them use different library
- Added helpers to generate barcode images 
- Adding fluent-like API:
```csharp
...
var column1 = table.AddColumn()
	.WithWidth(Unit.FromCentimeters(2));
var row = table.AddRow()
	.WithHeight(Unit.FromCentimeters(1));

row.CellAt(column1)
	.AddParagraph("test")
	.WithFontSize(13)
	.WithFontBold();

// instead of

var column1 = table.AddColumn();
column1.Width = Unit.FromCentimeters(2);

var row = table.AddRow()
	.WithHeight(Unit.FromCentimeters(1));

var cell = table[row.Index, column1.Index];
var paragraph = cell.AddParagraph("test")
paragraph.Format.Font.Size = 13;
paragraph.Format.Font.Bold = true;

```

Please not that this is still very much work in progress.
I'm not planning on breaking compatibility with MigraDoc, just adding on top of it, so ideally this should be almost a drop-in replacement.