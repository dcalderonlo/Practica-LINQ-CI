using Practica_LINQ_CI.Models;

namespace Practica_LINQ_CI.Helpers;
// Contiene los métodos de presentación para imprimir resultados en consola.
internal static class DisplayHelper
{
  // Imprime una colección de productos con su información principal.
  public static void PrintProducts(string title, IEnumerable<Product> list)
  {
    Console.WriteLine($"\n{title}:");
    foreach (var p in list)
      Console.WriteLine($"  - {p.Id}: {p.Name} | ${p.Price:F2} | Stock: {p.Stock} | {p.Category}");
  }

//   static void PrintProducts(string title, IEnumerable<Product> list)
// {
//     Console.WriteLine($"\n{title}:");
//     foreach (var p in list)
//         Console.WriteLine($"  - {p.Id}: {p.Name} | ${p.Price:F2} | Stock: {p.Stock} | {p.Category}");
// }

  // Imprime un único producto. Muestra un aviso si el resultado es nulo.
  public static void PrintProduct(string title, Product? product)
  {
    Console.WriteLine($"\n{title}:");
    if (product is null)
      Console.WriteLine("  (ninguno)");
    else
      Console.WriteLine($"  - {product.Id}: {product.Name} | ${product.Price:F2} | Stock: {product.Stock} | {product.Category}");
  }

//   static void PrintProduct(string title, Product? product)
// {
//     Console.WriteLine($"\n{title}:");
//     if (product is null)
//         Console.WriteLine("  (ninguno)");
//     else
//         Console.WriteLine($"  - {product.Id}: {product.Name} | ${product.Price:F2} | Stock: {product.Stock} | {product.Category}");
// }

  // Imprime una colección de strings simples (ej. solo nombres).
  public static void PrintStrings(string title, IEnumerable<string> list)
  {
    Console.WriteLine($"\n{title}:");
    foreach (var item in list)
      // foreach (var item in list.OrderBy(s => s))
      Console.WriteLine($"  - {item}");
  }

//   static void PrintStrings(string title, IEnumerable<string> list)
// {
//     Console.WriteLine($"\n{title}:");
//     foreach (var item in list)
//         Console.WriteLine($"  - {item}");
// }

  // Imprime los grupos de productos organizados por categoría,
  // mostrando la clave del grupo y cuántos productos contiene.
  public static void PrintGroupsProductsByCategory(string title, IEnumerable<IGrouping<string, Product>> groups)
  {
    Console.WriteLine($"\n{title}:");
    foreach (var group in groups.OrderBy(g => g.Key))
      Console.WriteLine($"  - {group.Key}: {group.Count()} productos");
  }

//   static void PrintGroups(string title, IEnumerable<IGrouping<string, Product>> groups)
// {
//     Console.WriteLine($"\n{title}:");
//     foreach (var group in groups.OrderBy(g => g.Key))
//         Console.WriteLine($"  - {group.Key}: {group.Count()} productos");
// }

  // Imprime un resultado escalar (número, bool, string, etc.).
  public static void PrintValue(string title, object value)
  {
    Console.WriteLine($"\n{title}: {value}");
  }

//   static void PrintValue(string title, object value)
// {
//     Console.WriteLine($"\n{title}: {value}");
// }
}
