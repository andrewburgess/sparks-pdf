using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SparksPDF.DocumentObjects
{
	internal class Header
	{
		public const string PDF_VERSION = "%PDF-1.2\n";

		public List<byte> GetOutput()
		{
			var encoding = new ASCIIEncoding();
			var list = new List<byte>(encoding.GetBytes(PDF_VERSION));
			return list;
		}
	}
}
