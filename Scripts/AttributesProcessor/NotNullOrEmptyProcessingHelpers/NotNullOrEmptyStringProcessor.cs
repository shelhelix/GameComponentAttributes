using UnityEngine;

using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public class NotNullOrEmptyStringProcessor : BaseNotNullOrEmptyTypeProcessor<string> {
		protected override void CheckObjectInternal(NotNullOrEmptyAttribute attribute, Object context, string value, FieldInfo fieldInfo) {
			if ( string.IsNullOrEmpty(value) ) {
				Debug.LogErrorFormat(context, "'{0}' is null or empty", fieldInfo.Name);
			}
		}
	}
}