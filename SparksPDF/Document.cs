using System.Collections.Generic;
using System.IO;
using SparksPDF.DocumentObjects;

namespace SparksPDF
{
	public class Document
	{
		internal Header Header { get; private set; }
		internal Body Body { get; private set; }
		internal CrossReferenceTable CrossReferenceTable { get; private set; }
		internal Trailer Trailer { get; private set; }

		public int XRefOffset { get; private set; }

		public Document()
		{
			Header = new Header();
			Body = new Body();
			CrossReferenceTable = new CrossReferenceTable();
			Trailer = new Trailer();
		}

		public void Write(Stream stream)
		{
			var bytes = new List<byte>();
			stream.Position = 0;
			bytes.AddRange(Header.GetOutput());
			bytes.AddRange(Body.GetOutput());

			XRefOffset = bytes.Count;

			bytes.AddRange(CrossReferenceTable.GetOutput());
			bytes.AddRange(Trailer.GetOutput(this));

			stream.Write(bytes.ToArray(), 0, bytes.Count);
		}
	}
}
