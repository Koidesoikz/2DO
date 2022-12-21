using System.Collections.Generic;

namespace _2DO.Data;

public class TaskList
{
    public List<Goal> goals;
    public List<Prefab> prefab;
    public bool complete;
    public string name;
    public DateTime startDate;
    public DateTime endDate;

    public TaskList(string name) {
        this.name = name;
        this.complete = false;
    }
}