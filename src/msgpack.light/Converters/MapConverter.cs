using System;
using System.Collections.Generic;

namespace MsgPack.Light.Converters
{
    internal class MapConverter<TMap, TKey, TValue> : MapConverterBase<TMap, TKey, TValue>
        where TMap : IDictionary<TKey, TValue>
    {
        public override void Write(TMap value, IMsgPackWriter writer, MsgPackContext context)
        {
            if (value == null)
            {
                context.NullConverter.Write(value, writer, context);
                return;
            }

            writer.WriteMapHeaderAndLength((uint) value.Count);
            var keyConverter = context.GetConverter<TKey>();
            var valueConverter = context.GetConverter<TValue>();

            ValidateConverters(keyConverter, valueConverter);

            foreach (var element in value)
            {
                keyConverter.Write(element.Key, writer, context);
                valueConverter.Write(element.Value, writer, context);
            }
        }

        public override TMap Read(IMsgPackReader reader, MsgPackContext context, Func<TMap> creator)
        {
            var length = reader.ReadMapLength();
            return length.HasValue ? ReadMap(reader, context, creator, length.Value) : default(TMap);
        }

        private TMap ReadMap(IMsgPackReader reader, MsgPackContext context, Func<TMap> creator, uint length)
        {
            var keyConverter = context.GetConverter<TKey>();
            var valueConverter = context.GetConverter<TValue>();

            ValidateConverters(keyConverter, valueConverter);

            var map = creator == null ? (TMap) context.GetObjectActivator(typeof(TMap))() : creator();

            for (var i = 0u; i < length; i++)
            {
                var key = keyConverter.Read(reader, context, null);
                var value = valueConverter.Read(reader, context, null);

                map[key] = value;
            }

            return map;
        }
    }
}