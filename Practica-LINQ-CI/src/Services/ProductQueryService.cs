using Practica_LINQ_CI.src.Interfaces;
using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Services;

// Implementación concreta del servicio de consultas LINQ sobre productos.
// Aplicación de SRP (Single Responsibility Principle) - solo maneja consultas.
// Implementa IProductQueryService para DIP (Dependency Inversion Principle).
public class ProductQueryService : IProductQueryService
{
  // Devuelve todos los productos sin aplicar ningún filtro.
  public IEnumerable<Product> GetAllProducts(List<Product> products) =>
    products.AsEnumerable();

  // Devuelve los nombres de todos los productos.
  public IEnumerable<string> GetProductNames(List<Product> products) =>
    products.Select(p => p.Name ?? string.Empty);

  // Devuelve los productos con precio mayor a 500.
  public IEnumerable<Product> GetPriceGT500(List<Product> products) =>
    products.Where(p => p.Price > 500);

  // Devuelve los productos con stock menor a 10.
  public IEnumerable<Product> GetStockLT10(List<Product> products) =>
    products.Where(p => p.Stock < 10);

  // Devuelve los productos de la categoría "Electrónica".
  public IEnumerable<Product> GetElectronicsCat(List<Product> products) =>
    products.Where(p => p.Category != null && p.Category.Equals("Electrónica", StringComparison.OrdinalIgnoreCase));

  // Devuelve los productos cuyo nombre comienza con "L".
  public IEnumerable<Product> GetNameStarL(List<Product> products) =>
    products.Where(p => p.Name != null && p.Name.StartsWith("L", StringComparison.OrdinalIgnoreCase));

  // Devuelve los productos con precio entre 100 y 500.
  public IEnumerable<Product> GetPrice100To500(List<Product> products) =>
    products.Where(p => p.Price >= 100 && p.Price <= 500);

  // Devuelve los productos ordenados por precio ascendente.
  public IEnumerable<Product> GetOrdByPriceAsc(List<Product> products) =>
    products.OrderBy(p => p.Price);

  // Devuelve los productos ordenados por precio descendente.
  public IEnumerable<Product> GetOrdByPriceDesc(List<Product> products) =>
    products.OrderByDescending(p => p.Price);

  // Devuelve los productos ordenados por nombre.
  public IEnumerable<Product> GetOrdByName(List<Product> products) =>
    products.OrderBy(p => p.Name, StringComparer.CurrentCulture);

  // Devuelve los productos ordenados por stock descendente.
  public IEnumerable<Product> GetOrdByStockDesc(List<Product> products) =>
    products.OrderByDescending(p => p.Stock);

  // Devuelve los 5 productos más caros.
  public IEnumerable<Product> GetTop5Expensive(List<Product> products) =>
    products.OrderByDescending(p => p.Price).Take(5);

  // Devuelve los 10 productos con menor stock.
  public IEnumerable<Product> GetTop10LowestStock(List<Product> products) =>
    products.OrderBy(p => p.Stock).Take(10);

  // Devuelve el total de productos.
  public int GetTotalProducts(List<Product> products) =>
    products.Count();

  // Devuelve el precio total de todos los productos.
  public decimal GetTotalPrice(List<Product> products) =>
    products.Sum(p => p.Price);

  // Devuelve el precio promedio de todos los productos.
  public double GetAvgPrice(List<Product> products) =>
    (double)products.Average(p => p.Price);

  // Devuelve el producto más caro.
  public Product? GetMostExpensive(List<Product> products) =>
    products.MaxBy(p => p.Price);

  // Devuelve el producto más barato.
  public Product? GetCheapest(List<Product> products) =>
    products.MinBy(p => p.Price);

  // Verifica si hay algún producto con precio mayor a 1000.
  public bool IsAnyPriceGT1000(List<Product> products) =>
    products.Any(p => p.Price > 1000);

  // Verifica si todos los productos tienen stock mayor a 5.
  public bool AreAllStockGT5(List<Product> products) =>
    products.All(p => p.Stock > 5);

  // Cuenta cuántos productos hay en la categoría "Audio".
  public int GetAudioCount(List<Product> products) =>
    products.Count(p => p.Category != null && p.Category.Equals("Audio", StringComparison.OrdinalIgnoreCase));

  // Agrupa los productos por categoría.
  public IEnumerable<IGrouping<string, Product>> GetGroupByCategory(List<Product> products) =>
    products.GroupBy(p => p.Category ?? "Sin Categoría");

