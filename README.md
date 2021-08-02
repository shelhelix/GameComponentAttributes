## GameComponentAttributes

GameComponentAttributes is a unity plugin for checking field values in your components.

## Installation

<details><summary>Instructions</summary>

### Installing with Unity Package Manager
***Via Git URL in Package manager UI***
*(Requires Unity version 2018.3.0b7  or above)*

git link for the unity package manager UI
```
https://github.com/shelhelix/GameComponentAttributes.git?path=/Assets/Plugins/GameComponentAttributes 
```

How to install packages via the package manager:
https://docs.unity3d.com/Manual/upm-ui-giturl.html


***Via Git URL manually***
*(Requires Unity version 2018.3.0b7  or above)*

To install this project as a [Git dependency](https://docs.unity3d.com/Manual/upm-git.html) using the Unity Package Manager,
add the following line to your project's `manifest.json`:

```
"com.gamecomponentattributes": "https://github.com/shelhelix/GameComponentAttributes.git?path=/Assets/Plugins/GameComponentAttributes"
```

You will need to have Git installed and available in your system's PATH.

### Installing 'the old way'
If no source control or package manager is available to you, you can simply copy/paste the source files into your assets folder.

</details>

### Example

```csharp
using UnityEngine;
using UnityEngine.UI;

using System.Collections.Generic;

using GameComponentAttributes;
using GameComponentAttributes.Attributes;

namespace ExampleNamespace {
	// GameComponent is just a MonoBehaviour with some code for checking fields with attributes
	// All checks execute in Awake and OnValidate methods 
	public sealed class ExampleClass : GameComponent {
	    // NotNull will check if something is set in the inspector for this field
	    [NotNull] public Image Background;
	    
	    // NotNullOrEmpty will check if something set in the inspector for this field and this collection is not empty
	    [NotNullOrEmpty] public List<Image> Buttons;    
	    
	    // Count will check that this collection has exactly 5 elements
	    [Count(5)] public List<Texture> Textures; 
	    
	    // Count will check that this collection has from 2 to 4 elements
	    [Count(2, 4)] public List<string> Texts; 
	    
	    // checkPrefab == false will disable attribute checking in prefabs
	    [NotNull(checkPrefab: false)] public Sprite Sprite;
	}
}

```