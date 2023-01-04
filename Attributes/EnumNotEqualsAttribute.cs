namespace GameComponentAttributes.Attributes {
	public class EnumNotEqualsAttribute : BaseGameComponentAttribute {
		public readonly int EnumIntValue;
		
		public EnumNotEqualsAttribute(int enumIntValue, bool checkInPrefab = true) : base(checkInPrefab) {
			EnumIntValue = enumIntValue;
		}
	}
}