using SQLite;

namespace _2DO.Data;

public class Goal
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }

    public bool complete { get; set; }
    public string name { get; set; }
    public string dateCreated { get; set; }
    public string dateCompleted { get; set; }

    public Goal(string name, DateTime dateTimeDate) {
        this.name = name;
        this.dateCreated = dateTimeDate.ToString("yyyy/MM/dd");
        this.dateCompleted = "";
        this.complete = false;
    }

    public Goal() {
    }
}