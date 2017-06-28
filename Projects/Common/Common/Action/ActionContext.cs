using System.Collections.Generic;

namespace ProceduralLevel.Common.Action
{
	public class ActionContext<DataType>
	{
		private int m_Depth;
		private Queue<IBaseAction<DataType>> m_Actions;

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
			m_Actions = new Queue<IBaseAction<DataType>>();
		}

		public void PushAction(IBaseAction<DataType> action) 
		{
			m_Actions.Enqueue(action);
		}

		public IBaseAction<DataType> PopAction() 
		{
			if(m_Actions.Count > 0) 
			{
				return m_Actions.Dequeue();
			}
			return null;
		}

		public bool Execute(DataType data)
		{
			IBaseAction<DataType> action = PopAction();
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
