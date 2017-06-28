using System.Collections.Generic;

namespace ProceduralLevel.Common.Action
{
	public class ActionContext<DataType>
	{
		private int m_Depth;
		private Queue<IAction<DataType>> m_Actions;

		public int Depth 
		{
			get { return m_Depth; }
		}

		public int Count 
		{
			get { return m_Actions.Count; }
		}

		public ActionContext(int depth) 
		{
			m_Depth = depth;
			m_Actions = new Queue<IAction<DataType>>();
		}

		public void PushAction(IAction<DataType> action) 
		{
			m_Actions.Enqueue(action);
		}

		public IAction<DataType> PopAction() 
		{
			if(m_Actions.Count > 0) 
			{
				return m_Actions.Dequeue();
			}
			return null;
		}

		public bool Execute(DataType data)
		{
			IAction<DataType> action = PopAction();
			if(action != null)
			{
				if(action.IsValid(data))
				{
					action.Apply(data);
				}
				return true;
			}
			return false;
		}
	}
}
