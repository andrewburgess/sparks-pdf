using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SparksPDF.FileStructure;

namespace SparksPDF.DocumentStructure
{
	public class PageTree : StructureObject
	{
		public List<Page> Pages { get; set; }

		public PageTree(Document document) : base(document, "/Pages")
		{
			Pages = new List<Page>();
		}

		public override List<byte> GetOutput()
		{
			Document.CrossReferenceTable.Entries.Add(new XRefEntry(Document.CurrentBytes, 0, false));

			var builder = new StringBuilder();
			builder.AppendLine(GetObjectHeader());
			builder.AppendLine("<<");
			foreach (var kv in Dictionary)
			{
				builder.AppendLine(kv.Key + " " + kv.Value);
			}

			builder.Append("/Kids [");
			if (Pages.Count > 0)
				builder.Append(Pages[0].GetMinimalIndirectReference());
			foreach (var page in Pages.Skip(1))
			{
				builder.Append(" " + page.GetMinimalIndirectReference());
			}
			builder.Append("]\n");
			builder.AppendLine("/Count " + Pages.Count);

			builder.AppendLine(">>");
			builder.AppendLine("endobj");

			var bytes = new ASCIIEncoding().GetBytes(builder.ToString()).ToList();
			Document.CurrentBytes += bytes.Count;

			foreach (var page in Pages)
			{
				bytes.AddRange(page.GetOutput());
			}

			return bytes;
		}
	}
}