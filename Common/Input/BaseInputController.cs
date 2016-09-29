﻿using System.Collections.Generic;

namespace ProceduralLevel.Common.Input
{
	public abstract class BaseInputController<ContextIDType, InputType>: IInputValidator<InputType>
    {
		private Dictionary<int, InputContext<InputType>> m_InputContexts;
		private List<InputContext<InputType>> m_ActiveInputContext;


		public BaseInputController()
		{
			m_InputContexts = new Dictionary<int, InputContext<InputType>>();
			m_ActiveInputContext = new List<InputContext<InputType>>();
		}

		public void RegisterInputContext(InputContext<InputType> context)
		{
			m_InputContexts[context.ContextID] = context;
		}

		public abstract void SetContext(ContextIDType contextID);
		public abstract void UnsetContext(ContextIDType contextID);
		public abstract bool IsContextSet(ContextIDType contextID);

		protected void SetContext(int contextID)
		{
			if(!IsContextSet(contextID))
			{
				m_ActiveInputContext.Add(m_InputContexts[contextID]);
			}
		}

		protected void UnsetContext(int contextID)
		{
			if(IsContextSet(contextID))
			{
				m_ActiveInputContext.Remove(m_InputContexts[contextID]);
			}
		}

		protected bool IsContextSet(int contextID)
		{
			for(int x = 0; x < m_ActiveInputContext.Count; x++)
			{
				if(m_ActiveInputContext[x].ContextID == contextID)
				{
					return true;
				}
			}
			return false;
		}

		public void ClearContext()
		{
			m_ActiveInputContext.Clear();
		}

		public bool IsInputValid(InputType input)
		{
			for(int x = 0; x < m_ActiveInputContext.Count; x++)
			{
				if(m_ActiveInputContext[x].IsInputValid(input))
				{
					return true;
				}
			}
			return false;
		}
	}
}