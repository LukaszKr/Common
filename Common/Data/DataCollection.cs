using ProceduralLevel.Common.Helper;
using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Data
{
	public class DataCollection<DataType> where DataType : class, IDataItem
	{
		protected ArrayList<DataType> m_Items = new ArrayList<DataType>();
		private BaseIdProvider m_IdProvider;

		public delegate bool ParameterCompareFunc<T>(DataType type, T value);

		public int Count
		{
			get { return m_Items.Count; }
		}

		public ArrayList<DataType> Items
		{
			get { return m_Items; }
		}

		public DataCollection(BaseIdProvider idProvider = null)
		{
			if(idProvider == null)
			{
				m_IdProvider = new SimpleIdProvider();
			}
			else
			{
				m_IdProvider = idProvider;
			}
		}

		#region CRUD
		public bool Add(DataType dataItem)
		{
			if(dataItem.ID > 0)
			{
				throw new Exception("Item is already in other DataCollection");
			}
			dataItem.ID = m_IdProvider.GetId();
			m_Items.Add(dataItem);
			return true;
		}

		public bool Contains(DataType item)
		{
			return ContainsItemBy(CompareFunc, item);
		}

		public bool Remove(DataType item)
		{
			return RemoveItemBy(CompareFunc, item);
		}

		public ArrayList<DataType> GetAll()
		{
			return m_Items;
		}
		#endregion

		#region ID CRUD
		public bool ContainsById(int id)
		{
			return ContainsItemBy(IDCompareFunc, id);
		}

		public DataType GetById(int id)
		{
			return GetItemBy(IDCompareFunc, id);
		}

		public bool RemoveById(int id)
		{
			return RemoveItemBy(IDCompareFunc, id);
		}

		private bool IDCompareFunc(DataType data, int value)
		{
			return (data.ID == value);
		}
		#endregion

		#region Generic CRUD
		public bool ContainsItemBy<T>(ParameterCompareFunc<T> compareFunc, T value)
		{
			for(int x = 0; x < m_Items.Count; x++)
			{
				if(compareFunc(m_Items[x], value))
				{
					return true;
				}
			}
			return false;
		}

		public DataType GetItemBy<T>(ParameterCompareFunc<T> compareFunc, T value)
		{
			for(int x = 0; x < m_Items.Count; x++)
			{
				if(compareFunc(m_Items[x], value))
				{
					return m_Items[x];
				}
			}
			return null;
		}

		public List<DataType> GetItemsBy<T>(ParameterCompareFunc<T> compareFunc, T value)
		{
			List<DataType> validItems = new List<DataType>();
			for(int x = 0; x < m_Items.Count; x++)
			{
				if(compareFunc(m_Items[x], value))
				{
					validItems.Add(m_Items[x]);
				}
			}
			return validItems;
		}

		public bool RemoveItemBy<T>(ParameterCompareFunc<T> compareFunc, T value)
		{
			for(int x = 0; x < m_Items.Count; x++)
			{
				if(compareFunc(m_Items[x], value))
				{
					m_IdProvider.ReleaseId(m_Items[x].ID);
					m_Items[x].ID = 0;
					m_Items.RemoveAt(x);
					return true;
				}
			}
			return false;
		}

		private bool CompareFunc(DataType type, DataType value)
		{
			return (type == value);
		}
		#endregion
	}
}
