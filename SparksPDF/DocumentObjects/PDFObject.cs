using System.Collections.Generic;
using System.Text;

namespace SparksPDF.DocumentObjects
{
	public abstract class PDFObject
	{
		public int Position { get; protected set; }

		public string GetIndirectReference()
		{
			return Position + " 0 R";
		}

		public abstract List<byte> GetOutput(Document document);
	}
}