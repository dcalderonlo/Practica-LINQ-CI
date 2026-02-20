using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Queries;
/// Contiene todos los métodos de consulta LINQ sobre la colección de productos.
/// Cada método resuelve un ejercicio específico de forma aislada y reutilizable.
public static class ProductQueries
{
  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 1 – CONSULTAS BÁSICAS (Ejercicios 1–6)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 1: Obtener todos los productos de la lista.
  // Se usa AsEnumerable() para dejar explícito que trabajamos con LINQ to Objects.
  public static IEnumerable<Product> GetAllProducts(List<Product> products) =>
    products.AsEnumerable();

  // Ejercicio 2: Obtener solo los nombres de todos los productos.
  public static IEnumerable<string> GetProductNames(List<Product> products) =>
    // Select proyecta cada objeto Product a una única propiedad string.
    products.Select(p => p.Name ?? string.Empty);

  // Ejercicio 3: Obtener los productos cuyo precio sea mayor a 500.
  public static IEnumerable<Product> GetPriceGT500(List<Product> products) =>
    // Where filtra los elementos que cumplen la condición dada.
    products.Where(p => p.Price > 500);

  // Ejercicio 4: Obtener los productos con stock menor a 10.
  public static IEnumerable<Product> GetStockLT10(List<Product> products) =>
    products.Where(p => p.Stock < 10);

