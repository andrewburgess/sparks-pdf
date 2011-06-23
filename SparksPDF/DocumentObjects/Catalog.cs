using System.Collections.Generic;
using System.Text;

namespace SparksPDF.DocumentObjects
{
	public class Catalog : PDFObject
	{
		public const string TYPE_IDENTIFIER = "/Type /Catalog";

		public Catalog(int position)
		{
			Position = position;
		}
	}
}