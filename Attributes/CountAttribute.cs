namespace GameComponentAttributes.Attributes {
	public sealed class CountAttribute : BaseGameComponentAttribute {
		public readonly int MinCount   = -1;
		public readonly int MaxCount   = -1;
		public readonly int ExactCount = -1;

		public CountAttribute(int minCount, int maxCount, bool checkInPrefab = true) : base(checkInPrefab) {
			MinCount = minCount;
			MaxCount = maxCount;
		}

		public CountAttribute(int exactCount, bool checkInPrefab = true) : base(checkInPrefab) {
			ExactCount = exactCount;
		}
	}
}