using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SparksPDF.FileStructure
{
	internal class Header
	{
		private Document Document { get; set; }

		public Header(Document document)
		{
			Document = document;
		}

		public const string PDF_VERSION = "%PDF-1.2\n";

		public List<byte> GetOutput()
		{
			return new ASCIIEncoding().GetBytes(PDF_VERSION).ToList();
		}
	}
}
