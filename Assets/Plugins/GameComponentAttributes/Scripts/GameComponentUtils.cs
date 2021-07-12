using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Experimental.SceneManagement;
#endif


using System.Collections.Generic;
using System.Reflection;

using GameComponentAttributes.Attributes;
using GameComponentAttributes.AttributesProcessor;

using Object = UnityEngine.Object;
 
namespace GameComponentAttributes {
	public static class GameComponentUtils {
		static readonly List<IAttributeProcessor> _processors = new List<IAttributeProcessor> {
			new NotNullAttributeProcessor(),
			new NotNullOrEmptyAttributeProcessor(),
			new CountAttributeProcessor(),
			new EnumNotEqualsProcessor()
		};


		public static void CheckAttributes(object rawObj, Object context = null) {
#if UNITY_EDITOR
			if ( !context ) {
				context = rawObj as Object;
			}
			var isPrefab = false;
			if ( context is MonoBehaviour mb ) {
				isPrefab = string.IsNullOrEmpty(mb.gameObject.scene.name) ||
				           (PrefabStageUtility.GetCurrentPrefabStage() != null);
			}
			foreach ( var fieldInfo in rawObj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance) ) {
				foreach ( var attributeRaw in fieldInfo.GetCustomAttributes(true) ) {
					if ( isPrefab && (attributeRaw is BaseGameComponentAttribute bgca) && !bgca.CheckPrefab ) {
						continue;
					}
					var processor = _processors.Find(x => x.IsSuitableProcessor(attributeRaw));
					processor?.ProcessValue(attributeRaw, rawObj, fieldInfo, context);					
				}
			}
#endif
		}
	}
}