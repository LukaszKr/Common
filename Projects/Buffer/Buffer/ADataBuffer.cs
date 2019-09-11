using System.Collections.Generic;

namespace ProceduralLevel.Common.Buffer
{
	public abstract partial class ADataBuffer
	{
		public abstract int Length { get; }

		public abstract int ToBytes(byte[] bytes, int offset = 0);
		public abstract void FromBytes(byte[] bytes);

		public abstract void Reset();

		public abstract int UnreadCount { get; }

		#region Serialize
		public ADataBuffer Write(IBufferSerialized serializable)
		{
			serializable.ToDataBuffer(this);
			return this;
		}

		public ADataBuffer Write(IBufferSerialized[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write<TEntry>(List<TEntry> list)
			where TEntry: IBufferSerialized
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}
		#endregion

		#region Deserialize
		public void Read(IBufferDeserialized serializable)
		{
			serializable.FromDataBuffer(this);
		}

		public void Read<TEntry>(List<TEntry> list, bool append = false)
			where TEntry : IBufferDeserialized, new()
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry);
				list.Add(entry);
			}
		}

		public int Read<TEntry>(TEntry[] arr, int offset = 0)
			where TEntry : IBufferDeserialized, new()
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry);
				arr[x+offset] = entry;
			}
			return length;
		}

		public TEntry[] ReadArray<TEntry>()
			where TEntry : IBufferDeserialized, new()
		{
			int length = ReadInt();
			TEntry[] arr = new TEntry[length];
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry);
				arr[x] = entry;
			}
			return arr;
		}

		public void Read<TData>(IBufferDeserialized<TData> serializable, TData data)
		{
			serializable.FromDataBuffer(this, data);
		}

		public void Read<TEntry, TData>(List<TEntry> list, TData data, bool append = false)
			where TEntry : IBufferDeserialized<TData>, new()
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry, data);
				list.Add(entry);
			}
		}

		public int Read<TEntry, TData>(TEntry[] arr, TData data, int offset = 0)
			where TEntry : IBufferDeserialized<TData>, new()
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry, data);
				arr[x+offset] = entry;
			}
			return length;
		}

		public TEntry[] ReadArray<TEntry, TData>(TData data)
			where TEntry : IBufferDeserialized<TData>, new()
		{
			int length = ReadInt();
			TEntry[] arr = new TEntry[length];
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry, data);
				arr[x] = entry;
			}
			return arr;
		}
		#endregion

		public override string ToString()
		{
			return string.Format("[Length: {0}]", Length);
		}
	}
}
