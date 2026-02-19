using System.Text.Json;

var products = LoadProducts();
RunMenu(products);

static void RunMenu(List<Product> products)
{
	while (true)
	{
		PrintMenu();
		Console.Write("\nSelecciona un ejercicio (0 para salir): ");
		var input = Console.ReadLine();
		if (string.IsNullOrWhiteSpace(input))
		{
			Console.WriteLine("Entrada invalida.");
			continue;
		}

		if (input.Trim() == "0")
		{
			Console.WriteLine("Saliendo...\n");
			return;
		}

		if (!int.TryParse(input, out var choice))
		{
			Console.WriteLine("Entrada invalida.");
			continue;
		}

		ExecuteExercise(choice, products);
	}
}

static void PrintMenu()
{
	Console.WriteLine("\n--- Menu de ejercicios ---");
	Console.WriteLine(" 1. Obtener todos los productos de la lista.");
	Console.WriteLine(" 2. Obtener los nombres de todos los productos.");
	Console.WriteLine(" 3. Obtener los productos cuyo precio sea mayor a 500.");
	Console.WriteLine(" 4. Obtener los productos con stock menor a 10.");
	Console.WriteLine(" 5. Obtener los productos de la categoria Electronica.");
	Console.WriteLine(" 6. Obtener los productos cuyo nombre comience con la letra L.");
	Console.WriteLine(" 7. Obtener los productos cuyo precio este entre 100 y 500.");
	Console.WriteLine(" 8. Obtener los productos ordenados por precio ascendente.");
	Console.WriteLine(" 9. Obtener los productos ordenados por precio descendente.");
	Console.WriteLine("10. Obtener los productos ordenados por nombre alfabetico.");
	Console.WriteLine("11. Obtener los productos ordenados por stock de mayor a menor.");
	Console.WriteLine("12. Obtener los primeros 5 productos mas caros.");
	Console.WriteLine("13. Obtener los 10 productos con menor stock.");
	Console.WriteLine("14. Obtener la cantidad total de productos en la lista.");
	Console.WriteLine("15. Obtener la suma de todos los precios de los productos.");
	Console.WriteLine("16. Obtener el precio promedio de los productos.");
	Console.WriteLine("17. Obtener el producto mas caro.");
	Console.WriteLine("18. Obtener el producto mas barato.");
	Console.WriteLine("19. Verificar si hay algun producto con precio mayor a 1000.");
	Console.WriteLine("20. Verificar si todos los productos tienen stock mayor a 5.");
	Console.WriteLine("21. Contar cuantos productos hay en la categoria Audio.");
	Console.WriteLine("22. Agrupar los productos por categoria.");
	Console.WriteLine("23. Obtener la categoria con mas productos.");
	Console.WriteLine("24. Obtener el stock total de todos los productos.");
	Console.WriteLine("25. Obtener el producto con el nombre mas largo.");
	Console.WriteLine("26. Obtener el producto con la descripcion mas corta.");
	Console.WriteLine("27. Filtrar los productos cuya descripcion contenga la palabra pantalla.");
	Console.WriteLine("28. Obtener el promedio de stock de la categoria Almacenamiento.");
	Console.WriteLine("29. Obtener los productos creados en una fecha especifica (20/12/2022).");
	Console.WriteLine("30. Obtener los productos cuya ID sea par.");
	Console.WriteLine("31. Obtener los productos cuya ID sea impar.");
	Console.WriteLine("32. Obtener los productos cuyo precio tenga un decimal mayor a .50.");
	Console.WriteLine("33. Obtener los productos cuyo nombre tenga mas de 10 caracteres.");
	Console.WriteLine("34. Obtener los productos cuyo stock sea un numero primo.");
	Console.WriteLine("35. Obtener los productos cuyo nombre contenga la palabra Pro.");
	Console.WriteLine("36. Obtener los productos cuyo stock sea un multiplo de 5.");
	Console.WriteLine("37. Obtener los productos con descripcion de mas de 20 caracteres.");
	Console.WriteLine("38. Obtener los productos cuyo precio sea un numero redondo.");
	Console.WriteLine("39. Obtener los productos que tengan exactamente dos palabras en su nombre.");
	Console.WriteLine("40. Obtener la cantidad de productos que no pertenecen a la categoria General.");
}

