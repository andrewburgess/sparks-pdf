using System;
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

			var info = new Info(document);
			info.Author = "Andrew Burgess";
			info.CreationDate = DateTime.Now;
			info.Creator = "SparksPDF";
			info.Producer = "SparksPDF";
			info.Subject = "Testing Document";

			document.AddPage(new Page(document));
			document.AddPage(new Page(document));
			document.Write(fs);
			fs.Close();
		}
	}
}
