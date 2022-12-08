using UnityEngine;

using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor {
	public class NotNullAttributeProcessor : BaseAttributeProcessor<NotNullAttribute> {
		protected override void ProcessValueInternal(NotNullAttribute attribute, object obj, FieldInfo fieldInfo, Object context) {
			var valueRaw = fieldInfo.GetValue(obj);
			if ( (valueRaw == null) || ((valueRaw is Object unityObj) && !unityObj) ) {
				Debug.LogErrorFormat(context, "{0} is null in object {1}", fieldInfo.Name, context);
			} ;
		}
	}
}