using MyPlaywright.Services;

namespace MyPlaywright
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IPlaywrightService, PlaywrightService>();
            //builder.Services.AddHostedService<PlaywrightInitializer>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // ép DI tạo Singleton sớm
            using (var scope = app.Services.CreateScope())
            {
                var playwrightService = scope.ServiceProvider.GetRequiredService<IPlaywrightService>();
                // nếu PlaywrightService có constructor hoặc logic khởi tạo — nó sẽ chạy ngay tại đây
            }

            app.Run();
        }
    }
}
