using BL;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IUsersDAL, UsersDAL>();
builder.Services.AddScoped<IUsersBL, UsersBL>();


builder.Services.AddDbContext<EconomyContext>(options =>
options.UseSqlServer("Server =DESKTOP-6S5T98O\\SQLEXPRESS; Database = Economy; Trusted_Connection = True; "));
builder.Services.AddScoped<ICategoriesDAL, CategoriesDAL>();
builder.Services.AddScoped<ICategoriesBL, CategoriesBL>();
builder.Services.AddScoped<IExpenseDAL, ExpenseDAL>();
builder.Services.AddScoped<IExpenseBL, ExpenseBL>();
builder.Services.AddScoped<IIncomeDAL, IncomeDAL>();
builder.Services.AddScoped<IIncomeBL, IncomeBL>();
builder.Services.AddScoped<IFixedExpenseDAL, FixedExpenseDAL>();
builder.Services.AddScoped<IFixedExpenseBL, FixedExpenseBL>();
builder.Services.AddScoped<IFixedIncomeDAL, FixedIncomeDAL>();
builder.Services.AddScoped<IFixedIncomeBL, FixedIncomeBL>();
builder.Services.AddCors(c => c.AddPolicy("policy", option => option.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("policy");
app.MapControllers();

app.Run();
