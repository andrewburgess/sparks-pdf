using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SparksPDF.DocumentObjects
{
	internal class Trailer
	{
		public const string TRAILER_MARKER = "trailer\n";
		public const string EOF_MARKER = "%%EOF";
		public const string START_XREF_MARKER = "startxref\n";

		private const string SIZE_KEY = "/Size";
		private const string ROOT_KEY = "/Root";

		public List<byte> GetOutput(Document document)
		{
			var encoding = new ASCIIEncoding();
			var list = new List<byte>();

			list.AddRange(encoding.GetBytes(TRAILER_MARKER));
			list.AddRange(encoding.GetBytes("<<\n"));

			list.AddRange(encoding.GetBytes(SIZE_KEY + " " + document.CrossReferenceTable.Entries.Count + "\n"));
			list.AddRange(encoding.GetBytes(ROOT_KEY + " " + document.Body.Catalog));

			list.AddRange(encoding.GetBytes(">>\n"));

			list.AddRange(encoding.GetBytes(START_XREF_MARKER));
			list.AddRange(encoding.GetBytes(document.XRefOffset + "\n"));

			list.AddRange(encoding.GetBytes(EOF_MARKER));

			return list;
		}
	}
}