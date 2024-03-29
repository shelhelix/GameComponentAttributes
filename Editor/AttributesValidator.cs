﻿using UnityEngine;

using System.Collections.Generic;
using System.Reflection;

using GameComponentAttributes.Attributes;
using GameComponentAttributes.AttributesProcessor;

using Object = UnityEngine.Object;
 
namespace GameComponentAttributes {
	public static class AttributesValidator {
		static readonly List<IAttributeProcessor> Processors = new() {
			new NotNullReferenceAttributeProcessor(),
			new NotEmptyCollectionAttributeProcessor(),
			new CountAttributeProcessor(),
			new EnumNotEqualsProcessor(),
		};


		public static void CheckAttributes(object rawObj, Object context = null) {
			if ( !context ) {
				context = rawObj as Object;
			}
			var isPrefab = false;
			if ( context is MonoBehaviour mb ) {
				isPrefab = string.IsNullOrEmpty(mb.gameObject.scene.name) || UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage();
			}
			var fields = rawObj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
			foreach ( var fieldInfo in fields ) {
				foreach ( var attributeRaw in fieldInfo.GetCustomAttributes(true) ) {
					if ( isPrefab && (attributeRaw is BaseGameComponentAttribute bgca) && !bgca.CheckInPrefab ) {
						continue;
					}
					var processor = Processors.Find(x => x.IsSuitableProcessor(attributeRaw));
					processor?.ProcessValue(attributeRaw, rawObj, fieldInfo, context);					
				}
			}
		}
	}
}