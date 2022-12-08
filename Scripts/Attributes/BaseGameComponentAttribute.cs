using System;

namespace GameComponentAttributes.Attributes {
	public abstract class BaseGameComponentAttribute : Attribute {
		public readonly bool CheckPrefab;

		protected BaseGameComponentAttribute(bool checkPrefab) {
			CheckPrefab = checkPrefab;
		}
	}
}