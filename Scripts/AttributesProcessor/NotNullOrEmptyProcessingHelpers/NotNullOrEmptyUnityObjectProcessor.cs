using System.Reflection;
using GameComponentAttributes.Attributes;
using UnityEngine;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public class NotNullOrEmptyUnityObjectProcessor : BaseNotNullOrEmptyTypeProcessor<Object> {
		protected override void CheckObjectInternal(NotNullOrEmptyAttribute attribute, Object context, Object value, FieldInfo fieldInfo) {
			if ( !value ) {
				Debug.LogErrorFormat(context, "{0} is null in object {1}", fieldInfo.Name, context);
			}
		}
	}
}