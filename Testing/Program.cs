using System.IO;
using SparksPDF;
using SparksPDF.DocumentStructure;

namespace Testing
{
	class Program
	{
		static void Main(string[] args)
		{
			var fs = new FileStream("test.pdf", FileMode.Create);
			var document = new Document();
			document.AddPage(new Page(document));
			document.Write(fs);
			fs.Close();
		}
	}
}
