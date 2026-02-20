using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Interfaces;

// Define el contrato para servicios que realizan consultas LINQ sobre productos.
// Aplicación del principio ISP (Interface Segregation Principle).
public interface IProductQueryService
{
  IEnumerable<Product> GetAllProducts(List<Product> products);
  IEnumerable<string> GetProductNames(List<Product> products);
  IEnumerable<Product> GetPriceGT500(List<Product> products);
  IEnumerable<Product> GetStockLT10(List<Product> products);
  IEnumerable<Product> GetElectronicsCat(List<Product> products);
  IEnumerable<Product> GetNameStarL(List<Product> products);
  IEnumerable<Product> GetPrice100To500(List<Product> products);
  IEnumerable<Product> GetOrdByPriceAsc(List<Product> products);
  IEnumerable<Product> GetOrdByPriceDesc(List<Product> products);
  IEnumerable<Product> GetOrdByName(List<Product> products);
  IEnumerable<Product> GetOrdByStockDesc(List<Product> products);
  IEnumerable<Product> GetTop5Expensive(List<Product> products);
  IEnumerable<Product> GetTop10LowestStock(List<Product> products);
  int GetTotalProducts(List<Product> products);
  decimal GetTotalPrice(List<Product> products);
  double GetAvgPrice(List<Product> products);
  Product? GetMostExpensive(List<Product> products);
  Product? GetCheapest(List<Product> products);
  bool IsAnyPriceGT1000(List<Product> products);
  bool AreAllStockGT5(List<Product> products);
  int GetAudioCount(List<Product> products);
  IEnumerable<IGrouping<string, Product>> GetGroupByCategory(List<Product> products);
  string? GetCatMostProducts(List<Product> products);
  int GetTotalStock(List<Product> products);
  Product? GetLongestName(List<Product> products);
  Product? GetShortestDesc(List<Product> products);
  IEnumerable<Product> GetDescContainingScreen(List<Product> products);
  double GetAvgStockStorage(List<Product> products);
  IEnumerable<Product> GetProductsCreatedOn(List<Product> products, DateTime date);
  IEnumerable<Product> GetProductsWithEvenId(List<Product> products);
  IEnumerable<Product> GetProductsWithOddId(List<Product> products);
  IEnumerable<Product> GetPriceDecimalGT50(List<Product> products);
  IEnumerable<Product> GetNameLongerThan10Chars(List<Product> products);
  IEnumerable<Product> GetPrimeStock(List<Product> products);
  IEnumerable<Product> GetNameContainingPro(List<Product> products);
  IEnumerable<Product> GetStockMult5(List<Product> products);
  IEnumerable<Product> GetDescLTChar20(List<Product> products);
  IEnumerable<Product> GetRoundPrice(List<Product> products);
  IEnumerable<Product> GetNameWithTwoWords(List<Product> products);
  int GetNotInGeneralCat(List<Product> products);
}
