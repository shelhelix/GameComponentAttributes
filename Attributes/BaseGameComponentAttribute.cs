using System;

namespace GameComponentAttributes.Attributes {
	public abstract class BaseGameComponentAttribute : Attribute {
		public readonly bool CheckInPrefab;

		protected BaseGameComponentAttribute(bool checkInPrefab) {
			CheckInPrefab = checkInPrefab;
		}
	}
}