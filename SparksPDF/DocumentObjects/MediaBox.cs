namespace SparksPDF.DocumentObjects
{
	public class MediaBox : Rectangle
	{
		public MediaBox(int lowerLeftX, int lowerLeftY, int upperRightX, int upperRightY) : base(lowerLeftX, lowerLeftY, upperRightX, upperRightY)
		{
		}

		public MediaBox(Rectangle rectangle) : base(rectangle.LowerLeftX, rectangle.LowerLeftY, rectangle.UpperRightX, rectangle.UpperRightY)
		{
		}

		public string GetOutput()
		{
			return string.Format("[{0} {1} {2} {3}]", LowerLeftX, LowerLeftY, UpperRightX, UpperRightY);
		}
	}
}