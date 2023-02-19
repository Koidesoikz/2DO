using SQLite;

namespace _2DO.Data;

public class Goal
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }

    public bool complete;
    public string name { get; set; }

    public Goal(string name) {
        this.name = name;
        this.complete = false;
    }

    public Goal() {
    }
}