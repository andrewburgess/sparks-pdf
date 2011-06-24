using System.Collections.Generic;

namespace SparksPDF
{
	public abstract class PDFObject
	{
		public abstract List<byte> GetOutput();
	}
}