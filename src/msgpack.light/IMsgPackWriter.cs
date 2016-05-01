using System;

namespace MsgPack
{
    public interface IMsgPackWriter : IDisposable
    {
        void Write(DataTypes dataType);

        void Write(byte value);

        void Write(byte[] array);

        void WriteArrayHeader(uint length);

        void WriteMapHeaderAndLength(uint length);
    }
}
