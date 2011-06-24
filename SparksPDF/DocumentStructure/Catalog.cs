using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SparksPDF.Enums;
using SparksPDF.FileStructure;

namespace SparksPDF.DocumentStructure
{
	public class Catalog : StructureObject
	{
		public const string KEY_PAGE_MODE = "/PageMode";

		public PageTree PageTree { get; private set; }
		private OutlineTree Outline { get; set; }

		public Catalog(Document document) : base(document, "/Catalog")
		{
			PageTree = new PageTree(document);
			Outline = null;

			SetPageMode(PageMode.UseNone);
		}

		public void SetPageMode(PageMode mode)
		{
			if (Dictionary.ContainsKey(KEY_PAGE_MODE))
				Dictionary[KEY_PAGE_MODE] = "/" + mode;
			else
				Dictionary.Add(KEY_PAGE_MODE, "/" + mode);
		}


		#region Overrides of StructureObject

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

			builder.AppendLine(PageTree.GetIndirectReference());
			if (Outline != null)
				builder.AppendLine(Outline.GetIndirectReference());

			builder.AppendLine(">>");
			builder.AppendLine("endobj");

			var bytes = new ASCIIEncoding().GetBytes(builder.ToString()).ToList();
			Document.CurrentBytes += bytes.Count;

			bytes.AddRange(PageTree.GetOutput());

			if (Outline != null)
				bytes.AddRange(Outline.GetOutput());

			return bytes;
		}

		#endregion
	}
}