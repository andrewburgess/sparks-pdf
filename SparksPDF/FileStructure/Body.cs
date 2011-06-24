using System.Collections.Generic;
using System.Text;
using SparksPDF.DocumentObjects;
using SparksPDF.DocumentStructure;

namespace SparksPDF.FileStructure
{
	internal class Body
	{
		public Catalog Catalog { get; private set; }

		private Document Document { get; set; }

		public Body(Document document)
		{
			Document = document;
			Catalog = new Catalog(document);
		}

		public List<byte> GetOutput()
		{
			return Catalog.GetOutput();
		}
	}
}