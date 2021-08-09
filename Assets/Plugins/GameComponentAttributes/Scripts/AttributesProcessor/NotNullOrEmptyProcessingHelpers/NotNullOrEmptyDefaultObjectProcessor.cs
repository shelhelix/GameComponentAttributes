using UnityEngine;

using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public class NotNullOrEmptyDefaultObjectProcessor : BaseNotNullOrEmptyTypeProcessor<object> {
		protected override void CheckObjectInternal(NotNullOrEmptyAttribute attribute, Object context, object value, FieldInfo fieldInfo) {
			if ( value == null ) {
				Debug.LogErrorFormat(context, "'{0}' is null", fieldInfo.Name);
			}
		}
	}
}