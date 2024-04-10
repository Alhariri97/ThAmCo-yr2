using ThAmCo.Events.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuth0WebAppAuthentication(options =>
    {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>();

// Injection For Event Services Dependencies
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IVenuesService, VenuesService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ICateringService, CateringService>();

var app = builder.Build();



if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

//For errors!
app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
