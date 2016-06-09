using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.BitConverter;

namespace System.IO
{
    public static class BigEndianReader
    {
        public static int ReadInt32BE(this BinaryReader reader) =>
            ToInt32(reader.ReadValue(4), 0);

        public static uint ReadUInt32BE(this BinaryReader reader) =>
            ToUInt32(reader.ReadValue(4), 0);

        public static short ReadInt16BE(this BinaryReader reader) =>
            ToInt16(reader.ReadValue(2), 0);

        public static ushort ReadUInt16BE(this BinaryReader reader) =>
            ToUInt16(reader.ReadValue(2), 0);

        public static long ReadInt64BE(this BinaryReader reader) =>
            ToInt64(reader.ReadValue(8), 0);

        public static float ReadSingleBE(this BinaryReader reader) =>
            ToSingle(reader.ReadValue(4), 0);

        public static double ReadDoubleBE(this BinaryReader reader) =>
            ToDouble(reader.ReadValue(8), 0);

        static byte[] ReadValue(this BinaryReader reader, int size)
        {
            var bytes = reader.ReadBytes(size);
            if (IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
    }
}
