using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Interfaces;

// Define el contrato para servicios de presentación de resultados en consola.
// Aplicación del principio ISP (Interface Segregation Principle).
public interface IDisplayService
{
  void PrintProducts(string title, IEnumerable<Product> list);
  void PrintProduct(string title, Product? product);
  void PrintStrings(string title, IEnumerable<string> list);
  void PrintGroupsProductsByCategory(string title, IEnumerable<IGrouping<string, Product>> groups);
  void PrintValue(string title, object value);
}
