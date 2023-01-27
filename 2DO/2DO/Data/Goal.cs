namespace _2DO.Data;

public class Goal
{
    public bool complete;
    public string name;

    public Goal(string name)
    {
        this.name = name;
        this.complete = false;
    }
}
