using System;
using System.IO;

namespace MsgPack.Light
{
    public interface IMsgPackReader : IDisposable
    {
        DataTypes ReadDataType();

        byte ReadByte();

        void ReadBytes(byte[] buffer);

        void Seek(int offset, SeekOrigin origin);

        uint? ReadArrayLength();

        uint? ReadMapLength();
    }
}