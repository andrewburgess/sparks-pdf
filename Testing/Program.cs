using System.IO;
using SparksPDF;

namespace Testing
{
	class Program
	{
		static void Main(string[] args)
		{
			var fs = new FileStream("test.pdf", FileMode.Create);
			var document = new Document();
			document.Write(fs);
			fs.Close();
		}
	}
}
