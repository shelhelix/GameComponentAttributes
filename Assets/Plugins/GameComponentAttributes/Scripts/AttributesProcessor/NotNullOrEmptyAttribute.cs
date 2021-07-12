using UnityEngine;

using System.Collections;
using System.Reflection;

using GameComponentAttributes.Attributes;

namespace GameComponentAttributes.AttributesProcessor {
	public class NotNullOrEmptyAttributeProcessor : BaseAttributeProcessor<NotNullOrEmptyAttribute> {
		protected override void ProcessValueInternal(NotNullOrEmptyAttribute attribute, object obj, FieldInfo fieldInfo, Object context) {
			var valueRaw = fieldInfo.GetValue(obj);
			switch ( valueRaw ) {
				case ICollection collection: {
					if ( collection.Count == 0 ) {
						Debug.LogErrorFormat(context, "Collection '{0}' is empty",
							fieldInfo.Name);
					}
					if ( !attribute.AllowNullNodes ) {
						foreach ( var node in collection ) {
							if ( node is Object unityObj ) {
								if ( !unityObj ) {
									Debug.LogErrorFormat(context,
										"Collection '{0}' has null elements", fieldInfo.Name);
									break;
								}
							} else if ( node == null ) {
								Debug.LogErrorFormat(context,
									"Collection '{0}' has null elements", fieldInfo.Name);
								break;
							}
						}
					}
					break;
				}
				case Object valueObj: {
					if ( !valueObj ) {
						Debug.LogErrorFormat(context, "{0} is null in object {1}", fieldInfo.Name, context);
					}
					break;
				}
				case string str: {
					if ( string.IsNullOrEmpty(str) ) {
						Debug.LogErrorFormat(context, "'{0}' is null or empty",
							fieldInfo.Name);
					}
					break;
				}
				default: {
					if ( valueRaw == null ) {
						Debug.LogErrorFormat(context, "'{0}' is null",
							fieldInfo.Name);
					}
					break;
				}
			}
		}
	}
}