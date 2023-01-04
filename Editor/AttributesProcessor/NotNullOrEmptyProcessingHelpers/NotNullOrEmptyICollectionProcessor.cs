using UnityEngine;

using System.Collections;
using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public class NotNullOrEmptyICollectionProcessor : BaseNotNullOrEmptyTypeProcessor<ICollection> {
		protected override void CheckObjectInternal(NonEmptyCollectionAttribute collectionAttribute, Object context, ICollection value, FieldInfo fieldInfo) {
			if ( value == null ) {
				return;
			}
			if ( value.Count == 0 ) {
				Debug.LogErrorFormat(context, "Collection '{0}' is empty", fieldInfo.Name);
				return;
			}
			CheckCollectionElements(collectionAttribute, value, fieldInfo, context);
		}

		void CheckCollectionElements(NonEmptyCollectionAttribute collectionAttribute, ICollection collection, FieldInfo fieldInfo, Object context) {
			if (collectionAttribute.AllowNullNodes) {
				return;
			}
			foreach ( var node in collection ) {
				if ( (node is Object unityObj) && !unityObj ) {
					Debug.LogErrorFormat(context, "Collection '{0}' has null unity elements", fieldInfo.Name);
					break;
				}
				if ( node == null ) {
					Debug.LogErrorFormat(context, "Collection '{0}' has null elements", fieldInfo.Name);
					break;
				}
			}
		}
	}
}