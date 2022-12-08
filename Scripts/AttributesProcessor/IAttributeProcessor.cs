using UnityEngine;

using System.Reflection;

namespace GameComponentAttributes.AttributesProcessor {
	public interface IAttributeProcessor {
		bool IsSuitableProcessor(object attribute);

		void ProcessValue(object attribute, object obj, FieldInfo fieldInfo, Object context);
	}
}