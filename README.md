## GameComponentAttributes

GameComponentAttributes is a unity plugin for checking field values in your components.

## Installation

### Installing with Unity Package Manager
*(Requires Unity version 2018.3.0b7  or above)*

To install latest version of the plugin use this git link in the unity package manager
```
https://github.com/shelhelix/GameComponentAttributes.git
```

<details><summary>Other ways</summary>

***1. Via Git URL (manually editing json file)***
*(Requires Unity version 2018.3.0b7  or above)*

To install this project as a [Git dependency](https://docs.unity3d.com/Manual/upm-git.html) using the Unity Package Manager,
add the following line to your project's `manifest.json`:

```
"com.ultrashel.gamecomponentattributes": "https://github.com/shelhelix/GameComponentAttributes.git?path=/Assets/Plugins/GameComponentAttributes"
```

You will need to have Git installed and available in your system's PATH.

***2. Manually add sources***

If no source control or package manager is available to you, you can simply copy/paste the source files into your assets folder.
</details>

### Example

```csharp
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

using GameComponentAttributes.Attributes;

namespace ExampleNamespace {
    // All checks perform only in the Editor on a Scene/Prefab save 
    public sealed class ExampleClass : MonoBehaviour {
        // NotNull will check if something is set in the inspector for this field
        [NotNullReference] public Image Background;
    
        // NotNullOrEmpty will check if something set in the inspector for this field and this collection is not empty
        [NonEmptyCollection] public List<Image> Buttons;    
    
        // Count will check that this collection has exactly 5 elements
        [Count(5)] public List<Texture> Textures; 
    
        // Count will check that this collection has from 2 to 4 elements
        [Count(2, 4)] public List<string> Texts; 
    
        // checkInPrefab == false will disable attribute checking in prefabs
        [NotNullReference(checkInPrefab: false)] public Sprite Sprite;
    }
}
```
