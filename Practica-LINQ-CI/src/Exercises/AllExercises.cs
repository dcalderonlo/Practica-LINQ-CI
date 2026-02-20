using Practica_LINQ_CI.src.Interfaces;
using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Exercises;

// Clase base abstracta para ejercicios que simplifica la implementación.
// Aplicación de Template Method Pattern y principio DRY.
public abstract class BaseExercise(
  int number,
  string description,
  IProductQueryService queryService,
  IDisplayService displayService) : IExercise
{
  protected readonly IProductQueryService QueryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
  protected readonly IDisplayService DisplayService = displayService ?? throw new ArgumentNullException(nameof(displayService));

  public int Number { get; } = number;
  public string Description { get; } = description ?? throw new ArgumentNullException(nameof(description));

  public abstract void Execute(List<Product> products);
}

// ═══════════════════════════════════════════════════════════════════════════
//  IMPLEMENTACIONES CONCRETAS DE EJERCICIOS (1-40)
// ═══════════════════════════════════════════════════════════════════════════

public class Exercise01(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(1, "Todos los productos", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("1. Todos los productos", QueryService.GetAllProducts(products));
}

public class Exercise02(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(2, "Nombres de productos", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintStrings("2. Nombres de productos", QueryService.GetProductNames(products));
}

public class Exercise03(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(3, "Precio > 500", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("3. Precio > $500", QueryService.GetPriceGT500(products));
}

public class Exercise04(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(4, "Stock < 10", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("4. Stock < 10", QueryService.GetStockLT10(products));
}

public class Exercise05(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(5, "Categoría Electrónica", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("5. Categoría Electrónica", QueryService.GetElectronicsCat(products));
}

public class Exercise06(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(6, "Nombre empieza con L", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("6. Nombre empieza con 'L'", QueryService.GetNameStarL(products));
}

public class Exercise07(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(7, "Precio entre 100 y 500", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("7. Precio entre $100 y $500", QueryService.GetPrice100To500(products));
}

public class Exercise08(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(8, "Ordenados por precio ascendente", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("8. Ordenados por precio ascendente", QueryService.GetOrdByPriceAsc(products));
}

public class Exercise09(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(9, "Ordenados por precio descendente", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("9. Ordenados por precio descendente", QueryService.GetOrdByPriceDesc(products));
}

public class Exercise10(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(10, "Ordenados por nombre", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("10. Ordenados por nombre alfabético", QueryService.GetOrdByName(products));
}

public class Exercise11(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(11, "Ordenados por stock desc", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("11. Ordenados por stock (mayor a menor)", QueryService.GetOrdByStockDesc(products));
}

public class Exercise12(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(12, "Top 5 más caros", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("12. Top 5 productos más caros", QueryService.GetTop5Expensive(products));
}

public class Exercise13(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(13, "10 menor stock", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("13. 10 productos con menor stock", QueryService.GetTop10LowestStock(products));
}

public class Exercise14(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(14, "Total productos", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("14. Total de productos", QueryService.GetTotalProducts(products));
}

public class Exercise15(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(15, "Suma precios", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("15. Suma de todos los precios", $"${QueryService.GetTotalPrice(products):F2}");
}

public class Exercise16(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(16, "Precio promedio", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("16. Precio promedio", $"${QueryService.GetAvgPrice(products):F2}");
}

public class Exercise17(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(17, "Más caro", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProduct("17. Producto más caro", QueryService.GetMostExpensive(products));
}

public class Exercise18(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(18, "Más barato", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProduct("18. Producto más barato", QueryService.GetCheapest(products));
}

public class Exercise19(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(19, "Precio > 1000", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("19. ¿Existe algún producto con precio > $1000?",
      QueryService.IsAnyPriceGT1000(products) ? "Sí" : "No");
}

public class Exercise20(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(20, "Todos stock > 5", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("20. ¿Todos los productos tienen stock > 5?",
      QueryService.AreAllStockGT5(products) ? "Sí" : "No");
}

public class Exercise21(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(21, "Total Audio", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("21. Total de productos en categoría Audio", QueryService.GetAudioCount(products));
}

public class Exercise22(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(22, "Agrupar por categoría", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintGroupsProductsByCategory("22. Productos agrupados por categoría",
      QueryService.GetGroupByCategory(products));
}

public class Exercise23(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(23, "Categoría con más productos", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("23. Categoría con más productos",
      QueryService.GetCatMostProducts(products) ?? "N/A");
}

public class Exercise24(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(24, "Stock total", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("24. Stock total de todos los productos",
      $"{QueryService.GetTotalStock(products):N0} unidades");
}

public class Exercise25(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(25, "Nombre más largo", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProduct("25. Producto con el nombre más largo", QueryService.GetLongestName(products));
}

public class Exercise26(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(26, "Descripción más corta", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProduct("26. Producto con la descripción más corta", QueryService.GetShortestDesc(products));
}

public class Exercise27(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(27, "Descripción contiene 'pantalla'", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("27. Descripción contiene 'pantalla'",
      QueryService.GetDescContainingScreen(products));
}

public class Exercise28(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(28, "Promedio stock Almacenamiento", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("28. Promedio de stock en Almacenamiento",
      $"{QueryService.GetAvgStockStorage(products):F2} unidades");
}

public class Exercise29(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(29, "Creados en fecha específica", queryService, displayService)
{
  public override void Execute(List<Product> products)
  {
    Console.Write("\nIngresa una fecha (dd/MM/yyyy): ");
    var inputDate = Console.ReadLine();

    if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null,
      System.Globalization.DateTimeStyles.None, out var date))
    {
      Console.WriteLine("Fecha inválida. Usa el formato dd/MM/yyyy (ej: 20/12/2022).");
      return;
    }

    var result = QueryService.GetProductsCreatedOn(products, date).ToList();
    if (result.Count == 0)
      DisplayService.PrintValue($"29. Productos creados el {date:dd/MM/yyyy}", "(ninguno en esa fecha)");
    else
      DisplayService.PrintProducts($"29. Productos creados el {date:dd/MM/yyyy}", result);
  }
}

public class Exercise30(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(30, "ID par", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("30. Productos con ID par", QueryService.GetProductsWithEvenId(products));
}

public class Exercise31(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(31, "ID impar", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("31. Productos con ID impar", QueryService.GetProductsWithOddId(products));
}

public class Exercise32(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(32, "Decimal > .50", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("32. Precio con decimal > .50", QueryService.GetPriceDecimalGT50(products));
}

public class Exercise33(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(33, "Nombre > 10 caracteres", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("33. Nombre con > 10 caracteres", QueryService.GetNameLongerThan10Chars(products));
}

public class Exercise34(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(34, "Stock primo", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("34. Stock es número primo", QueryService.GetPrimeStock(products));
}

public class Exercise35(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(35, "Nombre contiene 'Pro'", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("35. Nombre contiene 'Pro'", QueryService.GetNameContainingPro(products));
}

public class Exercise36(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(36, "Stock múltiplo de 5", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("36. Stock múltiplo de 5", QueryService.GetStockMult5(products));
}

public class Exercise37(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(37, "Descripción > 20 caracteres", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("37. Descripción > 20 caracteres", QueryService.GetDescLTChar20(products));
}

public class Exercise38(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(38, "Precio redondo", queryService, displayService)
{
  public override void Execute(List<Product> products)
  {
    var result = QueryService.GetRoundPrice(products).ToList();
    if (result.Count == 0)
      DisplayService.PrintValue("38. Productos con precio redondo", "(ninguno en esta colección)");
    else
      DisplayService.PrintProducts("38. Productos con precio redondo", result);
  }
}

public class Exercise39(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(39, "Nombre 2 palabras", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintProducts("39. Nombre con exactamente dos palabras", QueryService.GetNameWithTwoWords(products));
}

public class Exercise40(IProductQueryService queryService, IDisplayService displayService) : BaseExercise(40, "No categoría General", queryService, displayService)
{
  public override void Execute(List<Product> products) =>
    DisplayService.PrintValue("40. Productos que no pertenecen a 'General'",
      $"{QueryService.GetNotInGeneralCat(products)} productos");
}
