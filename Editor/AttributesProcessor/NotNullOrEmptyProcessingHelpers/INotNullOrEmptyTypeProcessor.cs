using System.Reflection;

using GameComponentAttributes.Attributes;

using Object = UnityEngine.Object;

namespace GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers {
	public interface INotNullOrEmptyTypeProcessor {
		bool IsSuitableProcessor(object value);
		void CheckObject(NonEmptyCollectionAttribute collectionAttribute, Object context, object value, FieldInfo fieldInfo);
	}
}