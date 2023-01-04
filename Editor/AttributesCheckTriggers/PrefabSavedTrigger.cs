using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace GameComponentAttributes.AttributesCheckTriggers {
    public class PrefabSavedTrigger {
        [InitializeOnLoadMethod]
        static void Initialize() {
            PrefabStage.prefabSaved -= OnSave;
            PrefabStage.prefabSaved += OnSave;
        }

        static void OnSave(GameObject gameObject) {
            if ( !gameObject ) {
                return;
            }
            var components = gameObject.GetComponentsInChildren<MonoBehaviour>(true);
            foreach ( var component in components ) {
                GameComponentUtils.CheckAttributes(component);
            }
        }
    }
}