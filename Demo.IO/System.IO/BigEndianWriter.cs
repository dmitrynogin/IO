using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.BitConverter;


namespace System.IO
{
    public static class BigEndianWriter
    {
        public static void WriteBE(this BinaryWriter writer, int value) =>
            writer.WriteValue(GetBytes(value));

        public static void WriteBE(this BinaryWriter writer, uint value) =>
            writer.WriteValue(GetBytes(value));

        public static void WriteBE(this BinaryWriter writer, short value) =>
            writer.WriteValue(GetBytes(value));

        public static void WriteBE(this BinaryWriter writer, ushort value) =>
            writer.WriteValue(GetBytes(value));

        public static void WriteBE(this BinaryWriter writer, long value) =>
            writer.WriteValue(GetBytes(value));

        public static void WriteBE(this BinaryWriter writer, float value) =>
            writer.WriteValue(GetBytes(value));

        public static void WriteBE(this BinaryWriter writer, double value) =>
            writer.WriteValue(GetBytes(value));
                
        static void WriteValue(this BinaryWriter writer, byte[] bytes)
        {            
            if (IsLittleEndian)
                Array.Reverse(bytes);

            writer.Write(bytes);
        }
    }
}
