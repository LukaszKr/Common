using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Data
{
	public class NamedDataCollection<DataType>: DataCollection<DataType> where DataType : NamedDataItem
	{
		public NamedDataCollection(BaseIdProvider idProvider) : base(idProvider)
		{

		}

		#region Name CRUD
		public DataType GetByName(string name)
		{
			return GetItemBy(NameComparerFunc, name);
		}

		public List<DataType> FindByName(string name)
		{
			return GetItemsBy(FindNameComparerFunc, name);
		}

		private bool NameComparerFunc(DataType data, string value)
		{
			return data.Name.Equals(value, StringComparison.OrdinalIgnoreCase);
		}

		private bool FindNameComparerFunc(DataType data, string value)
		{
			return data.Name.StartsWith(value, StringComparison.OrdinalIgnoreCase);
		}
		#endregion
	}
}
