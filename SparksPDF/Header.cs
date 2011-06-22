using System.IO;

namespace SparksPDF
{
	internal class Header
	{
		private const string PDF_VERSION = "%PDF-1.2";

		public void Write(Stream stream)
		{
			var encoding = new System.Text.ASCIIEncoding();
			var buffer = encoding.GetBytes(PDF_VERSION);

			stream.Write(buffer, (int)stream.Position, buffer.Length);
		}
	}
}
