create table Users
(
    Id uuid primary key,
    Username varchar unique,
    Email varchar unique,
    PasswordHash varchar,
    CreatedAt date
);
create table Categories
(
    Id uuid primary key,
    Username varchar unique,
    CreatedAt date
);
create type Priorities as enum ('Highest','Middle','Lowest');
create table Tasks
(
    Id uuid primary key,
    Title varchar not null,
    Description varchar,
    IsCompleted bool,
    DueDate date,
    UserId uuid references Users(Id),
    CategoryId uuid references Categories(Id),
    Priority Priorities,
    CreatedAt date
);
create table Comments
(
    Id uuid primary key,
    TaskId uuid references Tasks(Id),
    UserId uuid references Users(Id),
    Content varchar,
    CreatedAt date
);
create table TaskAttachments
(
    Id uuid primary key,
    TaskId uuid references Tasks(Id),
    FilePath varchar,
    CreatedAt date
);
create table TaskHistory
(
    Id uuid primary key,
    TaskId uuid references Tasks(Id),
    ChangeDescription varchar,
    ChangedAt date
);