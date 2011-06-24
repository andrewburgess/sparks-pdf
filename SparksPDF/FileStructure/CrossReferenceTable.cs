using System.Collections.Generic;
using System.Text;

namespace SparksPDF.FileStructure
{
	internal class CrossReferenceTable
	{
		public const string XREF_MARKER = "xref\n";

		public List<XRefEntry> Entries { get; private set; }

		private Document Document { get; set; }

		public CrossReferenceTable(Document document)
		{
			Document = document;
			Entries = new List<XRefEntry>
			          {
			          	new XRefEntry(0, 65535, true)
			          };
		}

		public void InsertEntry(int byteOffset)
		{
			Entries.Add(new XRefEntry(byteOffset, 0, false));
		}

		public List<byte> GetOutput()
		{
			var encoding = new ASCIIEncoding();
			var list = new List<byte>(encoding.GetBytes(XREF_MARKER));

			list.AddRange(encoding.GetBytes("0 " + Entries.Count + "\n"));

			foreach (var entry in Entries)
			{
				list.AddRange(encoding.GetBytes(entry.GetOutput()));
			}
			
			return list;
		}
	}
}