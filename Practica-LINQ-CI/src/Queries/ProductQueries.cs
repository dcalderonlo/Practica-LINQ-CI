using Practica_LINQ_CI.Models;

namespace Practica_LINQ_CI.Queries;
/// Contiene todos los métodos de consulta LINQ sobre la colección de productos.
/// Cada método resuelve un ejercicio específico de forma aislada y reutilizable.
public static class ProductQueries
{
  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 1 – CONSULTAS BÁSICAS (Ejercicios 1–6)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 1: Obtener todos los productos de la lista.
  // Se usa AsEnumerable() para dejar explícito que trabajamos con LINQ to Objects.
  public static IEnumerable<Product> ObtenerTodos(List<Product> products) =>
    products.AsEnumerable();

  // Ejercicio 2: Obtener solo los nombres de todos los productos.
  // Select proyecta cada objeto Product a una única propiedad string.
  public static IEnumerable<string> ObtenerNombres(List<Product> products) =>
    products.Select(p => p.Name);

  // Ejercicio 3: Obtener los productos cuyo precio sea mayor a 500.
  // Where filtra los elementos que cumplen la condición dada.
  public static IEnumerable<Product> PrecioMayorA500(List<Product> products) =>
    products.Where(p => p.Price > 500);

  // Ejercicio 4: Obtener los productos con stock menor a 10.
  public static IEnumerable<Product> StockMenorA10(List<Product> products) =>
    products.Where(p => p.Stock < 10);

