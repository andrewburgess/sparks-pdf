using System;
using System.Collections.Generic;

namespace SparksPDF.DocumentStructure
{
	public abstract class StructureObject
	{
		public const string KEY_TYPE = "/Type";
		public int Position { get; protected set; }
		public string Key { get; protected set; }
		public int Generation { get; set; }
		protected Document Document { get; set; }
		protected Dictionary<string, string> Dictionary { get; set; }

		protected StructureObject(Document document, string key)
		{
			Dictionary = new Dictionary<string, string>();
			Position = document.ObjectCount;
			document.ObjectCount++;

			Document = document;
			Generation = 0;
			Key = key;

			Dictionary.Add(KEY_TYPE, Key);
		}

		public virtual string GetIndirectReference()
		{
			return Key + " " + Position + " " + Generation + " R";
		}

		public virtual string GetObjectHeader()
		{
			return Position + " " + Generation + " obj";
		}

		public abstract List<byte> GetOutput();

		public virtual string GetMinimalIndirectReference()
		{
			return Position + " " + Generation + " R";
		}
	}
}