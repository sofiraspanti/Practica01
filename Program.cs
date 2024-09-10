using Practica01.Dominio;
using Practica01.Servicios;


FacturasServicios facturasServicios = new FacturasServicios();
// OBTENGO LAS FORMAS DE PAGO -------- no me trae los resultados de la lista
Console.WriteLine("Formas de pago disponibles:");
var formasPago = facturasServicios.GetAllFormasPago();
    foreach (var tipo in formasPago)
    {
        Console.WriteLine($"ID: {tipo.id_forma_pago}, Nombre: {tipo.nombre}");
    }

// OBTENGO LOS ARTICULOS - funciona ok
Console.WriteLine("Articulos disponibles:");
var articulos = facturasServicios.GetAllArticulos();
foreach (var tipo in articulos)
{
    Console.WriteLine($"ID: {tipo.id_art}, Producto: {tipo.nombre}, Precio: {tipo.precio}");
}

// OBTENGO LAS FACTURAS 
Console.WriteLine("Facturas disponibles:");
var facruras = facturasServicios.GetAllFacturas();
foreach (var tipo in facruras)
{
    Console.WriteLine($"Nro factura: {tipo.id_factura}, Fecha {tipo.fecha}, Forma de pago: {tipo.forma_pago}, Cliente: {tipo.cliente}");
}
