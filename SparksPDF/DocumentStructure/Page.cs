using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SparksPDF.CoordinateSystems;
using SparksPDF.DocumentObjects;
using SparksPDF.FileStructure;

namespace SparksPDF.DocumentStructure
{
	public class Page : StructureObject
	{
		public const string KEY_MEDIA_BOX = "/MediaBox";
		public const string KEY_PARENT = "/Parent";

		private PageTree _parent;
		internal PageTree Parent
		{
			get { return _parent; }
			set
			{
				Dictionary.Add(KEY_PARENT, value.GetMinimalIndirectReference());
				_parent = value;
			}
		}
		private MediaBox MediaBox { get; set; }

		private Dictionary<string, string> Resources { get; set; }

		public Page(Document document) : base(document, "/Page")
		{
			MediaBox = new MediaBox(PageSizes.A4);

			Resources = new Dictionary<string, string>();

			Dictionary.Add(KEY_MEDIA_BOX, MediaBox.GetOutput());
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

			builder.AppendLine("/Resources <<");
			foreach (var kv in Resources)
			{
				builder.AppendLine(kv.Key + " " + kv.Value);
			}
			builder.AppendLine(">>");

			builder.AppendLine(">>");
			builder.AppendLine("endobj");

			var bytes = new ASCIIEncoding().GetBytes(builder.ToString()).ToList();
			Document.CurrentBytes += bytes.Count;

			return bytes;
		}

		#endregion
	}
}