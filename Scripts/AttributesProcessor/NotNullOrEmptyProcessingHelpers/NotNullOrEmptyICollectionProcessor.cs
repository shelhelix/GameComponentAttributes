using UnityEngine;

using System.Collections;
using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public class NotNullOrEmptyICollectionProcessor : BaseNotNullOrEmptyTypeProcessor<ICollection> {
		protected override void CheckObjectInternal(NotNullOrEmptyAttribute attribute, Object context, ICollection value, FieldInfo fieldInfo) {
			if ( !(value is ICollection val) ) {
				return;
			}
			if ( val.Count == 0 ) {
				Debug.LogErrorFormat(context, "Collection '{0}' is empty", fieldInfo.Name);
			}
			CheckCollectionElements(attribute, val, fieldInfo, context);
		}

		void CheckCollectionElements(NotNullOrEmptyAttribute attribute, ICollection collection, FieldInfo fieldInfo, Object context) {
			if (attribute.AllowNullNodes) {
				return;
			}
			foreach ( var node in collection ) {
				if ( node is Object unityObj ) {
					if ( !unityObj ) {
						Debug.LogErrorFormat(context, "Collection '{0}' has null elements", fieldInfo.Name);
						break;
					}
				} else if ( node == null ) {
					Debug.LogErrorFormat(context, "Collection '{0}' has null elements", fieldInfo.Name);
					break;
				}
			}
		}
	}
}