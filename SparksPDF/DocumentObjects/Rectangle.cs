namespace SparksPDF.DocumentObjects
{
	public class Rectangle
	{
		public int LowerLeftX { get; set; }
		public int LowerLeftY { get; set; }
		public int UpperRightX { get; set; }
		public int UpperRightY { get; set; }

		public Rectangle(int lowerLeftX, int lowerLeftY, int upperRightX, int upperRightY)
		{
			LowerLeftX = lowerLeftX;
			LowerLeftY = lowerLeftY;
			UpperRightY = upperRightY;
			UpperRightX = upperRightX;
		}
	}
}