

using FORUM_CZAT.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ForumContext>(db_config => db_config.UseSqlite(builder.Configuration["ConnectionStrings:DB"]));
builder.Services.AddDbContext<ForumContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

builder.Services.AddDbContext<ForumContext>(db_config => db_config.UseSqlite(builder.Configuration["ConnectionStrings:IdentityDB"]));
builder.Services.AddDbContext<IdentityContext>(db_config => db_config.UseSqlite(builder.Configuration["ConnectionStrings:IdentityDB"]));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
});
builder.Services.AddScoped<IPostRepository,PostRepository>();
builder.Services.AddScoped<IURLRepository, URLRepository>();
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
