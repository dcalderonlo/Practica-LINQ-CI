using Practica_LINQ_CI.Data;
using Practica_LINQ_CI.Models;
using Practica_LINQ_CI.Queries;
using Practica_LINQ_CI.Helpers;

// ═══════════════════════════════════════════════════════════════════════════════
//  LINQ Productos – Punto de entrada de la aplicación
// ═══════════════════════════════════════════════════════════════════════════════

// List<Product> productos = ProductMocks.GetProducts();
RunMenu(products: ProductMocks.GetProducts());

// ─────────────────────────────────────────────────────────────────────────────
//  MENÚ PRINCIPAL
// ─────────────────────────────────────────────────────────────────────────────

// Bucle principal del menú. Solicita al usuario una opción y la ejecuta
// hasta que el usuario elija salir con la opción 0.
static void RunMenu(List<Product> products)
{
  while (true)
  {
    MenuHelper.PrintMenu();
    Console.Write("\nSelecciona un ejercicio (0 para salir): ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
    {
      Console.WriteLine("Entrada inválida.");
      continue;
    }

    if (input.Trim() == "0")
    {
      Console.WriteLine("Saliendo...\n");
      return;
    }

    if (!int.TryParse(input, out var option))
    {
      Console.WriteLine("Entrada inválida. Ingresa un número del 1 al 40.");
      continue;
    }

    ExecuteExercise(option, products);
  }
}

// Recibe la opción elegida por el usuario y llama al método correspondiente de ProductQueries, luego imprime el resultado.
static void ExecuteExercise(int option, List<Product> products)
{
  switch (option)
  {
    case 1:
      DisplayHelper.PrintProducts("1. Todos los productos", ProductQueries.GetAllProducts(products));
      break;

    case 2:
      DisplayHelper.PrintStrings("2. Nombres de todos los productos", ProductQueries.GetProductNames(products));
      break;

    case 3:
      DisplayHelper.PrintProducts("3. Precio mayor a $500", ProductQueries.GetPriceGT500(products));
      break;

    case 4:
      DisplayHelper.PrintProducts("4. Stock menor a 10", ProductQueries.GetStockLT10(products));
      break;

    case 5:
      DisplayHelper.PrintProducts("5. Categoría Electrónica", ProductQueries.GetElectronicsCat(products));
      break;

    case 6:
      DisplayHelper.PrintProducts("6. Nombre empieza con 'L'", ProductQueries.GetNameStarL(products));
      break;

    case 7:
      DisplayHelper.PrintProducts("7. Precio entre $100 y $500", ProductQueries.GetPrice100To500(products));
      break;

    case 8:
      DisplayHelper.PrintProducts("8. Ordenados por precio ascendente", ProductQueries.GetOrdByPriceAsc(products));
      break;

    case 9:
      DisplayHelper.PrintProducts("9. Ordenados por precio descendente", ProductQueries.GetOrdByPriceDesc(products));
      break;

    case 10:
      DisplayHelper.PrintProducts("10. Ordenados por nombre alfabético", ProductQueries.GetOrdByName(products));
      break;

    case 11:
      DisplayHelper.PrintProducts("11. Ordenados por stock (mayor a menor)", ProductQueries.GetOrdByStockDesc(products));
      break;

    case 12:
      DisplayHelper.PrintProducts("12. Top 5 productos más caros", ProductQueries.GetTop5Expensive(products));
      break;

    case 13:
      DisplayHelper.PrintProducts("13. 10 productos con menor stock", ProductQueries.GetTop10LowestStock(products));
      break;

    case 14:
      DisplayHelper.PrintValue("14. Total de productos", ProductQueries.GetTotalProducts(products));
      break;

    case 15:
      DisplayHelper.PrintValue("15. Suma de todos los precios", $"${ProductQueries.GetTotalPrice(products):F2}");
      break;

    case 16:
      DisplayHelper.PrintValue("16. Precio promedio", $"${ProductQueries.GetAvgPrice(products):F2}");
      break;

    case 17:
      DisplayHelper.PrintProduct("17. Producto más caro", ProductQueries.GetMostExpensive(products));
      break;

    case 18:
      DisplayHelper.PrintProduct("18. Producto más barato", ProductQueries.GetCheapest(products));
      break;

    case 19:
      DisplayHelper.PrintValue("19. ¿Existe algún producto con precio mayor a $1000?",
        ProductQueries.IsAnyPriceGT1000(products) ? "Sí" : "No");
      break;

    case 20:
      DisplayHelper.PrintValue("20. ¿Todos los productos tienen stock mayor a 5?",
        ProductQueries.AreAllStockGT5(products) ? "Sí" : "No");
      break;

    case 21:
      DisplayHelper.PrintValue("21. Total de productos en la categoría Audio", ProductQueries.GetAudioCount(products));
      break;

    case 22:
      DisplayHelper.PrintGroupsProductsByCategory("22. Productos agrupados por categoría", ProductQueries.GetGroupByCategory(products));
      break;

    case 23:
      DisplayHelper.PrintValue("23. Categoría con más productos", ProductQueries.GetCatMostProducts(products) ?? "N/A");
      break;

    case 24:
      DisplayHelper.PrintValue("24. Stock total de todos los productos", $"{ProductQueries.GetTotalStock(products):N0} unidades");
      break;

    case 25:
      DisplayHelper.PrintProduct("25. Producto con el nombre más largo", ProductQueries.GetLongestName(products));
      break;

    case 26:
      DisplayHelper.PrintProduct("26. Producto con la descripción más corta", ProductQueries.GetShortestDesc(products));
      break;

    case 27:
      DisplayHelper.PrintProducts("27. Descripción contiene 'pantalla'", ProductQueries.GetDescContainingScreen(products));
      break;

    case 28:
      DisplayHelper.PrintValue("28. Promedio de stock en Almacenamiento",
        $"{ProductQueries.GetAvgStockStorage(products):F2} unidades");
      break;

    case 29:
      Console.Write("\nIngresa una fecha (dd/MM/yyyy): ");
      var inputDate = Console.ReadLine();

      if (!DateTime.TryParseExact(inputDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var date))
      {
        Console.WriteLine("Fecha inválida. Usa el formato dd/MM/yyyy (ej: 20/12/2022).");
        break;
      }

      var dateResult = ProductQueries.GetProductsCreatedOn(products, date).ToList();

      if (dateResult.Count == 0)
        DisplayHelper.PrintValue("29. Productos creados el " + date.ToString("dd/MM/yyyy"), "(ninguno en esa fecha)");
      else
        DisplayHelper.PrintProducts("29. Productos creados el " + date.ToString("dd/MM/yyyy"), dateResult);
      break;

    case 30:
      DisplayHelper.PrintProducts("30. Productos con ID par", ProductQueries.GetProductsWithEvenId(products));
      break;

    case 31:
      DisplayHelper.PrintProducts("31. Productos con ID impar", ProductQueries.GetProductsWithOddId(products));
      break;

    case 32:
      DisplayHelper.PrintProducts("32. Precio con decimal mayor a .50", ProductQueries.GetPriceDecimalGT50(products));
      break;

    case 33:
      DisplayHelper.PrintProducts("33. Nombre con más de 10 caracteres", ProductQueries.GetNameLongerThan10Chars(products));
      break;

    case 34:
      DisplayHelper.PrintProducts("34. Stock es número primo", ProductQueries.GetPrimeStock(products));
      break;

    case 35:
      DisplayHelper.PrintProducts("35. Nombre contiene 'Pro'", ProductQueries.GetNameContainingPro(products));
      break;

    case 36:
      DisplayHelper.PrintProducts("36. Stock es múltiplo de 5", ProductQueries.GetStockMult5(products));
      break;

    case 37:
      DisplayHelper.PrintProducts("37. Descripción con más de 20 caracteres", ProductQueries.GetDescLTChar20(products));
      break;

    case 38:
      var roundPrices = ProductQueries.GetRoundPrice(products).ToList();
      if (roundPrices.Count == 0)
        DisplayHelper.PrintValue("38. Productos con precio redondo", "(ninguno en esta colección)");
      else
        DisplayHelper.PrintProducts("38. Productos con precio redondo", roundPrices);
      break;

    case 39:
      DisplayHelper.PrintProducts("39. Nombre con exactamente dos palabras", ProductQueries.GetNameWithTwoWords(products));
      break;

    case 40:
      DisplayHelper.PrintValue("40. Productos que no pertenecen a 'General'",
        $"{ProductQueries.GetNotInGeneralCat(products)} productos");
      break;

    default:
      Console.WriteLine("Opción no válida. Ingresa un número del 1 al 40.");
      break;
  }
}
