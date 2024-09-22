using Dapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Services;

public class TaskHistoryService : ITaskHistoryRepository
{
    public async Task<IEnumerable<TaskHistory>> GetAll()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TaskHistory>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public  async Task<TaskHistory?> GetById(Guid id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<TaskHistory>(SqlCommands.GetById,new{Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAsync(TaskHistory taskHistory)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Create,taskHistory)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(TaskHistory taskHistory)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Update,taskHistory)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Delete,new {Id=id})>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}



file class SqlCommands
{
    public const string ConnectionString = "Host=localhost;User Id=postgres;Database=exam7_db;Port=4321;Password=salom;";
    public const string GetAll = "select * from TaskHistory";
    public const string GetById = "select * from TaskHistory where id=@id";
    public const string Create = "insert into TaskHistory(Id,TaskId,ChangeDescription,ChangedAt) values(@Id,@TaskId,@ChangeDescription,@ChangedAt)";
    public const string Update = "update TaskHistory set TaskId=@TaskId,ChangeDescription=@ChangeDescription,ChangedAt=@ChangedAt where Id=@Id";
    public const string Delete = "delete from TaskHistory where id=@id";
}