  // Obtiene la categoría con más productos.
  public string? GetCatMostProducts(List<Product> products) =>
    products
      .GroupBy(p => p.Category ?? "Sin Categoría")
      .MaxBy(grupo => grupo.Count())
      ?.Key;

  // Obtiene el stock total de todos los productos.
  public int GetTotalStock(List<Product> products) =>
    products.Sum(p => p.Stock);

  // Obtiene el producto con el nombre más largo.
  public Product? GetLongestName(List<Product> products) =>
    products.MaxBy(p => p.Name?.Length ?? 0);

  // Obtiene el producto con la descripción más corta.
  public Product? GetShortestDesc(List<Product> products) =>
    products.MinBy(p => p.Description?.Length ?? int.MaxValue);

  // Filtra productos cuya descripción contenga la palabra "pantalla".
  public IEnumerable<Product> GetDescContainingScreen(List<Product> products) =>
    products.Where(p => p.Description != null && p.Description.Contains("pantalla", StringComparison.OrdinalIgnoreCase));

  // Obtiene el promedio de stock de la categoría "Almacenamiento".
  public double GetAvgStockStorage(List<Product> products) =>
    products
      .Where(p => p.Category != null && p.Category.Equals("Almacenamiento", StringComparison.OrdinalIgnoreCase))
      .Average(p => p.Stock);

  // Obtiene los productos creados en una fecha específica.
  public IEnumerable<Product> GetProductsCreatedOn(List<Product> products, DateTime date) =>
    products.Where(p => p.CreatedAt.Date == date.Date);

  // Obtiene los productos cuya ID sea par.
  public IEnumerable<Product> GetProductsWithEvenId(List<Product> products) =>
    products.Where(p => p.Id % 2 == 0);

  // Obtiene los productos cuya ID sea impar.
  public IEnumerable<Product> GetProductsWithOddId(List<Product> products) =>
    products.Where(p => p.Id % 2 != 0);

  // Obtiene los productos cuyo precio decimal sea mayor a 0.50.
  public IEnumerable<Product> GetPriceDecimalGT50(List<Product> products) =>
    products.Where(p => p.Price % 1 > 0.50m);

  // Obtiene los productos cuyo nombre tenga más de 10 caracteres.
  public IEnumerable<Product> GetNameLongerThan10Chars(List<Product> products) =>
    products.Where(p => p.Name != null && p.Name.Length > 10);

  // Obtiene los productos con stock primo.
  public IEnumerable<Product> GetPrimeStock(List<Product> products) =>
    products.Where(p => IsPrime(p.Stock));

  // Obtiene los productos cuyo nombre contenga la palabra "Pro".
  public IEnumerable<Product> GetNameContainingPro(List<Product> products) =>
    products.Where(p => p.Name != null && p.Name.Contains("Pro", StringComparison.OrdinalIgnoreCase));

  // Obtiene los productos cuyo stock sea un múltiplo de 5.
  public IEnumerable<Product> GetStockMult5(List<Product> products) =>
    products.Where(p => p.Stock % 5 == 0);

  // Obtiene los productos cuya descripción tenga más de 20 caracteres.
  public IEnumerable<Product> GetDescGTChar20(List<Product> products) =>
    products.Where(p => p.Description != null && p.Description.Length > 20);

  // Obtiene los productos cuya descripción tenga menos de 20 caracteres.
  public IEnumerable<Product> GetDescLTChar20(List<Product> products) =>
    products.Where(p => p.Description != null && p.Description.Length < 20);

  // Obtiene los productos cuyo precio sea un número redondo (sin decimales).
  public IEnumerable<Product> GetRoundPrice(List<Product> products) =>
    products.Where(p => p.Price % 1 == 0);

  // Obtiene los productos que tengan exactamente dos palabras en su nombre.
  public IEnumerable<Product> GetNameWithTwoWords(List<Product> products) =>
    products.Where(p =>
      p.Name != null && p.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 2);

  // Obtiene la cantidad de productos que no pertenecen a la categoría "General".
  public int GetNotInGeneralCat(List<Product> products) =>
    products.Count(p => p.Category != null && !p.Category.Equals("General", StringComparison.OrdinalIgnoreCase));

  // Determina si un número entero es primo.
  private static bool IsPrime(int number)
  {
    if (number < 2) return false;
    if (number == 2) return true;
    if (number % 2 == 0) return false;

    for (int i = 3; i <= Math.Sqrt(number); i += 2)
    {
      if (number % i == 0) return false;
    }
    return true;
  }
}
