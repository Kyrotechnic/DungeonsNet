namespace Dungeons.Server.Json;

public class LineReader
{
    private int pointer;
    private string line;
    private int max;
    public LineReader(string line)
    {
        this.line = line;
        this.pointer = 0;
        this.max = line.Length;
    }

    public char Get(bool advance = true)
    {
        if (pointer == max)
            return ' ';
        char c = line[pointer];

        if (advance)
            pointer = Math.Min(max - 1, pointer + 1);
        
        return c;
    }

    public string Read(int count, bool advance = true)
    {
        if (count + pointer >= this.max)
            throw new Exception("Count exceeds string length!");

        string temp = "";
        for (int i = 0; i < count; i++)
            temp += line[count];

        if (advance)
            pointer += count;
        
        return temp;
    }

    public bool Assert(string line)
    {
        string test = Peek(line.Length);

        if (test.Equals(line))
            return true;
        return false;
    }

    public string Peek(int count)
    {
        return Read(line.Length, false);
    }

    public char Peek()
    {
        return Get(false);
    }

    public void SkipWhitespace()
    {
        while (true)
        {
            if (pointer == max)
                return;

            char c = Peek();

            if (c == ' ' || c == '\n'|| c == '\b')
            {
                pointer++;
                continue;
            }
            break;
        }
    }
}