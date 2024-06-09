public struct Statistic
{
    public string Name {get; private set;}
    public int Value {get; private set;}

    public Statistic(string name, int value)
    {
        Name = name;
        Value = value;
    }



}