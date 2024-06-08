using System.Net;
using System.Text;
using Dungeons.Server.Api;
using Dungeons.Server.Location;

namespace Dungeons.Server.Protocol;

public class ByteBuffer : IBuffer
{
    private List<byte> bytes = new();
    private int pointer = 0;

    public void Set(byte[] bytes)
    {
        this.bytes = bytes.ToList();
    }

    public void SetPointer(int point)
    {
        this.pointer = point;
    }

    public byte[] Read(int count)
    {
        byte[] slice = new byte[count];

        for (int i = 0; i < count; i++)
        {
            slice[i] = bytes[pointer + i];
        }

        pointer += count;

        return slice;
    }

    public byte ReadByte()
    {
        return bytes[pointer++];
    }

    public double ReadDouble()
    {
        byte[] bytes = Read(8);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);

        return BitConverter.ToDouble(bytes);
    }

    public float ReadFloat()
    {
        byte[] bytes = Read(4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        
        return BitConverter.ToSingle(bytes);
    }

    public int ReadInt()
    {
        return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(Read(4)));
    }

    public long ReadLong()
    {
        return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(Read(8)));
    }

    public sbyte ReadSByte()
    {
        return (sbyte) ReadByte();
    }

    public short ReadShort()
    {
        return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(Read(2)));
    }

    public string ReadString()
    {
        int length = ReadVarInt();
        byte[] data = Read(length);

        return Encoding.UTF8.GetString(data);
    }

    public uint ReadUInt()
    {
        byte[] data = Read(4);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        
        return BitConverter.ToUInt32(data);
    }

    public ulong ReadULong()
    {
        byte[] data = Read(8);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        
        return BitConverter.ToUInt64(data);
    }

    public ushort ReadUShort()
    {
        byte[] data = Read(2);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        
        return BitConverter.ToUInt16(data);
    }

    public void Write(byte[] bytes)
    {
        this.bytes.AddRange(bytes);
    }

    public void WriteByte(byte value)
    {
        bytes.Add(value);
    }

    public void WriteDouble(double value)
    {
        byte[] bytes = BitConverter.GetBytes(value);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        
        Write(bytes);
    }

    public void WriteFloat(float value)
    {
        byte[] bytes = BitConverter.GetBytes(value);

        if (BitConverter.IsLittleEndian)
            Array.Reverse(bytes);
        
        Write(bytes);
    }

    public void WriteInt(int value)
    {
        Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value)));
    }

    public void WriteLong(long value)
    {
        Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value)));
    }

    public void WriteSByte(sbyte value)
    {
        WriteByte((byte) value);
    }

    public void WriteShort(short value)
    {
        Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value)));
    }

    public void WriteString(string value)
    {
        WriteVarInt(value.Length);
        Write(Encoding.UTF8.GetBytes(value));
    }

    public void WriteUInt(uint value)
    {
        Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int) value)));
    }

    public void WriteULong(ulong value)
    {
        Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long) value)));
    }

    public void WriteUShort(ushort value)
    {
        Write(BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value)));
    }

    public void WriteVarInt(int value)
    {
        while ((value & -128) != 0)
        {
            bytes.Add((byte) (value & 127 | 128));
            value = (int) (((uint) value) >> 7);
        }
        bytes.Add((byte) value);
    }

    public void WriteBool(bool value)
    {
        byte ret = 0;

        if (value)
            ret = 1;
        
        WriteByte(ret);
    }

    public bool ReadBool()
    {
        return ReadByte() == 1;
    }

    public void WriteVarLong(long value)
    {
        while ((value & -128) != 0)
        {
            bytes.Add((byte) (value & 127 | 128));
            value = (int) (((ulong) value) >> 7);
        }
        bytes.Add((byte) value);
    }

    public int ReadVarInt()
    {
        int value = 0;
        int size = 0;
        int b;

        while ((b = ReadByte() & 0x80) == 0x80)
        {
            value |= (b & 0x7F) << (size++ * 7);

            if (size > 5)
                throw new IOException("VarInt is so huge wtf");
        }

        return value | ((b & 0x7F) << (size * 7));
    }

    public long ReadVarLong()
    {
        long value = 0;
        int size = 0;
        int b;
#pragma warning disable CS0675 // Bitwise-or operator used on a sign-extended operand
        while ((b = ReadByte() & 0x80) == 0x80)
        {
            value |= (b & 0x7F) << (size++*7);

            if (size > 10)
                throw new IOException("VarLong too big wtf bit");
        }

        return value | ((b & 0x7F) << (size * 7));
#pragma warning restore CS0675 // Bitwise-or operator used on a sign-extended operand
    }

    public void WritePosition(Position value)
    {
        long v = ((value.x & 0x3FFFFFF) << 38) | ((value.z & 0x3FFFFFF) << 12) | (value.y & 0xFFF);

        WriteLong(v);
    }

    public Position ReadPosition()
    {
        long position = ReadLong();
        
        int x = (int) (position >> 38);
        int y = (int) (position << 52 >> 52); 
        int z = (int) (position << 26 >> 38);

        if (x >= 1 << 25)
            x -= 1 << 26;
        if (y >= 1 << 11)
            y -= 1 << 12;
        if (z >= 1 << 25)
            z -= 1 << 26;

        return new Position(x, y, z);
    }

    public void WriteGuid(Guid value)
    {
        byte[] bytes = value.ToByteArray();

        Write(bytes);
    }

    public Guid ReadUuid()
    {
        return new Guid(Read(16));
    }

    public Angle ReadAngle() 
    {
        return new Angle(ReadByte());
    }

    public void WriteAngle(Angle angle)
    {
        WriteByte(angle.Value);
    }

    public byte[] GetBytes()
    {
        return this.bytes.ToArray();
    }
}