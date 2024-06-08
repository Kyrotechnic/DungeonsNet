namespace Dungeons.Server.Api;

public struct Angle
{
    public byte Value {get; set;}
    public float Degrees 
    {
        get => Value * 360f / 256f;
        set => Value = (byte) Normalize(value);
    }

    public Angle(float value) 
    {
        this.Value = Value;
    }


    public static implicit operator Angle(float degree)
    {
        var angle = default(Angle);
        angle.Degrees = degree;
        return angle;
    }

    private static float Normalize(float degree)
    {
        degree %= 360;
        if (degree < 0) degree += 360;
        return degree;
    }

}