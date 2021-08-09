using System.Collections.Generic;
using System.Reflection;

using GameComponentAttributes.Attributes;
using GameComponentAttributes.AttributesProcessor.NotNullOrEmptyProcessingHelpers;

using Object = UnityEngine.Object;

namespace GameComponentAttributes.AttributesProcessor {
	public class NotNullOrEmptyAttributeProcessor : BaseAttributeProcessor<NotNullOrEmptyAttribute> {
		readonly List<INotNullOrEmptyTypeProcessor> _typeProcessors = new List<INotNullOrEmptyTypeProcessor> {
			new NotNullOrEmptyICollectionProcessor(),
			new NotNullOrEmptyUnityObjectProcessor(),
			new NotNullOrEmptyStringProcessor(),
			// fallback processor
			new NotNullOrEmptyDefaultObjectProcessor()
		};

		INotNullOrEmptyTypeProcessor _defaultProcessor;

		protected override void ProcessValueInternal(NotNullOrEmptyAttribute attribute, object obj, FieldInfo fieldInfo, Object context) {
			var valueRaw  = fieldInfo.GetValue(obj);
			var processor = _typeProcessors.Find(x => x.IsSuitableProcessor(x));
			processor?.CheckObject(attribute, context, valueRaw, fieldInfo);
		}
	}
}