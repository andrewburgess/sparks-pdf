using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SparksPDF.FileStructure;

namespace SparksPDF.DocumentStructure
{
	public class Info : StructureObject
	{
		public const string KEY_AUTHOR = "/Author";
		public const string KEY_CREATION_DATE = "/CreationDate";
		public const string KEY_CREATOR = "/Creator";
		public const string KEY_PRODUCER = "/Producer";
		public const string KEY_TITLE = "/Title";
		public const string KEY_SUBJECT = "/Subject";
		public const string KEY_KEYWORDS = "/Keywords";

		public string Author { set { Dictionary[KEY_AUTHOR] = value; } }

		public DateTime CreationDate
		{
			set
			{
				var timezone = value.ToString("%K");
				var first = timezone.Substring(0, 3);
				var second = "'" + timezone.Substring(4) + "'";

				Dictionary[KEY_CREATION_DATE] = string.Format("(D:{0}{1})", value.ToString("yyyyMMddHHmmss"), first + second);
			}
		}

		public string Creator { set { Dictionary[KEY_CREATOR] = value; } }

		public string Producer { set { Dictionary[KEY_PRODUCER] = value; } }

		public string Title { set { Dictionary[KEY_TITLE] = value; } }

		public string Subject { set { Dictionary[KEY_SUBJECT] = value; } }

		public string Keywords { set { Dictionary[KEY_KEYWORDS] = value; } }

		public Info(Document document) : base(document, "/Info")
		{
			document.SetDocumentInfo(this);
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
				if (!string.IsNullOrEmpty(kv.Value))
					builder.AppendLine(kv.Key + " (" + kv.Value + ")");
			}
			builder.AppendLine(">>");
			builder.AppendLine("endobj");

			return new ASCIIEncoding().GetBytes(builder.ToString()).ToList();
		}

		#endregion
	}
}