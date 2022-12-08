using UnityEngine;

using System.Collections;
using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor {
	public class CountAttributeProcessor : BaseAttributeProcessor<CountAttribute> {
		protected override void ProcessValueInternal(CountAttribute attribute, object obj, FieldInfo fieldInfo,
			Object context) {
			var valueRaw = fieldInfo.GetValue(obj);
			if ( !(valueRaw is ICollection collection) ) {
				return;
			}

			if ( (attribute.MinCount > 0) && (collection.Count < attribute.MinCount) ) {
				Debug.LogErrorFormat(context,
					"Collection '{0}' has less than '{1}' elements", fieldInfo.Name,
					attribute.MinCount);
			}

			if ( (attribute.MaxCount > 0) && (collection.Count > attribute.MaxCount) ) {
				Debug.LogErrorFormat(context,
					"Collection '{0}' has more than '{1}' elements", fieldInfo.Name,
					attribute.MaxCount);
			}

			if ( (attribute.ExactCount > 0) && (collection.Count != attribute.ExactCount) ) {
				Debug.LogErrorFormat(context,
					"Collection '{0}' must have '{1}' elements", fieldInfo.Name,
					attribute.ExactCount);
			}
			else {
				Debug.LogErrorFormat(context,
					"Field '{0}' has invalid type for attribute Count", fieldInfo.Name);
			}
		}
	}
}