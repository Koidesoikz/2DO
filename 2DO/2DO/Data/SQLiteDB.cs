using SQLite;
using System.Diagnostics;

namespace _2DO.Data;

public class SQLiteDB {
    SQLiteAsyncConnection DB;

    public SQLiteDB() {

    }

    async Task Init() {
        if (DB is not null) {
            return;
        }

        DB = new SQLiteAsyncConnection(DBConstants.DatabasePath, DBConstants.Flags);
        SQLite.CreateTableResult result = await DB.CreateTableAsync<Goal>();

        int goalLineAmount = await DB.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Goal");
        Debug.WriteLine("value: " + goalLineAmount);

        if(goalLineAmount == 0) {
            Debug.WriteLine("Filling in dummy data...");
            await DB.InsertAsync(new Goal() { name = "DB inserted goal" });
            await DB.InsertAsync(new Goal() { name = "Another DB inserted goal"});
        } else {
            Debug.WriteLine("No need to fill in data!!");
        }

    }

    public async Task<List<Goal>> GetAllGoals() {
        await Init();

        TableMapping goalSchema = await DB.GetMappingAsync(typeof(Goal));
        object[] parameters = { goalSchema };
        return await DB.QueryAsync<Goal>("SELECT * FROM Goal");
    }

    public async Task DropGoalTable() {
        await Init();

        await DB.DropTableAsync<Goal>();
    }

}