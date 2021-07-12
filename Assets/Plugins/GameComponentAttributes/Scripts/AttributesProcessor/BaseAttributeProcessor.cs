using UnityEngine;

using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor {
	public abstract class BaseAttributeProcessor<T> : IAttributeProcessor where T : BaseGameComponentAttribute {

		public bool IsSuitableProcessor(object attribute) {
			return attribute is T;
		}

		public void ProcessValue(object attribute, object obj, FieldInfo fieldInfo, Object context) {
			var attr = attribute as T;
			ProcessValueInternal(attr, obj, fieldInfo, context);
		}

		protected abstract void ProcessValueInternal(T attribute, object obj, FieldInfo fieldInfo, Object context);
	}
}