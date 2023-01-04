using System;

namespace GameComponentAttributes.Attributes {
	[AttributeUsage(AttributeTargets.Field)]
	public class NotNullReferenceAttribute : BaseGameComponentAttribute {
		public NotNullReferenceAttribute() : this(true) { }

		public NotNullReferenceAttribute(bool checkInPrefab = true) : base(checkInPrefab) { }
	}
}