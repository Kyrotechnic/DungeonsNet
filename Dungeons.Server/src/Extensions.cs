using System.Net.Sockets;

namespace Dungeons.Server;

public static class Extensions
{
    public static int ReadVarInt(this NetworkStream stream)
    {
        int value = 0;
        int size = 0;
        int b;

        while ((b = stream.ReadByte() & 0x80) == 0x80)
        {
            value |= (b & 0x7F) << (size++ * 7);

            if (size > 5)
            {
                throw new IOException("VarInt too big. The power is too much");
            }
        }

        return value | ((b & 0x7F) << (size * 7));
    }

    public static byte[] GetVarIntBytes(this int value)
    {
        List<byte> bytes = new List<byte>();

        while ((value & -128) != 0)
        {
            bytes.Add((byte) (value & 127 | 128));
            value = (int) ((uint) value >> 7);
        }

        return bytes.ToArray();
    }
}