  // Ejercicio 5: Obtener los productos de la categoría "Electrónica".
  // StringComparison.OrdinalIgnoreCase hace la comparación insensible a mayúsculas.
  public static IEnumerable<Product> CategoriaElectronica(List<Product> products) =>
    products.Where(p => p.Category.Equals("Electrónica", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 6: Obtener los productos cuyo nombre comience con la letra 'L'.
  // StartsWith evalúa el prefijo del string de forma eficiente.
  public static IEnumerable<Product> NombreEmpiezaConL(List<Product> products) =>
    products.Where(p => p.Name.StartsWith("L", StringComparison.OrdinalIgnoreCase));

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 2 – FILTROS DE RANGO Y ORDENAMIENTO (Ejercicios 7–11)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 7: Obtener los productos cuyo precio esté entre 100 y 500 (inclusive).
  public static IEnumerable<Product> PrecioEntre100Y500(List<Product> products) =>
    products.Where(p => p.Price >= 100 && p.Price <= 500);

  // Ejercicio 8: Obtener los productos ordenados por precio ascendente.
  // OrderBy ordena de menor a mayor.
  public static IEnumerable<Product> OrdenadosPorPrecioAsc(List<Product> products) =>
    products.OrderBy(p => p.Price);

  // Ejercicio 9: Obtener los productos ordenados por precio descendente.
  // OrderByDescending ordena de mayor a menor.
  public static IEnumerable<Product> OrdenadosPorPrecioDesc(List<Product> products) =>
    products.OrderByDescending(p => p.Price);

  // Ejercicio 10: Obtener los productos ordenados por nombre alfabéticamente (A → Z).
  // StringComparer.CurrentCulture respeta caracteres especiales como tildes y la ñ.
  public static IEnumerable<Product> OrdenadosPorNombre(List<Product> products) =>
    products.OrderBy(p => p.Name, StringComparer.CurrentCulture);

  // Ejercicio 11: Obtener los productos ordenados por stock de mayor a menor.
  public static IEnumerable<Product> OrdenadosPorStockDesc(List<Product> products) =>
    products.OrderByDescending(p => p.Stock);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 3 – PAGINACIÓN Y SELECCIÓN LIMITADA (Ejercicios 12–13)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 12: Obtener los primeros 5 productos más caros.
  // Combinamos OrderByDescending con Take para obtener el top N.
  public static IEnumerable<Product> Top5MasCaros(List<Product> products) =>
    products.OrderByDescending(p => p.Price).Take(5);

  // Ejercicio 13: Obtener los 10 productos con menor stock.
  // Combinamos OrderBy con Take para obtener el top N.
  public static IEnumerable<Product> Top10MenorStock(List<Product> products) =>
    products.OrderBy(p => p.Stock).Take(10);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 4 – AGREGACIONES Y ESTADÍSTICAS (Ejercicios 14–20)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 14: Obtener la cantidad total de productos en la lista.
  // Count() recorre la colección y devuelve un entero.
  public static int TotalProductos(List<Product> products) =>
    products.Count();

  // Ejercicio 15: Obtener la suma de todos los precios de los productos.
  // Sum() acumula el valor de la propiedad indicada en el selector.
  public static decimal SumaPrecios(List<Product> products) =>
    products.Sum(p => p.Price);

  // Ejercicio 16: Obtener el precio promedio de los productos.
  // Average() calcula la media aritmética de los valores proyectados.
  public static double PrecioPromedio(List<Product> products) =>
    (double)products.Average(p => p.Price);

  // Ejercicio 17: Obtener el producto más caro.
  // MaxBy selecciona el elemento cuya propiedad Price es la mayor.
  public static Product? ProductoMasCaro(List<Product> products) =>
    products.MaxBy(p => p.Price);

  // Ejercicio 18: Obtener el producto más barato.
  // MinBy selecciona el elemento cuya propiedad Price es la menor.
  public static Product? ProductoMasBarato(List<Product> products) =>
    products.MinBy(p => p.Price);

  // Ejercicio 19: Verificar si hay algún producto con precio mayor a 1000.
  // Any() devuelve true en cuanto encuentra el primer elemento que cumple la condición.
  public static bool HayProductoMayorA1000(List<Product> products) =>
    products.Any(p => p.Price > 1000);

  // Ejercicio 20: Verificar si todos los productos tienen stock mayor a 5.
  // All() devuelve true solo si TODOS los elementos cumplen la condición.
  public static bool TodosTienenStockMayorA5(List<Product> products) =>
    products.All(p => p.Stock > 5);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 5 – AGRUPACIONES (Ejercicios 21–24)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 21: Contar cuántos productos hay en la categoría "Audio".
  // Combinamos Where + Count para filtrar primero y luego contar.
  public static int ContarProductosAudio(List<Product> products) =>
    products.Count(p => p.Category.Equals("Audio", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 22: Agrupar los productos por categoría.
  // GroupBy devuelve IGrouping donde cada grupo tiene una clave (categoría)
  // y una colección de los productos que pertenecen a ella.
  public static IEnumerable<IGrouping<string, Product>> AgruparPorCategoria(List<Product> products) =>
    products.GroupBy(p => p.Category);

  // Ejercicio 23: Obtener la categoría con más productos.
  // Agrupamos, contamos elementos por grupo y tomamos el máximo.
  public static string? CategoriaConMasProductos(List<Product> products) =>
    products
      .GroupBy(p => p.Category)
      .MaxBy(grupo => grupo.Count())
      ?.Key;

  // Ejercicio 24: Obtener el stock total de todos los productos.
  // Sum() acumula el valor de la propiedad indicada en el selector.
  public static int StockTotal(List<Product> products) =>
    products.Sum(p => p.Stock);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 6 – CONSULTAS SOBRE STRINGS (Ejercicios 25–27, 33, 35, 39)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 25: Obtener el producto con el nombre más largo.
  // MaxBy compara la longitud (número de caracteres) del nombre.
  public static Product? ProductoNombreMasLargo(List<Product> products) =>
    products.MaxBy(p => p.Name.Length);

  // Ejercicio 26: Obtener el producto con la descripción más corta.
  // MinBy compara la longitud (número de caracteres) de la descripción.
  public static Product? ProductoDescripcionMasCorta(List<Product> products) =>
    products.MinBy(p => p.Description.Length);

  // Ejercicio 27: Filtrar los productos cuya descripción contenga la palabra "pantalla".
  // Contains con StringComparison permite búsqueda insensible a mayúsculas.
  public static IEnumerable<Product> DescripcionContienePantalla(List<Product> products) =>
    products.Where(p => p.Description.Contains("pantalla", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 33: Obtener los productos cuyo nombre tenga más de 10 caracteres.
  public static IEnumerable<Product> NombreMasDe10Caracteres(List<Product> products) =>
    products.Where(p => p.Name.Length > 10);

  // Ejercicio 35: Obtener los productos cuyo nombre contenga la palabra "Pro".
  public static IEnumerable<Product> NombreContienePro(List<Product> products) =>
    products.Where(p => p.Name.Contains("Pro", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 39: Obtener los productos que tengan exactamente dos palabras en su nombre.
  // Split divide el nombre por espacios y contamos los fragmentos no vacíos.
  public static IEnumerable<Product> NombreConDosPalabras(List<Product> products) =>
    products.Where(p =>
      p.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 2);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 7 – CONSULTAS NUMÉRICAS Y MATEMÁTICAS (Ejercicios 28–32, 34, 36, 38)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 28: Obtener el promedio de stock de los productos de "Almacenamiento".
  // Filtramos primero con Where y luego calculamos el promedio con Average.
  public static double PromedioStockAlmacenamiento(List<Product> products) =>
    products
      .Where(p => p.Category.Equals("Almacenamiento", StringComparison.OrdinalIgnoreCase))
      .Average(p => p.Stock);

  // Ejercicio 29: Obtener los productos creados en una fecha específica.
  // Comparamos solo la parte de fecha (sin hora) usando Date.
  public static IEnumerable<Product> CreadosEnFecha(List<Product> products, DateTime fecha) =>
    products.Where(p => p.CreatedAt.Date == fecha.Date);

  // Ejercicio 30: Obtener los productos cuya ID sea par.
  // El operador módulo (%) devuelve 0 cuando el número es divisible entre 2.
  public static IEnumerable<Product> IdPar(List<Product> products) =>
    products.Where(p => p.Id % 2 == 0);

  // Ejercicio 31: Obtener los productos cuya ID sea impar.
  // El operador módulo (%) devuelve 1 cuando el número no es divisible entre 2.
  public static IEnumerable<Product> IdImpar(List<Product> products) =>
    products.Where(p => p.Id % 2 != 0);

  // Ejercicio 32: Obtener los productos cuyo precio tenga parte decimal mayor a .50.
  // (price % 1) extrae la parte decimal; ej. 99.75 % 1 = 0.75
  public static IEnumerable<Product> PrecioConDecimalMayorA50(List<Product> products) =>
    products.Where(p => p.Price % 1 > 0.50m);

  // Ejercicio 34: Obtener los productos cuyo stock sea un número primo.
  // EsPrimo es un método auxiliar privado definido más abajo.
  public static IEnumerable<Product> StockEsPrimo(List<Product> products) =>
    products.Where(p => EsPrimo(p.Stock));

  // Ejercicio 36: Obtener los productos cuyo stock sea múltiplo de 5.
  public static IEnumerable<Product> StockMultiploDe5(List<Product> products) =>
    products.Where(p => p.Stock % 5 == 0);

  // Ejercicio 37: Obtener los productos con descripción de más de 20 caracteres.
  public static IEnumerable<Product> DescripcionMasDe20Caracteres(List<Product> products) =>
    products.Where(p => p.Description.Length > 20);

  // Ejercicio 38: Obtener los productos cuyo precio sea un número redondo (sin decimales).
  // (price % 1 == 0) es true cuando no existe parte decimal.
  public static IEnumerable<Product> PrecioRedondo(List<Product> products) =>
    products.Where(p => p.Price % 1 == 0);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 8 – OTROS (Ejercicio 40)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 40: Obtener la cantidad de productos que no pertenecen a "General".
  // Count con predicado es más compacto que Where + Count por separado.
  public static int ProductosQueNoSonGeneral(List<Product> products) =>
    products.Count(p => !p.Category.Equals("General", StringComparison.OrdinalIgnoreCase));

  // ─────────────────────────────────────────────────────────────────────────
  //  MÉTODOS AUXILIARES PRIVADOS
  // ─────────────────────────────────────────────────────────────────────────

  // Determina si un número entero es primo.
  // Un primo es divisible únicamente por 1 y por sí mismo.
  private static bool EsPrimo(int number)
  {
    if (number < 2) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    // Solo necesitamos comprobar divisores hasta la raíz cuadrada del número
    for (int i = 3; i <= Math.Sqrt(number); i += 2)
    {
      if (number % i == 0) return false;
    }
    return true;
  }
}
