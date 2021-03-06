using System;

using Shouldly;

using Xunit;

namespace ProGaudi.MsgPack.Light.Tests.Writer
{
    public class Nullable
    {
        [Fact]
        public void WriteNullAsNullableBool()
        {
            MsgPackSerializer.Serialize(default(bool?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(bool?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }
        [Fact]
        public void WriteNullAsNullableFloat()
        {
            MsgPackSerializer.Serialize(default(float?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(float?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableDouble()
        {
            MsgPackSerializer.Serialize(default(double?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(double?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableByte()
        {
            MsgPackSerializer.Serialize(default(byte?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(byte?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableSbyte()
        {
            MsgPackSerializer.Serialize(default(sbyte?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(sbyte?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableShort()
        {
            MsgPackSerializer.Serialize(default(short?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(short?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableUshort()
        {
            MsgPackSerializer.Serialize(default(ushort?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(ushort?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableInt()
        {
            MsgPackSerializer.Serialize(default(int?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(int?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableUint()
        {
            MsgPackSerializer.Serialize(default(uint?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(uint?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableLong()
        {
            MsgPackSerializer.Serialize(default(long?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(long?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void WriteNullAsNullableUlong()
        {
            MsgPackSerializer.Serialize(default(ulong?)).ShouldBe(new[] { (byte)DataTypes.Null });
            ((MsgPackToken)default(ulong?)).RawBytes.ShouldBe(new[] { (byte)DataTypes.Null });
        }

        [Fact]
        public void False()
        {
            MsgPackSerializer.Serialize((bool?)false).ShouldBe(new[] { (byte)DataTypes.False });
            ((MsgPackToken)(bool?)false).RawBytes.ShouldBe(new[] { (byte)DataTypes.False });
        }

        [Fact]
        public void True()
        {
            MsgPackSerializer.Serialize((bool?)true).ShouldBe(new[] { (byte)DataTypes.True });
            ((MsgPackToken)(bool?)true).RawBytes.ShouldBe(new[] { (byte)DataTypes.True });
        }

        [Theory]
        [InlineData(0, new byte[] { 203, 0, 0, 0, 0, 0, 0, 0, 0 })]
        [InlineData(1, new byte[] { 203, 63, 240, 0, 0, 0, 0, 0, 0 })]
        [InlineData(-1, new byte[] { 203, 191, 240, 0, 0, 0, 0, 0, 0 })]
        [InlineData(Math.E, new byte[] { 203, 64, 5, 191, 10, 139, 20, 87, 105 })]
        [InlineData(Math.PI, new byte[] { 203, 64, 9, 33, 251, 84, 68, 45, 24 })]
        [InlineData(224, new byte[] { 203, 64, 108, 0, 0, 0, 0, 0, 0 })]
        [InlineData(256, new byte[] { 203, 64, 112, 0, 0, 0, 0, 0, 0 })]
        [InlineData(65530, new byte[] { 203, 64, 239, 255, 64, 0, 0, 0, 0 })]
        [InlineData(65540, new byte[] { 203, 64, 240, 0, 64, 0, 0, 0, 0 })]
        [InlineData(double.NaN, new byte[] { 203, 255, 248, 0, 0, 0, 0, 0, 0 })]
        [InlineData(double.MaxValue, new byte[] { 203, 127, 239, 255, 255, 255, 255, 255, 255 })]
        [InlineData(double.MinValue, new byte[] { 203, 255, 239, 255, 255, 255, 255, 255, 255 })]
        [InlineData(double.PositiveInfinity, new byte[] { 203, 127, 240, 0, 0, 0, 0, 0, 0 })]
        [InlineData(double.NegativeInfinity, new byte[] { 203, 255, 240, 0, 0, 0, 0, 0, 0 })]
        public void TestDouble(double value, byte[] bytes)
        {
            MsgPackSerializer.Serialize((double?)value).ShouldBe(bytes);
            ((MsgPackToken)value).RawBytes.ShouldBe(bytes);
        }

        [Theory]
        [InlineData(0, new byte[] { 202, 0, 0, 0, 0 })]
        [InlineData(1, new byte[] { 202, 63, 128, 0, 0 })]
        [InlineData(-1, new byte[] { 202, 191, 128, 0, 0 })]
        [InlineData(2.71828, new byte[] { 202, 64, 45, 248, 77 })]
        [InlineData(3.14159, new byte[] { 202, 64, 73, 15, 208 })]
        [InlineData(224, new byte[] { 202, 67, 96, 0, 0 })]
        [InlineData(256, new byte[] { 202, 67, 128, 0, 0 })]
        [InlineData(65530, new byte[] { 202, 71, 127, 250, 0 })]
        [InlineData(65540, new byte[] { 202, 71, 128, 2, 0 })]
        [InlineData(float.NaN, new byte[] { 202, 255, 192, 0, 0 })]
        [InlineData(float.MaxValue, new byte[] { 202, 127, 127, 255, 255 })]
        [InlineData(float.MinValue, new byte[] { 202, 255, 127, 255, 255 })]
        [InlineData(float.PositiveInfinity, new byte[] { 202, 127, 128, 0, 0 })]
        [InlineData(float.NegativeInfinity, new byte[] { 202, 255, 128, 0, 0 })]
        public void TestFloat(float value, byte[] bytes)
        {
            MsgPackSerializer.Serialize((float?)value).ShouldBe(bytes);
            ((MsgPackToken)value).RawBytes.ShouldBe(bytes);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        [InlineData(short.MinValue, new byte[] { 209, 128, 0 })]
        [InlineData(short.MaxValue, new byte[] { 205, 127, 0xff })]
        [InlineData(int.MinValue, new byte[] { 210, 128, 0, 0, 0 })]
        [InlineData(int.MaxValue, new byte[] { 206, 127, 0xff, 0xff, 0xff })]
        [InlineData(long.MaxValue, new byte[] { 207, 127, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(long.MinValue, new byte[] { 211, 128, 0, 0, 0, 0, 0, 0, 0 })]
        public void TestSignedLong(long number, byte[] data)
        {
            MsgPackSerializer.Serialize((long?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        [InlineData(short.MinValue, new byte[] { 209, 128, 0 })]
        [InlineData(short.MaxValue, new byte[] { 205, 127, 0xff })]
        [InlineData(int.MinValue, new byte[] { 210, 128, 0, 0, 0 })]
        [InlineData(int.MaxValue, new byte[] { 206, 127, 0xff, 0xff, 0xff })]
        [InlineData(50505, new byte[] { 205, 197, 73 })]
        public void TestSignedInt(int number, byte[] data)
        {
            MsgPackSerializer.Serialize((int?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        [InlineData(short.MinValue, new byte[] { 209, 128, 0 })]
        [InlineData(short.MaxValue, new byte[] { 205, 127, 0xff })]
        public void TestSignedShort(short number, byte[] data)
        {
            MsgPackSerializer.Serialize((short?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(-1, new byte[] { 0xff })]
        [InlineData(sbyte.MinValue, new byte[] { 208, 128 })]
        [InlineData(sbyte.MaxValue, new byte[] { 127 })]
        public void TestSignedByte(sbyte number, byte[] data)
        {
            MsgPackSerializer.Serialize((sbyte?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(byte.MaxValue, new byte[] { 0xcc, 0xff })]
        [InlineData(ushort.MaxValue, new byte[] { 0xcd, 0xff, 0xff })]
        [InlineData(uint.MaxValue, new byte[] { 0xce, 0xff, 0xff, 0xff, 0xff })]
        [InlineData(ulong.MaxValue, new byte[] { 0xcf, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff })]
        public void TetsUnsignedLong(ulong number, byte[] data)
        {
            MsgPackSerializer.Serialize((ulong?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(byte.MaxValue, new byte[] { 0xcc, 0xff })]
        [InlineData(ushort.MaxValue, new byte[] { 0xcd, 0xff, 0xff })]
        [InlineData(uint.MaxValue, new byte[] { 0xce, 0xff, 0xff, 0xff, 0xff })]
        public void TetsUnsignedInt(uint number, byte[] data)
        {
            MsgPackSerializer.Serialize((uint?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(byte.MaxValue, new byte[] { 0xcc, 0xff })]
        [InlineData(ushort.MaxValue, new byte[] { 0xcd, 0xff, 0xff })]
        public void TetsUnsignedShort(ushort number, byte[] data)
        {
            MsgPackSerializer.Serialize((ushort?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

        [Theory]
        [InlineData(0, new byte[] { 0x00 })]
        [InlineData(1, new byte[] { 1 })]
        [InlineData(byte.MaxValue, new byte[] { 0xcc, 0xff })]
        public void TetsUnsignedByte(byte number, byte[] data)
        {
            MsgPackSerializer.Serialize((byte?)number).ShouldBe(data);
            ((MsgPackToken)number).RawBytes.ShouldBe(data);
        }

    }
}