  // Ejercicio 5: Obtener los productos de la categoría "Electrónica".
  public static IEnumerable<Product> GetElectronicsCat(List<Product> products) =>
    // StringComparison.OrdinalIgnoreCase hace la comparación insensible a mayúsculas.
    products.Where(p => p.Category != null && p.Category.Equals("Electrónica", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 6: Obtener los productos cuyo nombre comience con la letra 'L'.
  public static IEnumerable<Product> GetNameStarL(List<Product> products) =>
    // StartsWith evalúa el prefijo del string de forma eficiente.
    products.Where(p => p.Name != null && p.Name.StartsWith("L", StringComparison.OrdinalIgnoreCase));

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 2 – FILTROS DE RANGO Y ORDENAMIENTO (Ejercicios 7–11)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 7: Obtener los productos cuyo precio esté entre 100 y 500 (inclusive).
  public static IEnumerable<Product> GetPrice100To500(List<Product> products) =>
    products.Where(p => p.Price >= 100 && p.Price <= 500);

  // Ejercicio 8: Obtener los productos ordenados por precio ascendente.
  public static IEnumerable<Product> GetOrdByPriceAsc(List<Product> products) =>
    // OrderBy ordena de menor a mayor.
    products.OrderBy(p => p.Price);

  // Ejercicio 9: Obtener los productos ordenados por precio descendente.
  public static IEnumerable<Product> GetOrdByPriceDesc(List<Product> products) =>
    // OrderByDescending ordena de mayor a menor.
    products.OrderByDescending(p => p.Price);

  // Ejercicio 10: Obtener los productos ordenados por nombre alfabéticamente (A → Z).
  public static IEnumerable<Product> GetOrdByName(List<Product> products) =>
    // StringComparer.CurrentCulture respeta caracteres especiales como tildes y la ñ.
    products.OrderBy(p => p.Name, StringComparer.CurrentCulture);

  // Ejercicio 11: Obtener los productos ordenados por stock de mayor a menor.
  public static IEnumerable<Product> GetOrdByStockDesc(List<Product> products) =>
    products.OrderByDescending(p => p.Stock);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 3 – PAGINACIÓN Y SELECCIÓN LIMITADA (Ejercicios 12–13)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 12: Obtener los primeros 5 productos más caros.
  public static IEnumerable<Product> GetTop5Expensive(List<Product> products) =>
    // Combinamos OrderByDescending con Take para obtener el top N.
    products.OrderByDescending(p => p.Price).Take(5);

  // Ejercicio 13: Obtener los 10 productos con menor stock.
  public static IEnumerable<Product> GetTop10LowestStock(List<Product> products) =>
    // Combinamos OrderBy con Take para obtener el top N.
    products.OrderBy(p => p.Stock).Take(10);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 4 – AGREGACIONES Y ESTADÍSTICAS (Ejercicios 14–20)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 14: Obtener la cantidad total de productos en la lista.
  public static int GetTotalProducts(List<Product> products) =>
    // Count() recorre la colección y devuelve un entero.
    products.Count();

  // Ejercicio 15: Obtener la suma de todos los precios de los productos.
  public static decimal GetTotalPrice(List<Product> products) =>
    products.Sum(p => p.Price);

  // Ejercicio 16: Obtener el precio promedio de los productos.
  public static double GetAvgPrice(List<Product> products) =>
    (double)products.Average(p => p.Price);

  // Ejercicio 17: Obtener el producto más caro.
  public static Product? GetMostExpensive(List<Product> products) =>
    products.MaxBy(p => p.Price);

  // Ejercicio 18: Obtener el producto más barato.
  public static Product? GetCheapest(List<Product> products) =>
    products.MinBy(p => p.Price);

  // Ejercicio 19: Verificar si hay algún producto con precio mayor a 1000.
  public static bool IsAnyPriceGT1000(List<Product> products) =>
    products.Any(p => p.Price > 1000);

  // Ejercicio 20: Verificar si todos los productos tienen stock mayor a 5.
  public static bool AreAllStockGT5(List<Product> products) =>
    products.All(p => p.Stock > 5);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 5 – AGRUPACIONES (Ejercicios 21–24)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 21: Contar cuántos productos hay en la categoría "Audio".
  public static int GetAudioCount(List<Product> products) =>
    products.Count(p => p.Category != null && p.Category.Equals("Audio", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 22: Agrupar los productos por categoría.
  public static IEnumerable<IGrouping<string, Product>> GetGroupByCategory(List<Product> products) =>
    // GroupBy devuelve IGrouping donde cada grupo tiene una clave (categoría)
    // y una colección de los productos que pertenecen a ella.
    products.GroupBy(p => p.Category ?? "Sin Categoría");

  // Ejercicio 23: Obtener la categoría con más productos.
  public static string? GetCatMostProducts(List<Product> products) =>
    products
      .GroupBy(p => p.Category ?? "Sin Categoría")
      .MaxBy(grupo => grupo.Count())
      ?.Key;

  // Ejercicio 24: Obtener el stock total de todos los productos.
  public static int GetTotalStock(List<Product> products) =>
    products.Sum(p => p.Stock);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 6 – CONSULTAS SOBRE STRINGS (Ejercicios 25–27, 33, 35, 39)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 25: Obtener el producto con el nombre más largo.
  public static Product? GetLongestName(List<Product> products) =>
    products.MaxBy(p => p.Name?.Length ?? 0);

  // Ejercicio 26: Obtener el producto con la descripción más corta.
  public static Product? GetShortestDesc(List<Product> products) =>
    products.MinBy(p => p.Description?.Length ?? int.MaxValue);

  // Ejercicio 27: Filtrar los productos cuya descripción contenga la palabra "pantalla".
  public static IEnumerable<Product> GetDescContainingScreen(List<Product> products) =>
    // Contains con StringComparison permite búsqueda insensible a mayúsculas.
    products.Where(p => p.Description != null && p.Description.Contains("pantalla", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 33: Obtener los productos cuyo nombre tenga más de 10 caracteres.
  public static IEnumerable<Product> GetNameLongerThan10Chars(List<Product> products) =>
    products.Where(p => p.Name != null && p.Name.Length > 10);

  // Ejercicio 35: Obtener los productos cuyo nombre contenga la palabra "Pro".
  public static IEnumerable<Product> GetNameContainingPro(List<Product> products) =>
    products.Where(p => p.Name != null && p.Name.Contains("Pro", StringComparison.OrdinalIgnoreCase));

  // Ejercicio 39: Obtener los productos que tengan exactamente dos palabras en su nombre.
  public static IEnumerable<Product> GetNameWithTwoWords(List<Product> products) =>
    products.Where(p =>
      // Split divide el nombre en partes usando espacios y contamos los fragmentos no vacíos;
      // RemoveEmptyEntries ignora espacios extra.
      p.Name != null && p.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 2);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 7 – CONSULTAS NUMÉRICAS Y MATEMÁTICAS (Ejercicios 28–32, 34, 36, 38)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 28: Obtener el promedio de stock de los productos de "Almacenamiento".
  public static double GetAvgStockStorage(List<Product> products) =>
    products
      // Filtramos primero con Where y luego calculamos el promedio con Average.
      .Where(p => p.Category != null && p.Category.Equals("Almacenamiento", StringComparison.OrdinalIgnoreCase))
      .Average(p => p.Stock);

  // Ejercicio 29: Obtener los productos creados en una fecha específica.
  public static IEnumerable<Product> GetProductsCreatedOn(List<Product> products, DateTime date) =>
    products.Where(p => p.CreatedAt.Date == date.Date);

  // Ejercicio 30: Obtener los productos cuya ID sea par.
  public static IEnumerable<Product> GetProductsWithEvenId(List<Product> products) =>
    // El operador módulo (%) devuelve 0 cuando el número es divisible entre 2.
    products.Where(p => p.Id % 2 == 0);

  // Ejercicio 31: Obtener los productos cuya ID sea impar.
  public static IEnumerable<Product> GetProductsWithOddId(List<Product> products) =>
    // El operador módulo (%) devuelve 1 cuando el número no es divisible entre 2.
    products.Where(p => p.Id % 2 != 0);

  // Ejercicio 32: Obtener los productos cuyo precio tenga parte decimal mayor a .50.
  public static IEnumerable<Product> GetPriceDecimalGT50(List<Product> products) =>
    products.Where(p => p.Price % 1 > 0.50m);

  // Ejercicio 34: Obtener los productos cuyo stock sea un número primo.
  public static IEnumerable<Product> GetPrimeStock(List<Product> products) =>
    products.Where(p => IsPrime(p.Stock));

  // Ejercicio 36: Obtener los productos cuyo stock sea múltiplo de 5.
  public static IEnumerable<Product> GetStockMult5(List<Product> products) =>
    products.Where(p => p.Stock % 5 == 0);

  // Ejercicio 37: Obtener los productos con descripción de más de 20 caracteres.
  public static IEnumerable<Product> GetDescLTChar20(List<Product> products) =>
    products.Where(p => p.Description != null && p.Description.Length > 20);

  // Ejercicio 38: Obtener los productos cuyo precio sea un número redondo (sin decimales).
  public static IEnumerable<Product> GetRoundPrice(List<Product> products) =>
    products.Where(p => p.Price % 1 == 0);

  // ─────────────────────────────────────────────────────────────────────────
  //  SECCIÓN 8 – OTROS (Ejercicio 40)
  // ─────────────────────────────────────────────────────────────────────────

  // Ejercicio 40: Obtener la cantidad de productos que no pertenecen a "General".
  public static int GetNotInGeneralCat(List<Product> products) =>
    products.Count(p => p.Category != null && !p.Category.Equals("General", StringComparison.OrdinalIgnoreCase));

  // ─────────────────────────────────────────────────────────────────────────
  //  MÉTODOS AUXILIARES PRIVADOS
  // ─────────────────────────────────────────────────────────────────────────

  // Determina si un número entero es primo.
  // Un primo es divisible únicamente por 1 y por sí mismo.
  private static bool IsPrime(int number)
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
