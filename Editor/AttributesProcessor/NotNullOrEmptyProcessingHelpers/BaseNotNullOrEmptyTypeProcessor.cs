using UnityEngine;

using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public abstract class BaseNotNullOrEmptyTypeProcessor<T> : INotNullOrEmptyTypeProcessor where T : class {
		public bool IsSuitableProcessor(object value) => value is T;

		public void CheckObject(NonEmptyCollectionAttribute collectionAttribute, Object context, object value, FieldInfo fieldInfo) {
			var castedValue = value as T;
			CheckObjectInternal(collectionAttribute, context, castedValue, fieldInfo);
		}

		protected abstract void CheckObjectInternal(NonEmptyCollectionAttribute collectionAttribute, Object context, T value, FieldInfo fieldInfo);
	}
}