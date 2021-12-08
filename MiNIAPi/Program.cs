using Microsoft.EntityFrameworkCore;

using MiNIAPi.EFCoreMange;
using MiNIAPi.Entites;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer()
.AddSwaggerGen().AddDbContextFactory<MyDBContext>(
        options =>
            options.UseSqlServer("Data Source=.;Integrated Security=True"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("CreateDB", (MyDBContext dbcontext) =>
{
    dbcontext.Database.EnsureDeleted();
    dbcontext.Database.EnsureCreated();
});
app.MapGet("Query", async (MyDBContext dbcontext, string name) => await dbcontext.Set<User>().Where(x => x.Name.Contains(name)).ToListAsync());

app.Run();

