using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Grid
{
	public static class GridRaycaster3D
	{
		public static IEnumerable<GridHit3D> Raycast(float startX, float startY, float startZ, float directionX, float directionY, float directionZ)
		{
			int stepX = Math.Sign(directionX);
			int stepY = Math.Sign(directionY);
			int stepZ = Math.Sign(directionZ);

			if(stepX == 0 && stepY == 0 && stepZ == 0)
			{
				yield break;
			}

			int currentX = (int)Math.Floor(startX);
			int currentY = (int)Math.Floor(startY);
			int currentZ = (int)Math.Floor(startZ);

			float nextBoundX = CalculateBound(currentX, startX, stepX);
			float nextBoundY = CalculateBound(currentY, startY, stepY);
			float nextBoundZ = CalculateBound(currentZ, startZ, stepZ);

			float deltaX = (1f/directionX)*stepX;
			float deltaY = (1f/directionY)*stepY;
			float deltaZ = (1f/directionZ)*stepZ;

			float travelX = nextBoundX/directionX;
			float travelY = nextBoundY/directionY;
			float travelZ = nextBoundZ/directionZ;

			EDirection3D xExitFace = (stepX > 0 ? EDirection3D.Left : EDirection3D.Right);
			EDirection3D yExitFace = (stepY > 0 ? EDirection3D.Down : EDirection3D.Up);
			EDirection3D zExitFace = (stepZ > 0 ? EDirection3D.Back : EDirection3D.Front);

			EDirection3D selectedFace;
			float startDecimalX = startX-(float)Math.Truncate(startX);
			float startDecimalY = startY-(float)Math.Truncate(startY);
			float startDecimalZ = startZ-(float)Math.Truncate(startZ);
			if(startDecimalX < startDecimalY && startDecimalX < startDecimalZ)
			{
				selectedFace = (directionX > 0 ? EDirection3D.Left : EDirection3D.Right);
			}
			else if(startDecimalY < startDecimalX && startDecimalY < startDecimalZ)
			{
				selectedFace = (directionY > 0 ? EDirection3D.Down : EDirection3D.Up);
			}
			else
			{
				selectedFace = (directionZ > 0 ? EDirection3D.Back : EDirection3D.Front);
			}

			while(true)
			{
				GridIndex3D point = new GridIndex3D(currentX, currentY, currentZ);
				if(travelX < travelY)
				{
					if(travelX < travelZ)
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = xExitFace;

						currentX += stepX;
						travelX += deltaX;
					}
					else
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = zExitFace;

						currentZ += stepZ;
						travelZ += deltaZ;
					}
				}
				else
				{
					if(travelY < travelZ)
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = yExitFace;

						currentY += stepY;
						travelY += deltaY;
					}
					else
					{
						yield return new GridHit3D(point, selectedFace);
						selectedFace = zExitFace;

						currentZ += stepZ;
						travelZ += deltaZ;
					}
				}
			}
		}

		public static int Raycast(float startX, float startY, float startZ, float directionX, float directionY, float directionZ, GridHit3D[] hitBuffer)
		{
			int stepX = Math.Sign(directionX);
			int stepY = Math.Sign(directionY);
			int stepZ = Math.Sign(directionZ);

			if(stepX == 0 && stepY == 0 && stepZ == 0)
			{
				return 0;
			}

			int bufferSize = hitBuffer.Length;

			int currentX = (int)Math.Floor(startX);
			int currentY = (int)Math.Floor(startY);
			int currentZ = (int)Math.Floor(startZ);

			float nextBoundX = CalculateBound(currentX, startX, stepX);
			float nextBoundY = CalculateBound(currentY, startY, stepY);
			float nextBoundZ = CalculateBound(currentZ, startZ, stepZ);

			float deltaX = (1f/directionX)*stepX;
			float deltaY = (1f/directionY)*stepY;
			float deltaZ = (1f/directionZ)*stepZ;

			float travelX = nextBoundX/directionX;
			float travelY = nextBoundY/directionY;
			float travelZ = nextBoundZ/directionZ;

			int iterator = 0;

			EDirection3D xExitFace = (stepX > 0 ? EDirection3D.Left : EDirection3D.Right);
			EDirection3D yExitFace = (stepY > 0 ? EDirection3D.Down : EDirection3D.Up);
			EDirection3D zExitFace = (stepZ > 0 ? EDirection3D.Back : EDirection3D.Front);

			EDirection3D selectedFace;
			float startDecimalX = startX-(float)Math.Truncate(startX);
			float startDecimalY = startY-(float)Math.Truncate(startY);
			float startDecimalZ = startZ-(float)Math.Truncate(startZ);
			if(startDecimalX < startDecimalY && startDecimalX < startDecimalZ)
			{
				selectedFace = (directionX > 0 ? EDirection3D.Left : EDirection3D.Right);
			}
			else if(startDecimalY < startDecimalX && startDecimalY < startDecimalZ)
			{
				selectedFace = (directionY > 0 ? EDirection3D.Down : EDirection3D.Up);
			}
			else
			{
				selectedFace = (directionZ > 0 ? EDirection3D.Back : EDirection3D.Front);
			}

			while(iterator < bufferSize)
			{
				GridIndex3D point = new GridIndex3D(currentX, currentY, currentZ);
				if(travelX < travelY)
				{
					if(travelX < travelZ)
					{
						hitBuffer[iterator++] = new GridHit3D(point, selectedFace);
						selectedFace = xExitFace;

						currentX += stepX;
						travelX += deltaX;
					}
					else
					{
						hitBuffer[iterator++] = new GridHit3D(point, selectedFace);
						selectedFace = zExitFace;

						currentZ += stepZ;
						travelZ += deltaZ;
					}
				}
				else
				{
					if(travelY < travelZ)
					{
						hitBuffer[iterator++] = new GridHit3D(point, selectedFace);
						selectedFace = yExitFace;

						currentY += stepY;
						travelY += deltaY;
					}
					else
					{
						hitBuffer[iterator++] = new GridHit3D(point, selectedFace);
						selectedFace = zExitFace;

						currentZ += stepZ;
						travelZ += deltaZ;
					}
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