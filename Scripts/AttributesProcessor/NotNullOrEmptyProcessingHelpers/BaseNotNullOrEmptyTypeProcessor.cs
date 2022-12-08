using UnityEngine;

using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public abstract class BaseNotNullOrEmptyTypeProcessor<T> : INotNullOrEmptyTypeProcessor where T : class {
		public bool IsSuitableProcessor(object value) {
			return value is T;
		}

		public void CheckObject(NotNullOrEmptyAttribute attribute, Object context, object value, FieldInfo fieldInfo) {
			var castedValue = value as T;
			CheckObjectInternal(attribute, context, castedValue, fieldInfo);
		}

		protected abstract void CheckObjectInternal(NotNullOrEmptyAttribute attribute, Object context, T value, FieldInfo fieldInfo);
	}
}