using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProceduralLevel.Common.Parsing.Template
{
	public class GetterEvaluator: AEvaluator
	{
		public readonly string Param;

		public GetterEvaluator(string param) : base(EEvaluatorType.Getter)
		{
			Param = param;
		}

		public override object Evaluate(object data, Dictionary<string, object> scope)
		{
			object result;
			if(Param != null && Param.Length > 0)
			{
				if(Param == "this")
				{
					result = data;
				}
				else
				{
					Dictionary<string, object> dict = data as Dictionary<string, object>;
					if(dict != null)
					{
						dict.TryGetValue(Param, out result);
					}
					else
					{
						Type type = data.GetType();
						FieldInfo field;
#if NET_CORE
						field = type.GetTypeInfo().GetField(Param);
#else
						field = type.GetField(Param);
#endif
						if(field != null)
						{
							result = field.GetValue(data);
						}
						else
						{
							scope.TryGetValue(Param, out result);
						}
					}
				}
			}
			else
			{
				result = data;
			}
			if(result != null)
			{
				return result;
			}
			else
			{
				return string.Format("({0}: NULL)", Param);
			}
		}

		public override string ToString()
		{
			return Param;
		}
	}
}
