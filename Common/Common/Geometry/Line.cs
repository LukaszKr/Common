using System;

namespace Common.Geometry
{
	public class Line
    {
		public Point Start { get; private set; }
		public Point End { get; private set; }

		public double Length
		{
			get { return Start.DistanceSqrt(End); }
		}

		public Line(Point startPoint, Point endPoint)
		{
			Start = startPoint;
			End = endPoint;
		}

		public bool Intersects(Line line)
		{
			return ((Orientation(line.Start) != Orientation(line.End)) && (line.Orientation(Start) != line.Orientation(End)));
		}

		public Point IntersectPoint(Line line)
		{
			float dx1 = End.X-Start.X;
			float dx2 = line.End.X-line.Start.X;
			float dx3 = Start.X-line.Start.X;

			float dy1 = End.Y-Start.Y;
			float dy2 = Start.Y-line.Start.Y;
			float dy3 = line.End.Y-line.Start.Y;

			float r = dx1*dy3-dy1*dx2;

			if(r != 0)
			{
				r = (dy2*(line.End.X-line.Start.X) - line.Start.X*dy3)/r;
				return new Point(Start.X+r*dx1, Start.Y+r*dy1);
			}
			else if((End.X-Start.X)*(line.Start.Y-Start.Y) - (line.Start.X-Start.X)*(End.Y-Start.Y) == 0)
			{
				return new Point(line.Start);
			}
			else
			{
				return new Point(line.End);
			}
		}

		public double NormalDistance(Point point)
		{
			return Math.Abs(((End.X-Start.X)*(Start.Y-point.Y)-(Start.X-point.X)*(End.Y-Start.Y))/Length);
		}

		public double Distance(Point point)
		{
			return 0;
	//		Local Dx#, Dy#, Ratio#
	
	//If(x1 = x2) And(y1 = y2) Then
	//  Return Sqr((Px-x1)*(Px-x1)+(Py-y1)*(Py-y1))
	//Else

	//	Dx#    = x2 - x1
	//	Dy#    = y2 - y1
	//	Ratio# = ((Px - x1) * Dx + (Py - y1) * Dy) / (Dx * Dx + Dy * Dy)
		
	//	If Ratio < 0 Then
	//		Return Sqr((Px-x1)*(Px-x1)+(Py-y1)*(Py-y1))
	//	ElseIf Ratio > 1 Then
	//		Return Sqr((Px-x2)*(Px-x2)+(Py-y2)*(Py-y2))
	//	Else
	//		Return Sqr((Px - ((1 - Ratio) * x1 + Ratio * x2))*(Px - ((1 - Ratio) * x1 + Ratio * x2))+(Py - ((1 - Ratio) * y1 + Ratio * y2))*(Py - ((1 - Ratio) * y1 + Ratio * y2)))
	//	EndIf

	//EndIf
		}

		public double Distance(Line line)
		{
			return 0;
	//		Local Dt#
	//Local sc#
	//Local sN#
	//Local sD#
	//Local tc#
	//Local tN#
	//Local tD#
	//Local dx#
	//Local dy#
	
	//Local ux# = x2 - x1
	//Local uy# = y2 - y1
	//Local vx# = x4 - x3
	//Local vy# = y4 - y3
	//Local wx# = x1 - x3
	//Local wy# = y1 - y3
	
	//Local a# = (ux * ux + uy * uy)
	//Local b# = (ux * vx + uy * vy)
	//Local c# = (vx * vx + vy * vy)
	//Local d# = (ux * wx + uy * wy)
	//Local e# = (vx * wx + vy * wy)
	
	//Dt = a * c - b * b
	//sD = Dt
	//tD = Dt


	//If Abs(Dt)<0.0001 Then
	//	sN = 0.0
	//	sD = 1.0
	//	tN = e
	//	tD = c
	//Else
	//	sN = (b * e - c * d)
	//	tN = (a * e - b * d)
	//	If sN < 0.0 Then
	//		sN = 0.0
	//		tN = e
	//		tD = c
	//	ElseIf sN > sD Then
	//		sN = sD
	//		tN = e + b
	//		tD = c
	//	EndIf
	//EndIf


	//If tN < 0.0 Then
	//	tN = 0.0
	//	If -d < 0.0 Then
	//		sN = 0.0
	//	ElseIf -d > a Then
	//		sN = sD
	//	Else
	//		sN = -d
	//		sD = a
	//	EndIf
	//ElseIf tN > tD Then
	//	tN = tD
	//	If(-d + b) < 0.0 Then
	//		sN = 0
	//	Else If(-d + b) > a Then
	//		sN = sD
	//	Else
	//		sN = (-d + b)
	//		sD = a
	//	EndIf
	//EndIf


	//If Abs(sN) < 0.0001 Then sc = 0.0 Else sc = sN / sD
	//If Abs(tN) < 0.0001 Then tc = 0.0 Else tc = tN / tD


	//dx = wx + (sc * ux) - (tc * vx)
	//dy = wy + (sc * uy) - (tc * vy)


	//Return Sqr(dx * dx + dy * dy)
		}

		public Point NearestInLine(Point point)
		{
	//		Local dx#=lx2-lx1
	//Local dy#=ly2-ly1
	//; d# = Sqr(dx*dx+dy*dy)
	//; ux# = dx/d
	//; uy# = dy/d
	//Local Ori1% = Orientation(lx1, ly1, (lx1+dy), (ly1-dx), x, y)
	//Local Ori2% = Orientation(lx2, ly2, (lx2+dy), (ly2-dx), x, y)
	//If(Ori1 = 1 And Ori2 = 1) Or Ori2 = 0 Then
	//   IntersectX = lx2
	//	IntersectY = ly2
	//ElseIf(Ori1 = -1 And Ori2 = -1) Or Ori1 = 0 Then
	//   IntersectX = lx1
	//	IntersectY = ly1
	//Else
	//	IntersectPoint(lx1, ly1, lx2, ly2, x, y, x+dy, y-dx)
	//EndIf
	//Return Sqr((x-IntersectX)*(x-IntersectX)+(y-IntersectY)*(y-IntersectY))
			return null;
		}

		//-1 to left, 0 on, 1 to right
		public int Orientation(Point point)
		{
			return Math.Sign((End.X-Start.X)*(point.Y-Start.Y)-(point.X-Start.X)*(End.Y-Start.Y));
		}
    }
}
