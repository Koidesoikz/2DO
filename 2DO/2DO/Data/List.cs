using System.Collections.Generic;

namespace _2DO.Data;

public class List
{
    public List<Goal> goals;
    public List<Prefab> prefab;
    public bool complete;
    public string name;
    public DateTime startDate;
    public DateTime endDate;
}