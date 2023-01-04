using System.Collections.Generic;
using System.Reflection;

using GameComponentAttributes.Attributes;
using GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers;

using Object = UnityEngine.Object;

namespace GameComponentAttributes.AttributesProcessor {
	public class NotEmptyCollectionAttributeProcessor : BaseAttributeProcessor<NonEmptyCollectionAttribute> {
		readonly List<INotNullOrEmptyTypeProcessor> _typeProcessors = new() {
			new NotNullOrEmptyICollectionProcessor(),
		};

		INotNullOrEmptyTypeProcessor _defaultProcessor;

		protected override void ProcessValueInternal(NonEmptyCollectionAttribute collectionAttribute, object obj, FieldInfo fieldInfo, Object context) {
			var valueRaw  = fieldInfo.GetValue(obj);
			var processor = _typeProcessors.Find(x => x.IsSuitableProcessor(x));
			processor?.CheckObject(collectionAttribute, context, valueRaw, fieldInfo);
		}
	}
}