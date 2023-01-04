namespace GameComponentAttributes.Attributes {
	public sealed class NonEmptyCollectionAttribute : BaseGameComponentAttribute {
		public readonly bool AllowNullNodes;
		
		public NonEmptyCollectionAttribute() : this(false, true) { }

		public NonEmptyCollectionAttribute(bool allowNullNodes = false, bool checkInPrefab = true) : base(checkInPrefab) {
			AllowNullNodes = allowNullNodes;
		}
	}
}