using SQLite;
using System.Diagnostics;

namespace _2DO.Data;

public class SQLiteDB {
    SQLiteAsyncConnection DB;
    private bool droppedTable = false;

    public SQLiteDB() {

    }

    async Task Init() {
        if (DB is not null && !droppedTable) {
            Debug.WriteLine("Jeg mistænker den her satan for at være skyld i lortet");

            //Dårlig fix
            if(await DB.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Goal") != 0) {
                return;
            }
        }
        Debug.WriteLine("POGGGGGGIES");
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

    public async Task<List<Goal>> GetAll<T>() {
        await Init();

        TableMapping goalSchema = await DB.GetMappingAsync(typeof(T));

        Debug.WriteLine("Test ting: " + goalSchema.TableName);

        return await DB.QueryAsync<Goal>($"SELECT * FROM {goalSchema.TableName}");
    }

    public async Task<List<Goal>> GetAllGoalsByDate(DateTime date) {
        await Init();

        return await DB.QueryAsync<Goal>($"SELECT * FROM Goal WHERE date=?", date.ToShortDateString());
    }

    public async Task Insert<T>(T data) {
        await Init();

        await DB.InsertAsync(data);
    }

    public async Task Update<T>(T data) {
        await Init();

        await DB.UpdateAsync(data);
    }
    public async Task Delete<T>(T data) {
        await Init();

        await DB.DeleteAsync(data);
    }

    public async Task DropGoalTable() {
        await Init();

        await DB.DropTableAsync<Goal>();

        droppedTable = true;
    }

}