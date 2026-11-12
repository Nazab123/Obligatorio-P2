
using Obligatorio_P2;

var builder = WebApplication.CreateBuilder(args);

// Agregamos los servicios necesarios para MVC
builder.Services.AddControllersWithViews();

// Configuramos la sesión
builder.Services.AddSession();

// Obtenemos la unica instancia de Sistema
Sistema sistema = Sistema.ObtenerInstancia();

// Ejecutamos las precargas de investigadores,
// sospechosos, casos y evidencias
sistema.Precargar();

// Registramos Sistema para utilizarl
// desde los controladores
builder.Services.AddSingleton(sistema);

var app = builder.Build();

// Configuracion del manejo de errores
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redireccion a HTTPS
app.UseHttpsRedirection();

// Permite servir archivos CSS, JS e imagenes
app.UseStaticFiles();

// Configuracion de rutas
app.UseRouting();

// Habilitamos la sesión para las solicitudes
app.UseSession();

// Autorizacion
app.UseAuthorization();

// Utilizamos Session en la aplicación
app.UseSession();

// Ruta predeterminada de MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Login}/{id?}");

app.Run();
