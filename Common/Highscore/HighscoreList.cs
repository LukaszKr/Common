using ProceduralLevel.Common.Serialization;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Highscore
{
	public class HighscoreList: ISerializable
    {
		public EOrder Order { get; private set; }
		public int Limit { get; private set; }
		public List<HighscoreEntry> Entries { get; private set; }

		public HighscoreList(IDeserializer deserializer)
		{
			Deserialize(deserializer);
		}

		public HighscoreList(int limit = 0, EOrder order = EOrder.Desc)
		{
			Limit = limit;
			Order = order;
			Entries = new List<HighscoreEntry>();
		}

		public void Deserialize(IDeserializer deserializer)
		{
			Limit = deserializer.ReadInt();
			Order = (EOrder)deserializer.ReadInt();

			int count = deserializer.ReadInt();
			Entries = new List<HighscoreEntry>(count);
			for(int x = 0; x < count; x++)
			{
				Entries.Add(new HighscoreEntry(deserializer));
			}
		}

		public void Serialize(ISerializer serializer)
		{
			serializer.Write(Limit);
			serializer.Write((int)Order);

			serializer.Write(Entries.Count);
			for(int x = 0; x < Entries.Count; x++)
			{
				serializer.Write(Entries[x]);
			}
		}

		public void AddEntry(HighscoreEntry entry)
		{
			bool inserted = false;
			if(Order == EOrder.Desc)
			{
				for(int x = 0; x < Entries.Count; x++)
				{
					if(Entries[x].Value < entry.Value)
					{
						Entries.Insert(x, entry);
						inserted = true;
						break;
					}
				}
				if(!inserted)
				{
					Entries.Add(entry);
				}
			}
			else
			{
				for(int x = Entries.Count-1; x > 0; x--)
				{
					if(Entries[x].Value > entry.Value)
					{
						Entries.Insert(x-1, entry);
						inserted = true;
						break;
					}
				}
				if(!inserted)
				{
					Entries.Insert(0, entry);
				}
			}

			if(Limit > 0 && Entries.Count > Limit)
			{
				Entries.RemoveAt(Entries.Count-1);
			}
		}
	}
}
