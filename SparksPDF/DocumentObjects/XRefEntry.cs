using System;
using System.Text;

namespace SparksPDF.DocumentObjects
{
	internal class XRefEntry
	{
		public int ByteOffset { get; set; }
		public int Generation { get; set; }
		public bool IsFree { get; set; }

		public XRefEntry(int byteOffset, int generation, bool isFree)
		{
			ByteOffset = byteOffset;
			Generation = generation;
			IsFree = isFree;
		}

		public string GetOutput()
		{
			var line = new StringBuilder();
			line.Append(ByteOffset.ToString().PadLeft(10, '0'));
			line.Append(" ");
			line.Append(Generation.ToString().PadLeft(5, '0'));
			line.Append(" ");
			line.Append(IsFree ? "f" : "n");
			line.Append("\r\n");
			return line.ToString();
		}
	}
}