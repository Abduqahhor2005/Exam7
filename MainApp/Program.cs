using System.Text.Json;
using System.Text.Json.Serialization;
using Dapper;
using Infrastructure.Models;
using Infrastructure.Services;
using Npgsql;
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:5132/");
builder.WebHost.ConfigureKestrel(options => { options.AllowSynchronousIO = true; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();
CategoryService categoryService = new CategoryService();
CommentService commentService = new CommentService();
TaskAttachmentService taskAttachmentService = new TaskAttachmentService();
TaskHistoryService taskHistoryService = new TaskHistoryService();
TaskService taskService = new TaskService();
UserService userService = new UserService();

app.MapGet("api/Categories", async() =>
{
    IEnumerable<Category> categories = await categoryService.GetAll();
    return Results.Json(categories);
});
app.MapGet("api/Categories/{id}", async(Guid id) =>
{
    Category? category = await categoryService.GetById(id);
    if(category==null) return Results.NotFound(new{message="no category"});
    return Results.Json(category);
});
app.MapPost("api/Categories", async (Category category) =>
{
    bool res = await categoryService.CreateAsync(category);
    if(res==false) return Results.NotFound(new{message="not posted"});
    return Results.Ok(new{message="posted"});
});
app.MapPut("api/Categories", async (Category category) =>
{
    bool res = await categoryService.UpdateAsync(category);
    if(res==false) return Results.NotFound(new{message="not updated"});
    return Results.Ok(new{message="updated"});
});
app.MapDelete("api/Categories/{id}", async(Guid id) =>
{
    bool category = await categoryService.DeleteAsync(id);
    if(category==false) return Results.NotFound(new{message="not deleted"});
    return Results.Ok(new {message="deleted"});
});
app.MapGet("api/CategoriesWithCountOfTasks", async () =>
{
    IEnumerable<CategoriesWithCountOfTasks> categories = await categoryService.CategoriesWithCountOfTasks();
    return Results.Json(categories);
});
app.MapGet("api/Comments", async() =>
{
    IEnumerable<Comment> comments = await commentService.GetAll();
    return Results.Json(comments);
});
app.MapGet("api/Comments/{id}", async(Guid id) =>
{
    Comment? comment = await commentService.GetById(id);
    if(comment==null) return Results.NotFound(new{message="no comment"});
    return Results.Json(comment);
});
app.MapPost("api/Comments", async (Comment comment) =>
{
    bool res = await commentService.CreateAsync(comment);
    if(res==false) return Results.NotFound(new{message="not posted"});
    return Results.Ok(new{message="posted"});
});
app.MapPut("api/Comments", async (Comment comment) =>
{
    bool res = await commentService.UpdateAsync(comment);
    if(res==false) return Results.NotFound(new{message="not updated"});
    return Results.Ok(new{message="updated"});
});
app.MapDelete("api/Comments/{id}", async(Guid id) =>
{
    bool comment = await commentService.DeleteAsync(id);
    if(comment==false) return Results.NotFound(new{message="not deleted"});
    return Results.Ok(new {message="deleted"});
});
app.MapGet("api/TaskAttachment", async() =>
{
    IEnumerable<TaskAttachment> taskAttachments = await taskAttachmentService.GetAll();
    return Results.Json(taskAttachments);
});
app.MapGet("api/TaskAttachment/{id}", async(Guid id) =>
{
    TaskAttachment? taskAttachment = await taskAttachmentService.GetById(id);
    if(taskAttachment==null) return Results.NotFound(new{message="no taskAttachment"});
    return Results.Json(taskAttachment);
});
app.MapPost("api/TaskAttachment", async (TaskAttachment taskAttachment) =>
{
    bool res = await taskAttachmentService.CreateAsync(taskAttachment);
    if(res==false) return Results.NotFound(new{message="not posted"});
    return Results.Ok(new{message="posted"});
});
app.MapPut("api/TaskAttachment", async (TaskAttachment taskAttachment) =>
{
    bool res = await taskAttachmentService.UpdateAsync(taskAttachment);
    if(res==false) return Results.NotFound(new{message="not updated"});
    return Results.Ok(new{message="updated"});
});
app.MapDelete("api/TaskAttachment/{id}", async(Guid id) =>
{
    bool taskAttachment = await taskAttachmentService.DeleteAsync(id);
    if(taskAttachment==false) return Results.NotFound(new{message="not deleted"});
    return Results.Ok(new {message="deleted"});
});
app.MapGet("api/TaskAttachmentsWithUserInformation", async() =>
{
    IEnumerable<TaskAttachmentsWithUserInformation> taskAttachments = await taskAttachmentService.TaskAttachmentsWithUserInformation();
    return Results.Json(taskAttachments);
});
app.MapGet("api/TaskHistory", async() =>
{
    IEnumerable<TaskHistory> taskHistories = await taskHistoryService.GetAll();
    return Results.Json(taskHistories);
});
app.MapGet("api/TaskHistory/{id}", async(Guid id) =>
{
    TaskHistory? taskHistory = await taskHistoryService.GetById(id);
    if(taskHistory==null) return Results.NotFound(new{message="no taskHistory"});
    return Results.Json(taskHistory);
});
app.MapPost("api/TaskHistory", async (TaskHistory taskHistory) =>
{
    bool res = await taskHistoryService.CreateAsync(taskHistory);
    if(res==false) return Results.NotFound(new{message="not posted"});
    return Results.Ok(new{message="posted"});
});
app.MapPut("api/TaskHistory", async (TaskHistory taskHistory) =>
{
    bool res = await taskHistoryService.UpdateAsync(taskHistory);
    if(res==false) return Results.NotFound(new{message="not updated"});
    return Results.Ok(new{message="updated"});
});
app.MapDelete("api/TaskHistory/{id}", async(Guid id) =>
{
    bool taskHistory = await taskHistoryService.DeleteAsync(id);
    if(taskHistory==false) return Results.NotFound(new{message="not deleted"});
    return Results.Ok(new {message="deleted"});
});
app.MapGet("api/Tasks", async() =>
{
    IEnumerable<Tasks> tasks = await taskService.GetAll();
    return Results.Json(tasks);
});
app.MapGet("api/Tasks/{id}", async(Guid id) =>
{
    Tasks? task = await taskService.GetById(id);
    if(task==null) return Results.NotFound(new{message="no task"});
    return Results.Json(task);
});
app.MapPost("api/Tasks", async (Tasks task) =>
{
    bool res = await taskService.CreateAsync(task);
    if(res==false) return Results.NotFound(new{message="not posted"});
    return Results.Ok(new{message="posted"});
});
app.MapPut("api/Tasks", async (Tasks task) =>
{
    bool res = await taskService.UpdateAsync(task);
    if(res==false) return Results.NotFound(new{message="not updated"});
    return Results.Ok(new{message="updated"});
});
app.MapDelete("api/Tasks/{id}", async(Guid id) =>
{
    bool task = await taskService.DeleteAsync(id);
    if(task==false) return Results.NotFound(new{message="not deleted"});
    return Results.Ok(new {message="deleted"});
});
app.MapGet("api/TasksByPriority", async() =>
{
    IEnumerable<TasksByPriority> tasks = await taskService.TasksByPriority();
    return Results.Json(tasks);
});
app.MapGet("api/TasksWithUserAndCategory", async() =>
{
    IEnumerable<TasksWithUserAndCategory> tasks = await taskService.TasksWithUserAndCategory();
    return Results.Json(tasks);
});
app.MapGet("api/TasksOrderedByDueDate", async() =>
{
    IEnumerable<TasksOrderedByDueDate> tasks = await taskService.TasksOrderedByDueDate();
    return Results.Json(tasks);
});
app.MapGet("api/TaskHistoryById", async() =>
{
    TaskHistoryById? task = await taskService.TaskHistoryById();
    if(task==null) return Results.NotFound(new{message="no task"});
    return Results.Json(task);
});
app.MapGet("api/TaskCommentsFilteredByUser", async() =>
{
    CommentsTaskFilteredByUser? task = await taskService.CommentsTaskFilteredByUser();
    if(task==null) return Results.NotFound(new{message="no task"});
    return Results.Json(task);
});
app.MapGet("api/TasksFilteredByDueDate", async() =>
{
    IEnumerable<TasksFilteredByDueDate> tasks = await taskService.TasksFilteredByDueDate();
    return Results.Json(tasks);
});
app.MapGet("api/TasksFilteredByDueDateAndPriority", async() =>
{
    IEnumerable<TasksFilteredByDueDateAndPriority> task = await taskService.TasksFilteredByDueDateAndPriority();
    return Results.Json(task);
});
app.MapGet("api/Users", async() =>
{
    IEnumerable<User> users = await userService.GetAll();
    return Results.Json(users);
});
app.MapGet("api/Users/{id}", async(Guid id) =>
{
    User? user = await userService.GetById(id);
    if(user==null) return Results.NotFound(new{message="no user"});
    return Results.Json(user);
});
app.MapPost("api/Users", async (User user) =>
{
    bool res = await userService.CreateAsync(user);
    if(res==false) return Results.NotFound(new{message="not posted"});
    return Results.Ok(new{message="posted"});
});
app.MapPut("api/Users", async (User user) =>
{
    bool res = await userService.UpdateAsync(user);
    if(res==false) return Results.NotFound(new{message="not updated"});
    return Results.Ok(new{message="updated"});
});
app.MapDelete("api/Users/{id}", async(Guid id) =>
{
    bool user = await userService.DeleteAsync(id);
    if(user==false) return Results.NotFound(new{message="not deleted"});
    return Results.Ok(new {message="deleted"});
});
app.MapGet("api/UsersWithTasks", async() =>
{
    IEnumerable<UsersWithTasks> users = await userService.UsersWithTasks();
    return Results.Json(users);
});
app.Run();