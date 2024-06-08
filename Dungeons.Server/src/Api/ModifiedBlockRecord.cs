public struct ModifiedBlockRecord
{
    public byte HorizontalPosition {get; private set;}
    public byte YCoordinate {get; private set;}
    public int BlockId {get; private set;}
    public ModifiedBlockRecord(byte HorizontalPosition, byte YCoordinate, int BlockId) 
    {
        this.HorizontalPosition = HorizontalPosition;
        this.YCoordinate = YCoordinate;
        this.BlockId = BlockId;
    }
}