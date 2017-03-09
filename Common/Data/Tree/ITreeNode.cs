using System.Collections.Generic;

namespace ProceduralLevel.Common.Data
{
	public interface ITreeNode<NodeType> where NodeType : class, ITreeNode<NodeType>
	{
		NodeType Parent { get; set; }

		List<NodeType> GetNodes();
		bool CanBeDirectChildOf(NodeType node);
	}
}
