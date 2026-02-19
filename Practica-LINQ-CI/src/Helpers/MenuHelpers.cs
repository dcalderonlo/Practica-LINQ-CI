namespace Practica_LINQ_CI.Helpers;
// Contiene los métodos relacionados con la presentación del menú en consola.
internal static class MenuHelper
{
  // Imprime en consola la lista de todos los ejercicios disponibles.
  public static void PrintMenu()
  {
    Console.WriteLine("\n--- Menú de ejercicios ---");
    Console.WriteLine(" 1.  Obtener todos los productos de la lista.");
    Console.WriteLine(" 2.  Obtener los nombres de todos los productos.");
    Console.WriteLine(" 3.  Obtener los productos cuyo precio sea mayor a 500.");
    Console.WriteLine(" 4.  Obtener los productos con stock menor a 10.");
    Console.WriteLine(" 5.  Obtener los productos de la categoría Electrónica.");
    Console.WriteLine(" 6.  Obtener los productos cuyo nombre comience con la letra L.");
    Console.WriteLine(" 7.  Obtener los productos cuyo precio esté entre 100 y 500.");
    Console.WriteLine(" 8.  Obtener los productos ordenados por precio ascendente.");
    Console.WriteLine(" 9.  Obtener los productos ordenados por precio descendente.");
    Console.WriteLine("10.  Obtener los productos ordenados por nombre alfabético.");
    Console.WriteLine("11.  Obtener los productos ordenados por stock de mayor a menor.");
    Console.WriteLine("12.  Obtener los primeros 5 productos más caros.");
    Console.WriteLine("13.  Obtener los 10 productos con menor stock.");
    Console.WriteLine("14.  Obtener la cantidad total de productos en la lista.");
    Console.WriteLine("15.  Obtener la suma de todos los precios de los productos.");
    Console.WriteLine("16.  Obtener el precio promedio de los productos.");
    Console.WriteLine("17.  Obtener el producto más caro.");
    Console.WriteLine("18.  Obtener el producto más barato.");
    Console.WriteLine("19.  Verificar si hay algún producto con precio mayor a 1000.");
    Console.WriteLine("20.  Verificar si todos los productos tienen stock mayor a 5.");
    Console.WriteLine("21.  Contar cuántos productos hay en la categoría Audio.");
    Console.WriteLine("22.  Agrupar los productos por categoría.");
    Console.WriteLine("23.  Obtener la categoría con más productos.");
    Console.WriteLine("24.  Obtener el stock total de todos los productos.");
    Console.WriteLine("25.  Obtener el producto con el nombre más largo.");
    Console.WriteLine("26.  Obtener el producto con la descripción más corta.");
    Console.WriteLine("27.  Filtrar productos cuya descripción contenga la palabra 'pantalla'.");
    Console.WriteLine("28.  Obtener el promedio de stock de la categoría Almacenamiento.");
    Console.WriteLine("29.  Obtener los productos creados en una fecha específica (20/12/2022).");
    Console.WriteLine("30.  Obtener los productos cuya ID sea par.");
    Console.WriteLine("31.  Obtener los productos cuya ID sea impar.");
    Console.WriteLine("32.  Obtener los productos cuyo precio tenga un decimal mayor a .50.");
    Console.WriteLine("33.  Obtener los productos cuyo nombre tenga más de 10 caracteres.");
    Console.WriteLine("34.  Obtener los productos cuyo stock sea un número primo.");
    Console.WriteLine("35.  Obtener los productos cuyo nombre contenga la palabra 'Pro'.");
    Console.WriteLine("36.  Obtener los productos cuyo stock sea un múltiplo de 5.");
    Console.WriteLine("37.  Obtener los productos con descripción de más de 20 caracteres.");
    Console.WriteLine("38.  Obtener los productos cuyo precio sea un número redondo.");
    Console.WriteLine("39.  Obtener los productos que tengan exactamente dos palabras en su nombre.");
    Console.WriteLine("40.  Obtener la cantidad de productos que no pertenecen a la categoría General.");
  }
}
