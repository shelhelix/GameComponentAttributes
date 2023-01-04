using GameComponentAttributes;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MG.Utils.CommonValidator.Editor.ValidateTriggers {
	public static class SceneSavedValidateTrigger {
		[InitializeOnLoadMethod]
		static void Initialize() {
			EditorSceneManager.sceneSaved -= OnSave;
			EditorSceneManager.sceneSaved += OnSave;
		}

		static void OnSave(Scene scene) {
			var roots = scene.GetRootGameObjects();
			foreach ( var root in roots ) {
				var components = root.GetComponentsInChildren<MonoBehaviour>(true);
				foreach ( var component in components ) {
					GameComponentUtils.CheckAttributes(component);
				}
			}
		}
	}
}
