using System;

namespace GameComponentAttributes.Attributes {
	[AttributeUsage(AttributeTargets.Field)]
	public class NotNullAttribute : BaseGameComponentAttribute {
		public NotNullAttribute() : this(true) { }

		public NotNullAttribute(bool checkPrefab = true) : base(checkPrefab) { }
	}
}