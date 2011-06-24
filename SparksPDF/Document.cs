using System.Collections.Generic;
using System.IO;
using SparksPDF.DocumentStructure;
using SparksPDF.FileStructure;

namespace SparksPDF
{
	public class Document
	{
		internal Header Header { get; private set; }
		internal Body Body { get; private set; }
		internal CrossReferenceTable CrossReferenceTable { get; private set; }
		internal Trailer Trailer { get; private set; }

		public int ObjectCount { get; set; }
		public int CurrentBytes { get; set; }

		public Document()
		{
			ObjectCount = 1;
			Header = new Header(this);
			Body = new Body(this);
			CrossReferenceTable = new CrossReferenceTable(this);
			Trailer = new Trailer(this);
		}

		public void AddPage(Page page)
		{
			page.Parent = Body.Catalog.PageTree;
			Body.Catalog.PageTree.Pages.Add(page);
		}

		public void Write(Stream stream)
		{
			var bytes = new List<byte>();
			stream.Position = 0;
			CurrentBytes = 0;

			bytes.AddRange(Header.GetOutput());
			CurrentBytes = bytes.Count;

			bytes.AddRange(Body.GetOutput());
			CurrentBytes = bytes.Count;

			bytes.AddRange(CrossReferenceTable.GetOutput());
			CurrentBytes = bytes.Count;

			bytes.AddRange(Trailer.GetOutput());
			CurrentBytes = bytes.Count;

			stream.Write(bytes.ToArray(), 0, bytes.Count);
		}
	}
}