static void ExecuteExercise(int choice, List<Product> products)
{
	switch (choice)
	{
		case 1:
			PrintProducts("1. Todos los productos", products);
			break;
		case 2:
			PrintStrings("2. Nombres de productos", products.Select(p => p.Name ?? string.Empty));
			break;
		case 3:
			PrintProducts("3. Precio > 500", products.Where(p => p.Price > 500m));
			break;
		case 4:
			PrintProducts("4. Stock < 10", products.Where(p => p.Stock < 10));
			break;
		case 5:
			PrintProducts("5. Categoria Electronica", products.Where(p => p.Category == "Electrónica"));
			break;
		case 6:
			PrintProducts("6. Nombre inicia con L", products.Where(p => (p.Name ?? string.Empty).StartsWith('L')));
			break;
		case 7:
			PrintProducts("7. Precio entre 100 y 500", products.Where(p => p.Price >= 100m && p.Price <= 500m));
			break;
		case 8:
			PrintProducts("8. Precio ascendente", products.OrderBy(p => p.Price));
			break;
		case 9:
			PrintProducts("9. Precio descendente", products.OrderByDescending(p => p.Price));
			break;
		case 10:
			PrintProducts("10. Nombre alfabetico", products.OrderBy(p => p.Name));
			break;
		case 11:
			PrintProducts("11. Stock descendente", products.OrderByDescending(p => p.Stock));
			break;
		case 12:
			PrintProducts("12. Top 5 mas caros", products.OrderByDescending(p => p.Price).Take(5));
			break;
		case 13:
			PrintProducts("13. 10 menor stock", products.OrderBy(p => p.Stock).Take(10));
			break;
		case 14:
			PrintValue("14. Total productos", products.Count);
			break;
		case 15:
			PrintValue("15. Suma precios", products.Sum(p => p.Price));
			break;
		case 16:
			PrintValue("16. Promedio precios", products.Average(p => p.Price));
			break;
		case 17:
			PrintProducts("17. Producto mas caro", products.OrderByDescending(p => p.Price).Take(1));
			break;
		case 18:
			PrintProducts("18. Producto mas barato", products.OrderBy(p => p.Price).Take(1));
			break;
		case 19:
			PrintValue("19. Existe precio > 1000", products.Any(p => p.Price > 1000m));
			break;
		case 20:
			PrintValue("20. Todos stock > 5", products.All(p => p.Stock > 5));
			break;
		case 21:
			PrintValue("21. Total categoria Audio", products.Count(p => p.Category == "Audio"));
			break;
		case 22:
			PrintGroups("22. Agrupar por categoria", products.GroupBy(p => p.Category ?? "(Sin categoria)"));
			break;
		case 23:
		{
			var topCategory = products
				.GroupBy(p => p.Category ?? "(Sin categoria)")
				.OrderByDescending(g => g.Count())
				.FirstOrDefault();
			PrintValue("23. Categoria con mas productos", topCategory?.Key ?? "N/A");
			break;
		}
		case 24:
			PrintValue("24. Stock total", products.Sum(p => p.Stock));
			break;
		case 25:
			PrintProducts("25. Nombre mas largo", products.OrderByDescending(p => (p.Name ?? string.Empty).Length).Take(1));
			break;
		case 26:
			PrintProducts("26. Descripcion mas corta", products.OrderBy(p => (p.Description ?? string.Empty).Length).Take(1));
			break;
		case 27:
			PrintProducts(
				"27. Descripcion contiene pantalla",
				products.Where(p => (p.Description ?? string.Empty).Contains("pantalla", StringComparison.OrdinalIgnoreCase)));
			break;
		case 28:
		{
			var almacenamiento = products.Where(p => p.Category == "Almacenamiento").ToList();
			PrintValue("28. Promedio stock Almacenamiento", almacenamiento.Count > 0 ? almacenamiento.Average(p => p.Stock) : 0);
			break;
		}
		case 29:
		{
			var targetDate = new DateTime(2022, 12, 20);
			PrintProducts("29. Creados en 20/12/2022", products.Where(p => p.CreatedAt.Date == targetDate.Date));
			break;
		}
		case 30:
			PrintProducts("30. ID par", products.Where(p => p.Id % 2 == 0));
			break;
		case 31:
			PrintProducts("31. ID impar", products.Where(p => p.Id % 2 != 0));
			break;
		case 32:
			PrintProducts("32. Decimal > .50", products.Where(p => p.Price % 1m > 0.50m));
			break;
		case 33:
			PrintProducts("33. Nombre > 10 caracteres", products.Where(p => (p.Name ?? string.Empty).Length > 10));
			break;
		case 34:
			PrintProducts("34. Stock primo", products.Where(p => IsPrime(p.Stock)));
			break;
		case 35:
			PrintProducts("35. Nombre contiene Pro", products.Where(p => (p.Name ?? string.Empty).Contains("Pro", StringComparison.OrdinalIgnoreCase)));
			break;
		case 36:
			PrintProducts("36. Stock multiplo de 5", products.Where(p => p.Stock % 5 == 0));
			break;
		case 37:
			PrintProducts("37. Descripcion > 20 caracteres", products.Where(p => (p.Description ?? string.Empty).Length > 20));
			break;
		case 38:
			PrintProducts("38. Precio redondo", products.Where(p => p.Price % 1m == 0m));
			break;
		case 39:
			PrintProducts(
				"39. Nombre con dos palabras",
				products.Where(p => (p.Name ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 2));
			break;
		case 40:
			PrintValue("40. No categoria General", products.Count(p => p.Category != "General"));
			break;
		default:
			Console.WriteLine("Opcion no valida.");
			break;
	}
}

static List<Product> LoadProducts()
{
	var projectDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
	var jsonPath = Path.Combine(projectDir, "src", "products.json");
	var json = File.ReadAllText(jsonPath);
	var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
	var payload = JsonSerializer.Deserialize<ProductPayload>(json, options);
	return payload?.Products ?? new List<Product>();
}

static void PrintProducts(string title, IEnumerable<Product> items)
{
	Console.WriteLine($"\n{title}:");
	foreach (var product in items)
	{
		var name = product.Name ?? "(Sin nombre)";
		Console.WriteLine($"- {product.Id}: {name} | {product.Price:C} | Stock: {product.Stock} | {product.Category}");
	}
}

static void PrintStrings(string title, IEnumerable<string> items)
{
	Console.WriteLine($"\n{title}:");
	foreach (var item in items)
	{
		Console.WriteLine($"- {item}");
	}
}

static void PrintGroups(string title, IEnumerable<IGrouping<string, Product>> groups)
{
	Console.WriteLine($"\n{title}:");
	foreach (var group in groups.OrderBy(g => g.Key))
	{
		Console.WriteLine($"- {group.Key}: {group.Count()} productos");
	}
}

static void PrintValue(string title, object value)
{
	Console.WriteLine($"\n{title}: {value}");
}

static bool IsPrime(int number)
{
	if (number < 2)
	{
		return false;
	}

	if (number == 2)
	{
		return true;
	}

	if (number % 2 == 0)
	{
		return false;
	}

	var limit = (int)Math.Sqrt(number);
	for (var i = 3; i <= limit; i += 2)
	{
		if (number % i == 0)
		{
			return false;
		}
	}

	return true;
}

internal sealed class ProductPayload
{
	public List<Product>? Products { get; set; }
}

