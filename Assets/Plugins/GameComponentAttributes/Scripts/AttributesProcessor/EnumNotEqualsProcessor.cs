using System;
using System.Reflection;

using UnityEngine;
using Object = UnityEngine.Object;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor {
	public class EnumNotEqualsProcessor : BaseAttributeProcessor<EnumNotEqualsAttribute> {
		protected override void ProcessValueInternal(EnumNotEqualsAttribute attribute, object obj, FieldInfo fieldInfo, Object context) {
			if ( fieldInfo.FieldType.IsEnum ) {
				if ( (int)fieldInfo.GetValue(obj) == attribute.EnumIntValue ) {
					var valueRaw = fieldInfo.GetValue(obj);
					Debug.LogErrorFormat(context, "Field '{0}' mustn't be equal to '{1}'", fieldInfo.Name, 
					Enum.Parse(fieldInfo.FieldType, valueRaw.ToString()));
				}
			} else {
				Debug.LogErrorFormat(context, "Field '{0}' has invalid type for attribute EnumNotEquals", fieldInfo.Name);
			}
		}
	}
}