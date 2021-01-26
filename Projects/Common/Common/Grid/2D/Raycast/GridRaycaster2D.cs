using System;

namespace ProceduralLevel.Common.Grid
{
	public static class GridRaycaster2D
	{
		public static int Raycast(float startX, float startY, float directionX, float directionY, GridHit2D[] hitBuffer)
		{
			int stepX = Math.Sign(directionX);
			int stepY = Math.Sign(directionY);

			if(stepX == 0 && stepY == 0)
			{
				return 0;
			}

			int bufferSize = hitBuffer.Length;

			int currentX = (int)Math.Floor(startX);
			int currentY = (int)Math.Floor(startY);
			currentX = Math.Max(currentX, 0);
			currentY = Math.Max(currentY, 0);

			float nextBoundX = CalculateBound(currentX, startX, stepX);
			float nextBoundY = CalculateBound(currentY, startY, stepY);

			float deltaX = (1f/directionX)*stepX;
			float deltaY = (1f/directionY)*stepY;

			float travelX = nextBoundX/directionX;
			float travelY = nextBoundY/directionY;

			int iterator = 0;

			EDirection2D xExitFace = (stepX > 0 ? EDirection2D.Left : EDirection2D.Right);
			EDirection2D yExitFace = (stepY > 0 ? EDirection2D.Down : EDirection2D.Up);

			EDirection2D selectedFace;
			float startDecimalX = startX-(float)Math.Truncate(startX);
			float startDecimalY = startY-(float)Math.Truncate(startY);
			if(startDecimalX < startDecimalY)
			{
				selectedFace = (directionX > 0 ? EDirection2D.Left : EDirection2D.Right);
			}
			else
			{
				selectedFace = (directionY > 0 ? EDirection2D.Down : EDirection2D.Up);
			}

			while(iterator < bufferSize)
			{
				GridPoint2D point = new GridPoint2D(currentX, currentY);
				if(travelX < travelY)
				{
					hitBuffer[iterator++] = new GridHit2D(point, selectedFace);
					selectedFace = xExitFace;

					currentX += stepX;
					travelX += deltaX;
				}
				else
				{
					hitBuffer[iterator++] = new GridHit2D(point, selectedFace);
					selectedFace = yExitFace;

					currentY += stepY;
					travelY += deltaY;
				}
			}

			return iterator;
		}

		public static float CalculateBound(int current, float start, int step)
		{
			if(step == 0)
			{
				return float.MaxValue;
			}
			if(step > 0)
			{
				return (current-start+step);
			}
			else
			{
				return (current-start);
			}
		}
	}
}