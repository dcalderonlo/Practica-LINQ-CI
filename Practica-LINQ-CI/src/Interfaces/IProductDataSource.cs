using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Interfaces;

// Define el contrato para fuentes de datos de productos.
// Aplicación del principio DIP (Dependency Inversion Principle).
public interface IProductDataSource
{
  // Obtiene la lista completa de productos disponibles.
  List<Product> GetProducts();
}
