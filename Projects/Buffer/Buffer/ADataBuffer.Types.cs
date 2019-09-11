using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Buffer
{
    public partial class ADataBuffer
    {
		#region Char
		public abstract ADataBuffer Write(char data);
		public abstract char ReadChar(); 
 
		public ADataBuffer Write(char[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<char> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<char> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadChar());
			}
		}

		public int Read(char[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadChar();
			}
			return length;
		}

		public char[] ReadCharArray()
		{
			int length = ReadInt();
			char[] arr = new char[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadChar();
			}
			return arr;
		}
		#endregion 

		#region Bool
		public abstract ADataBuffer Write(bool data);
		public abstract bool ReadBool(); 
 
		public ADataBuffer Write(bool[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<bool> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<bool> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadBool());
			}
		}

		public int Read(bool[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadBool();
			}
			return length;
		}

		public bool[] ReadBoolArray()
		{
			int length = ReadInt();
			bool[] arr = new bool[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadBool();
			}
			return arr;
		}
		#endregion 

		#region Byte
		public abstract ADataBuffer Write(byte data);
		public abstract byte ReadByte(); 
 
		public ADataBuffer Write(byte[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<byte> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<byte> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadByte());
			}
		}

		public int Read(byte[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadByte();
			}
			return length;
		}

		public byte[] ReadByteArray()
		{
			int length = ReadInt();
			byte[] arr = new byte[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadByte();
			}
			return arr;
		}
		#endregion 

		#region Short
		public abstract ADataBuffer Write(short data);
		public abstract short ReadShort(); 
 
		public ADataBuffer Write(short[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<short> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<short> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadShort());
			}
		}

		public int Read(short[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadShort();
			}
			return length;
		}

		public short[] ReadShortArray()
		{
			int length = ReadInt();
			short[] arr = new short[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadShort();
			}
			return arr;
		}
		#endregion 

		#region UShort
		public abstract ADataBuffer Write(ushort data);
		public abstract ushort ReadUShort(); 
 
		public ADataBuffer Write(ushort[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<ushort> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<ushort> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadUShort());
			}
		}

		public int Read(ushort[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadUShort();
			}
			return length;
		}

		public ushort[] ReadUShortArray()
		{
			int length = ReadInt();
			ushort[] arr = new ushort[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadUShort();
			}
			return arr;
		}
		#endregion 

		#region Int
		public abstract ADataBuffer Write(int data);
		public abstract int ReadInt(); 
 
		public ADataBuffer Write(int[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<int> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<int> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadInt());
			}
		}

		public int Read(int[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadInt();
			}
			return length;
		}

		public int[] ReadIntArray()
		{
			int length = ReadInt();
			int[] arr = new int[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadInt();
			}
			return arr;
		}
		#endregion 

		#region UInt
		public abstract ADataBuffer Write(uint data);
		public abstract uint ReadUInt(); 
 
		public ADataBuffer Write(uint[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<uint> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<uint> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadUInt());
			}
		}

		public int Read(uint[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadUInt();
			}
			return length;
		}

		public uint[] ReadUIntArray()
		{
			int length = ReadInt();
			uint[] arr = new uint[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadUInt();
			}
			return arr;
		}
		#endregion 

		#region String
		public abstract ADataBuffer Write(string data);
		public abstract string ReadString(); 
 
		public ADataBuffer Write(string[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public ADataBuffer Write(List<string> list)
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public void Read(List<string> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadString());
			}
		}

		public int Read(string[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadString();
			}
			return length;
		}

		public string[] ReadStringArray()
		{
			int length = ReadInt();
			string[] arr = new string[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadString();
			}
			return arr;
		}
		#endregion 

    }
}
