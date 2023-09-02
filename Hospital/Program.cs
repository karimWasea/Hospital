using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Dataaccesslayer;
using hospitalUtilities;
using hospitalservess;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using hospitalIrepreatory;
using hospitalVm;

var builder = WebApplication.CreateBuilder(args);









var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
IServiceCollection serviceCollection = builder.Services.AddDbContext<ApplicationDBcontext>(options =>
    options.UseSqlServer(connectionString));





builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount =  false)
.AddEntityFrameworkStores<ApplicationDBcontext>().AddDefaultTokenProviders();


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddTransient<Imgoeration>();
builder.Services.AddTransient<Roomserves>();
builder.Services.AddTransient<Patientserves>();
builder.Services.AddTransient<Contactserves>();
builder.Services.AddTransient<Hospitalserves>();
builder.Services.AddTransient<lookupServess>();
builder.Services.AddTransient<Apointmentserves>();
builder.Services.AddTransient<timingShiftservess>();
builder.Services.AddTransient<Applicationuserserves>();
//builder.Services.AddScoped(typeof(IPagination<PatientVm>), typeof(PaginationService<PatientVm>));
builder.Services.AddTransient<Doctorserves>();
builder.Services.AddTransient<PatientHistoryserves>();
builder.Services.AddTransient<DoctorDayworkserves>();
builder.Services.AddTransient<idoctorvisittserves>();
builder.Services.AddTransient<patientreportserves>();
builder.Services.AddTransient< RoleService>();

builder.Services.AddScoped<IDbInitializer, DbInitializers>();
builder.Services.AddScoped<IEmailSender, Emailsender>();
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Set the path for the login page.
    options.LoginPath = "/Identity/Account/Login";

    // Set the path for the access denied page.
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";

    //    // Set the path for the logout page.
    //    options.LogoutPath = "/Identity/Account/Logout";

    //    // Set the cookie expiration time (in this example, it's set to 7 days).
    //    options.ExpireTimeSpan = TimeSpan.FromDays(7);

    //    Set whether the cookie is essential for authentication.If set to true,
    //    authentication will fail if the cookie is not present.
    //   options.Cookie.IsEssential = true;

    //    Set the cookie name.
    //    options.Cookie.Name = "authratization";

    //    Set the domain for the cookie. If not set, the cookie will be valid for the current domain only.
    //   options.Cookie.Domain = ".library";

    //    Set whether the cookie should only be transmitted over HTTPS.
    //    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;

    //    Set the cookie path.
    //    options.Cookie.Path = "/";

    //    Set whether the cookie should be accessible by JavaScript in the browser.
    //    options.Cookie.HttpOnly = true;
});

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
Dataeding();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
//app.UseEndpoints(endpoints =>
//   {
//       endpoints.MapControllerRoute(
//         name: "areas",
//         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//       );
       app.MapControllerRoute(
        name: "patient",
        pattern: "{area=Admin}/{controller=Home}/{action=Index}/{id?}");

       //app.UseEndpoints(endpoints =>
       //{
       //    endpoints.MapControllerRoute(
       //        name: "default",
       //        pattern: "{controller=Home}/{action=Index}/{id?}");
       //});


       app.Run();
       void Dataeding()
   {



       using (var Scope = app.Services.CreateScope())
       {

           var Dbinsalizar = Scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        Dbinsalizar.Initialize();
    }
   }