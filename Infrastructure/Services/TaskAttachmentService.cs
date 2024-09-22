using Dapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Services;

public class TaskAttachmentService : ITaskAttachmentRepository
{
    public async Task<IEnumerable<TaskAttachment>> GetAll()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TaskAttachment>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<TaskAttachment?> GetById(Guid id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<TaskAttachment>(SqlCommands.GetById,new{Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAsync(TaskAttachment taskAttachment)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Create,taskAttachment)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(TaskAttachment taskAttachment)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Update,taskAttachment)>0;
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
    public async Task<IEnumerable<TaskAttachmentsWithUserInformation>> TaskAttachmentsWithUserInformation()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TaskAttachmentsWithUserInformation>(SqlCommands.TaskAttachmentsWithUserInformation);
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
    public const string GetAll = "select * from TaskAttachments";
    public const string GetById = "select * from TaskAttachments where id=@id";
    public const string Create = "insert into TaskAttachments(Id,TaskId,FilePath,CreatedAt) values(@Id,@TaskId,@FilePath,@CreatedAt)";
    public const string Update = "update TaskAttachments set TaskId=@TaskId,FilePath=@FilePath,CreatedAt=@CreatedAt where Id=@Id";
    public const string Delete = "delete from TaskAttachments where id=@id";
    public const string TaskAttachmentsWithUserInformation = @"select ta.id,ta.FilePath,t.Title,u.username from TaskAttachments ta
join Tasks t on t.id = ta.TaskId
join Users u on u.id = t.userid
";
}