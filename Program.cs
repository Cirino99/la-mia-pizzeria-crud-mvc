using la_mia_pizzeria_static.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();  //autoload

builder.Services.AddScoped<IPizzaRepository, InMemoryPizzaRepository>();
//builder.Services.AddScoped<IPizzaRepository, DbPizzaRepository>();
builder.Services.AddScoped<ICategoryRepository, InMemoryCategoryRepository>();
//builder.Services.AddScoped<ICategoryRepository, DbCategoryRepository>();
builder.Services.AddScoped<IIngredientRepository, InMemoryIngredientRepository>();
//builder.Services.AddScoped<IIngredientRepository, DbIngredientRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=Index}/{id?}");

app.Run();
