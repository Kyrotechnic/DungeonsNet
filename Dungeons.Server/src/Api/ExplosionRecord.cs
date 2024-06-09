public struct ExplosionRecord
{
    public sbyte Byte1 {get; private set;}
    public sbyte Byte2 {get; private set;}
    public sbyte Byte3 {get; private set;}
    public ExplosionRecord(sbyte Byte1, sbyte Byte2, sbyte Byte3)
    {
        this.Byte1 = Byte1;
        this.Byte2 = Byte2;
        this.Byte3 = Byte3;
    }
}