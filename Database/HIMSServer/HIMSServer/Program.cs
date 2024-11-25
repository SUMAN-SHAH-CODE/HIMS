using HIMSServer;
using Microsoft.EntityFrameworkCore;
using RepositoryPatient;//adi name space xa vana namespace lanai 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Adding CORS hai
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();

}));

///here AddDbContext method is use to add PatientDbContext instance by DI
//builder.Configuration.GetConnectionString("DefaultConnection"): This retrieves the connection string from the appsettings.json file or another configuration source.
//b => b.MigrationsAssembly("HIMSServer"): This specifies the migrations assembly as "HIMSServer".
builder.Services.AddDbContext<PatientDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("HIMSServer")));



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseCheckSecurityMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//apply cors before use authorization
app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
