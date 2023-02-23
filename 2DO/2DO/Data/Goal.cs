using SQLite;

namespace _2DO.Data;

public class Goal
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }

    public bool complete { get; set; }
    public string name { get; set; }
    public string date { get; set; }

    public Goal(string name, DateTime dateTimeDate) {
        this.name = name;
        this.date = dateTimeDate.ToShortDateString();

        this.complete = false;
    }

    public Goal() {
    }
}