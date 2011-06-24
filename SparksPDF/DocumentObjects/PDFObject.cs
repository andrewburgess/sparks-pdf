using System.Collections.Generic;

namespace SparksPDF.DocumentObjects
{
	public abstract class PDFObject
	{
		public abstract List<byte> GetOutput(Document document);
	}
}