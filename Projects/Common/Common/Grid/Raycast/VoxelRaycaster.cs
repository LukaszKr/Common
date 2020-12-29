using System;

namespace ProceduralLevel.Common.Grid
{
	public static class VoxelRaycaster
	{
		public static int Raycast(float startX, float startY, float startZ, float directionX, float directionY, float directionZ, VoxelHit[] hitBuffer)
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
			currentX = Math.Max(currentX, 0);
			currentY = Math.Max(currentY, 0);
			currentZ = Math.Max(currentZ, 0);

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

			EDirection3D xExitFace = (stepX > 0? EDirection3D.Left: EDirection3D.Right);
			EDirection3D yExitFace = (stepY > 0? EDirection3D.Down: EDirection3D.Up);
			EDirection3D zExitFace = (stepZ > 0? EDirection3D.Back: EDirection3D.Forward);

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
				selectedFace = (directionZ > 0 ? EDirection3D.Back : EDirection3D.Forward);
			}

			while(iterator < bufferSize)
			{
				GridPoint3D point = new GridPoint3D(currentX, currentY, currentZ);
				if(travelX < travelY)
				{
					if(travelX < travelZ)
					{
						hitBuffer[iterator++] = new VoxelHit(point, selectedFace);
						selectedFace = xExitFace;

						currentX += stepX;
						travelX += deltaX;
					}
					else
					{
						hitBuffer[iterator++] = new VoxelHit(point, selectedFace);
						selectedFace = zExitFace;

						currentZ += stepZ;
						travelZ += deltaZ;
					}
				}
				else
				{
					if(travelY < travelZ)
					{
						hitBuffer[iterator++] = new VoxelHit(point, selectedFace);
						selectedFace = yExitFace;

						currentY += stepY;
						travelY += deltaY;
					}
					else
					{
						hitBuffer[iterator++] = new VoxelHit(point, selectedFace);
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