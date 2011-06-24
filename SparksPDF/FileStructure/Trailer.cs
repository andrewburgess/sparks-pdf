using System.Collections.Generic;
using System.Text;

namespace SparksPDF.FileStructure
{
	internal class Trailer
	{
		public const string TRAILER_MARKER = "trailer\n";
		public const string EOF_MARKER = "%%EOF";
		public const string START_XREF_MARKER = "startxref\n";

		private const string SIZE_KEY = "/Size";
		private const string ROOT_KEY = "/Root";

		private Document Document { get; set; }

		public Trailer(Document document)
		{
			Document = document;
		}

		public List<byte> GetOutput()
		{
			var encoding = new ASCIIEncoding();
			var list = new List<byte>();

			list.AddRange(encoding.GetBytes(TRAILER_MARKER));
			list.AddRange(encoding.GetBytes("<<\n"));

			list.AddRange(encoding.GetBytes(SIZE_KEY + " " + Document.CrossReferenceTable.Entries.Count + "\n"));
			list.AddRange(encoding.GetBytes(ROOT_KEY + " " + Document.Body.Catalog.GetMinimalIndirectReference() + "\n"));

			if (Document.Info != null)
				list.AddRange(encoding.GetBytes(Document.Info.GetIndirectReference()));

			list.AddRange(encoding.GetBytes(">>\n"));

			list.AddRange(encoding.GetBytes(START_XREF_MARKER));
			list.AddRange(encoding.GetBytes(Document.CurrentBytes + "\n"));

			list.AddRange(encoding.GetBytes(EOF_MARKER));

			return list;
		}
	}
}