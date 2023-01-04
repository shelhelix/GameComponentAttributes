using UnityEngine;

using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor {
	public class NotNullReferenceAttributeProcessor : BaseAttributeProcessor<NotNullReferenceAttribute> {
		protected override void ProcessValueInternal(NotNullReferenceAttribute attribute, object obj, FieldInfo fieldInfo, Object context) {
			var valueRaw = fieldInfo.GetValue(obj);
			if ( (valueRaw == null) || ((valueRaw is Object unityObj) && !unityObj) ) {
				Debug.LogErrorFormat(context, "{0} is null in object {1}", fieldInfo.Name, context);
			} ;
		}
	}
}