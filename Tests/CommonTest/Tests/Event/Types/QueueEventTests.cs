using NUnit.Framework;
using ProceduralLevel.Common.Event;

namespace Tests.Event.Types
{
	[TestFixture]
	public class QueueEventTests: AEventTests<QueueEvent<int>>
	{
	}
}
