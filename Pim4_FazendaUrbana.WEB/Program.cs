using Pim4_FazendaUrbana.DATA.Interfaces;
using Pim4_FazendaUrbana.DATA.Repositories;
using Microsoft.AspNetCore.Http;
using Pim4_FazendaUrbana.WEB.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IRepositoryFuncionario, RepositoryFuncionario>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseBrowserLink();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//         => optionsBuilder.UseSqlServer("Data Source=DESKTOP-P8QSFMT\\SQLEXPRESS;Initial Catalog=PimFazendaUrbanaWeb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.Run();
