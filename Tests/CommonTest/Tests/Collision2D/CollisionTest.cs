using NUnit.Framework;
using ProceduralLevel.Common.Collision2D;
using Tests.Collision2D;

namespace Tests.Collision
{
	[TestFixture]
	public class CollisionTest
	{
		[Test]
		public void DistancePointToPoint()
		{
			AssertTests("Distance - Point to Point",
				new PointToPointDistanceTest(new Point(40, 100), new Point(160, 100), 120)
			);
		}

		[Test]
		public void DistancePointToCircle()
		{
			AssertTests("Distance - Point to Circle",
				new PointToCircleDistanceTest(new Point(150, 100), new Circle(100, 100, 40), 10),
				new PointToCircleDistanceTest(new Point(140, 100), new Circle(100, 100, 40), 0),
				new PointToCircleDistanceTest(new Point(120, 100), new Circle(100, 100, 40), 0)
			);
		}

		[Test]
		public void DistanceCircleToCircle()
		{
			AssertTests("Distance - Circle to Cirlce",
				new CircleToCircleDistanceTest(new Circle(60, 100, 30), new Circle(140, 100, 40), 10),
				new CircleToCircleDistanceTest(new Circle(60, 100, 40), new Circle(140, 100, 40), 0),
				new CircleToCircleDistanceTest(new Circle(60, 100, 40), new Circle(70, 100, 20), 0),
				new CircleToCircleDistanceTest(new Circle(60, 100, 40), new Circle(100, 100, 20), 0)
			);
		}

		[Test]
		public void DistanceCircleToLine()
		{
			AssertTests("Distance - Circle to Line",
				new CircleToLineDistanceTest(new Circle(140, 100, 20), new Line(100, 60, 100, 140), false, 20),
				new CircleToLineDistanceTest(new Circle(140, 100, 20), new Line(100, 60, 100, 140), true, 20),
				new CircleToLineDistanceTest(new Circle(100, 40, 20), new Line(50, 60, 50, 140), false, 30),
				new CircleToLineDistanceTest(new Circle(100, 40, 20), new Line(50, 60, 50, 140), true, 33.85165f),
				new CircleToLineDistanceTest(new Circle(100, 160, 20), new Line(50, 60, 50, 140), false, 30),
				new CircleToLineDistanceTest(new Circle(100, 160, 20), new Line(50, 60, 50, 140), true, 33.85165f)
			);
		}

		[Test]
		public void DistancePointToLine()
		{
			AssertTests("Distance - Point to Line",
				new PointToLineDistanceTest(new Point(100, 20), new Line(100, 40, 100, 160), false, 0),
				new PointToLineDistanceTest(new Point(100, 20), new Line(100, 40, 100, 160), true, 20),
				new PointToLineDistanceTest(new Point(130, 100), new Line(100, 40, 100, 160), false, 30),
				new PointToLineDistanceTest(new Point(130, 100), new Line(100, 40, 100, 160), true, 30),
				new PointToLineDistanceTest(new Point(90, 10), new Line(50, 40, 50, 160), false, 40),
				new PointToLineDistanceTest(new Point(90, 10), new Line(50, 40, 50, 160), true, 50),
				new PointToLineDistanceTest(new Point(90, 190), new Line(50, 40, 50, 160), false, 40),
				new PointToLineDistanceTest(new Point(90, 190), new Line(50, 40, 50, 160), true, 50)
			);
		}

		[Test]
		public void IntersectionPointToCircle()
		{
			AssertTests("Intersection - Point to Circle",
				new PointToCircleIntersectionTest(new Point(50, 100), new Circle(100, 100, 40), false),
				new PointToCircleIntersectionTest(new Point(60, 100), new Circle(100, 100, 40), true),
				new PointToCircleIntersectionTest(new Point(80, 100), new Circle(100, 100, 40), true)
			);
		}

		[Test]
		public void IntersectionPointToLine()
		{
			AssertTests("Intersection - Point to Line",
				new PointToLineIntersectionTest(new Point(100, 100), new Line(40, 40, 160, 160), true),
				new PointToLineIntersectionTest(new Point(100, 100), new Line(40, 40, 160, 120), false)
			);
		}

		[Test]
		public void IntersectionCircleToCircle()
		{
			AssertTests("Intersection - Circle to Cirlce",
				new CircleToCircleIntersectionTest(new Circle(60, 100, 30), new Circle(140, 100, 40), false),
				new CircleToCircleIntersectionTest(new Circle(60, 100, 40), new Circle(140, 100, 40), true),
				new CircleToCircleIntersectionTest(new Circle(60, 100, 40), new Circle(70, 100, 20), true),
				new CircleToCircleIntersectionTest(new Circle(60, 100, 40), new Circle(100, 100, 20), true)
			);
		}

		[Test]
		public void IntersectionCircleToLine()
		{
			AssertTests("Intersection - Circle to Line",
				new CircleToLineIntersectionTest(new Circle(130, 100, 20), new Line(100, 40, 100, 160), false),
				new CircleToLineIntersectionTest(new Circle(70, 100, 20), new Line(50, 40, 50, 160), true),
				new CircleToLineIntersectionTest(new Circle(60, 100, 20), new Line(50, 40, 50, 160), true),
				new CircleToLineIntersectionTest(new Circle(50, 70, 20), new Line(50, 80, 50, 160), true),
				new CircleToLineIntersectionTest(new Circle(50, 30, 20), new Line(50, 80, 50, 160), false),
				new CircleToLineIntersectionTest(new Circle(50, 60, 20), new Line(50, 80, 50, 160), true)
			);
		}

		[Test]
		public void IntersectionLineToLine()
		{
			AssertTests("Intersection - Line to Line",
				new LineToLineIntersectionTest(new Line(40, 40, 60, 100), new Line(100, 100, 80, 90), false),
				new LineToLineIntersectionTest(new Line(40, 40, 60, 100), new Line(100, 100, 10, 160), false),
				new LineToLineIntersectionTest(new Line(100, 40, 100, 100), new Line(100, 20, 100, 120), true), //overlapping
				new LineToLineIntersectionTest(new Line(40, 40, 160, 160), new Line(110, 40, 40, 120), true),
				new LineToLineIntersectionTest(new Line(40, 40, 100, 100), new Line(60, 60, 80, 90), true) //point sticking		
			);
		}

		[Test]
		public void OrientationPointToLine()
		{
			AssertTests("Orientation - Point to Line",
					new OrientationTest(new Line(40, 160, 160, 40), new Point(40, 40), EOrientation.Left),
					new OrientationTest(new Line(40, 160, 160, 40), new Point(100, 100), EOrientation.On),
					new OrientationTest(new Line(40, 160, 160, 40), new Point(160, 160), EOrientation.Right)
			);
		}

		private void AssertTests(string groupName, params ACollisionTest[] tests)
		{
			int length = tests.Length;
			for(int x = 0; x < length; ++x)
			{
				ACollisionTest test = tests[x];
				Assert.IsTrue(test.Passed(), test.ToString());
			}
		}
	}
}
