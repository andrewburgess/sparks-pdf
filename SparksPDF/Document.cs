using System.IO;

namespace SparksPDF
{
	public class Document
	{
		private Header Header { get; set; }

		public Document()
		{
			Header = new Header();
		}

		public void Write(Stream stream)
		{
			stream.Position = 0;
			Header.Write(stream);
		}
	}
}
