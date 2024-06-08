using Dungeons.Server.Location;
using Dungeons.Server.Api;

namespace Dungeons.Server.Protocol;

public interface IBuffer
{
    public static IBuffer Create()
    {
        return new ByteBuffer();
    }

    //write

    public void Write(byte[] bytes);
    public void WriteByte(byte value);
    public void WriteSByte(sbyte value);
    public void WriteShort(short value);
    public void WriteUShort(ushort value);
    public void WriteVarInt(int value);
    public void WriteVarLong(long value);
    public void WriteInt(int value);
    public void WriteUInt(uint value);
    public void WriteLong(long value);
    public void WriteULong(ulong value);
    public void WriteFloat(float value);
    public void WriteDouble(double value);
    public void WriteString(string value);
    public void WriteBool(bool value);
    public void WritePosition(Position value);
    public void WriteGuid(Guid value);
    public void WriteAngle(Angle angle);

    //read
    public byte[] Read(int count);
    public byte ReadByte();
    public sbyte ReadSByte();
    public short ReadShort();
    public ushort ReadUShort();
    public int ReadInt();
    public int ReadVarInt();
    public long ReadVarLong();
    public uint ReadUInt();
    public long ReadLong();
    public ulong ReadULong();
    public float ReadFloat();
    public double ReadDouble();
    public string ReadString();
    public bool ReadBool();
    public Position ReadPosition();
    public Guid ReadUuid();
    public Angle ReadAngle();

    //
    public void Set(byte[] bytes);
    public void SetPointer(int point);
    public byte[] GetBytes();
}