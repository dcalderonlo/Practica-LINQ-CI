using Practica_LINQ_CI.src.Interfaces;
using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Services;

// Implementación concreta del servicio de presentación en consola.
// Aplicación de SRP (Single Responsibility Principle) - solo maneja presentación.
// Implementa IDisplayService para DIP (Dependency Inversion Principle).
public class ConsoleDisplayService : IDisplayService
{
  public void PrintProducts(string title, IEnumerable<Product> list)
  {
    Console.WriteLine($"\n{title}:");
    foreach (var p in list)
      Console.WriteLine($"  - {p.Id}: {p.Name} | ${p.Price:F2} | Stock: {p.Stock} | {p.Category}");
  }

  public void PrintProduct(string title, Product? product)
  {
    Console.WriteLine($"\n{title}:");
    if (product is null)
      Console.WriteLine("  (ninguno)");
    else
      Console.WriteLine($"  - {product.Id}: {product.Name} | ${product.Price:F2} | Stock: {product.Stock} | {product.Category}");
  }

  public void PrintStrings(string title, IEnumerable<string> list)
  {
    Console.WriteLine($"\n{title}:");
    foreach (var item in list)
      Console.WriteLine($"  - {item}");
  }

  public void PrintGroupsProductsByCategory(string title, IEnumerable<IGrouping<string, Product>> groups)
  {
    Console.WriteLine($"\n{title}:");
    foreach (var group in groups.OrderBy(g => g.Key))
      Console.WriteLine($"  - {group.Key}: {group.Count()} productos");
  }

  public void PrintValue(string title, object value)
  {
    Console.WriteLine($"\n{title}: {value}");
  }
}
