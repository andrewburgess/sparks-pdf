using System.Collections.Generic;
using System.IO;

namespace SparksPDF.DocumentObjects
{
	internal class Body
	{
		public Catalog Catalog { get; private set; }
		public Pages Pages { get; private set; }
		public Outlines Outlines { get; private set; }

		public 

		public Body()
		{
			Catalog = new Catalog(1);
			Pages = null;
			Outlines = null;
		}

		public List<byte> GetOutput()
		{
			return new List<byte>();
		}
	}
}