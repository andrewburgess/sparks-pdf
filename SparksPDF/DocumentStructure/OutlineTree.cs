using System;
using System.Collections.Generic;

namespace SparksPDF.DocumentStructure
{
	public class OutlineTree : StructureObject
	{
		public OutlineTree(Document document) : base(document, "/Outlines")
		{
		}

		public override List<byte> GetOutput()
		{
			throw new NotImplementedException();
		}
	}
}