using GameComponentAttributes;
using GameComponentAttributes.Attributes;
using UnityEditor;
using UnityEngine;

namespace MG.Utils.CommonValidator.Editor.ValidateTriggers {
	[CustomPropertyDrawer(typeof(BaseGameComponentAttribute), true)]
	public class PropertyDrawerValidateTrigger : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginChangeCheck();
			EditorGUI.PropertyField(position, property, label, true);
			if ( EditorGUI.EndChangeCheck() ) {
				AttributesValidator.CheckAttributes(property.serializedObject);
			}
		}
 
		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => EditorGUI.GetPropertyHeight(property);
	}
}

