using System.Collections.Generic;

namespace ProceduralLevel.Common.Data
{
	//this is in extension to prevent code-repeating that would happen if it was just an interface
	public static class TreeNodeExt
	{
		public static bool SetParent<NodeType>(this NodeType node, NodeType parent) where NodeType : class, ITreeNode<NodeType>
		{
			if(!node.CanBeDirectChildOf(parent))
			{
				return false;
			}

			if(node.Parent != null)
			{
				node.Parent.GetNodes().Remove(node);
			}
			node.Parent = parent;
			if(node.Parent != null)
			{
				node.Parent.GetNodes().Add(node);
			}
			return true;
		}

		public static bool CanBeChildOf<NodeType>(this NodeType node, NodeType potentialParent) where NodeType : class, ITreeNode<NodeType>
		{
			if(potentialParent == null)
			{
				return node.Parent != null;
			}
			if(potentialParent.Equals(node.Parent) || potentialParent.Equals(node) || (potentialParent != null && potentialParent.IsChildOf(node)))
			{
				return false;
			}

			return node.CanBeDirectChildOf(potentialParent);
		}

		public static bool IsChildOf<NodeType>(this NodeType node, NodeType parent) where NodeType : class, ITreeNode<NodeType>
		{
			if(parent == null)
			{
				if(node.Parent == null)
				{
					return true;
				}
				return false;
			}

			List<NodeType> childNodes = parent.GetNodes();
			for(int x = 0; x < childNodes.Count; x++)
			{
				NodeType child = childNodes[x];
				if(child.Equals(node))
				{
					return true;
				}
				if(node.IsChildOf(child))
				{
					return true;
				}
			}
			return false;
		}
	}
}
