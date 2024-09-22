using Dapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Services;

public class TaskService:ITaskRepository
{
    public async Task<IEnumerable<Tasks>> GetAll()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<Tasks>(SqlCommands.GetAll);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Tasks?> GetById(Guid id)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<Tasks>(SqlCommands.GetById,new{Id=id});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateAsync(Tasks task)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Create,task)>0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Tasks task)
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.ExecuteAsync(SqlCommands.Update,task)>0;
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
    public async Task<IEnumerable<TasksByPriority>> TasksByPriority()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TasksByPriority>(SqlCommands.TasksByPriority);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<TasksWithUserAndCategory>> TasksWithUserAndCategory()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TasksWithUserAndCategory>(SqlCommands.TasksWithUserAndCategory);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<TasksOrderedByDueDate>> TasksOrderedByDueDate()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TasksOrderedByDueDate>(SqlCommands.TasksOrderedByDueDate);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<TaskHistoryById?> TaskHistoryById()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<TaskHistoryById>(SqlCommands.TaskHistoryById);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<CommentsTaskFilteredByUser?> CommentsTaskFilteredByUser()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryFirstOrDefaultAsync<CommentsTaskFilteredByUser>(SqlCommands.CommentsTaskFilteredByUser);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<TasksFilteredByDueDate>> TasksFilteredByDueDate()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TasksFilteredByDueDate>(SqlCommands.TasksFilteredByDueDate);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
    public async Task<IEnumerable<TasksFilteredByDueDateAndPriority>> TasksFilteredByDueDateAndPriority()
    {
        try
        {
            using (NpgsqlConnection con = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                con.Open();
                return await con.QueryAsync<TasksFilteredByDueDateAndPriority>(SqlCommands.TasksFilteredByDueDateAndPriority);
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
    public const string GetAll = "select * from tasks";
    public const string GetById = "select * from tasks where id=@id";
    public const string Create = "insert into tasks(Id,Title,Description,IsCompleted,DueDate,UserId,CategoryId,Priority,CreatedAt) values(@Id,@Title,@Description,@IsCompleted,@DueDate,@UserId,@CategoryId,@Priority,@CreatedAt)";
    public const string Update = "update tasks set Title=@Title,Description=@Description,IsCompleted=@IsCompleted,DueDate=@DueDate,UserId=@UserId,CategoryId=@CategoryId,Priority=@Priority,CreatedAt=@CreatedAt where Id=@Id";
    public const string Delete = "delete from tasks where id=@id";
    public const string TasksByPriority = @"select id,Title,Description,Priority from Tasks
where Priority = 'Highest'
";

    public const string TasksWithUserAndCategory = @"select t.id,t.Title,t.Description,u.Username,c.Name from Tasks t
join Users u on u.id = t.UserId
join Categories c on c.id = t.CategoryId
";

    public const string TasksOrderedByDueDate = @"select id,Title,Description,DueDate from Tasks
order by DueDate
";

    public const string TaskHistoryById = @"select t.id,t.title,th.changedat from Tasks t
join TaskHistory th on t.id = th.TaskId
where t.id = '550e8400-e29b-41d4-a716-446655440001'
";

    public const string CommentsTaskFilteredByUser = @"select t.id,t.title,c.Content from Tasks t
join Comments c on t.id = c.TaskId
join Users u on u.id = t.userid
where u.id = 'e3e70632-6c9f-4ad7-8a23-034f3a3a31b1'
";

    public const string TasksFilteredByDueDate = @"select id,Title,DueDate from Tasks 
where extract(month from current_date)-extract(month from DueDate)>3
";

    public const string TasksFilteredByDueDateAndPriority = @"select id,Title,DueDate from Tasks 
where extract(month from current_date)-extract(month from DueDate)>2 and
priority = 'Lowest'
";
}