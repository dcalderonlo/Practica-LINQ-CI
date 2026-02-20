using Practica_LINQ_CI.src.Interfaces;

namespace Practica_LINQ_CI.src.Services;

// Orquesta la ejecución de la aplicación y gestiona el ciclo de vida principal.
// Aplicación de principios SOLID:
// - SRP: Solo se encarga de la orquestación del flujo principal
// - OCP: Permite agregar ejercicios sin modificar esta clase
// - DIP: Depende de abstracciones (interfaces) en lugar de clases concretas
public class ApplicationRunner(
  IProductDataSource dataSource,
  IMenuService menuService,
  IDisplayService displayService,
  IProductQueryService queryService,
  IEnumerable<IExercise> exercises)
{
  private readonly IProductDataSource _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
  private readonly IMenuService _menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
  private readonly IDisplayService _displayService = displayService ?? throw new ArgumentNullException(nameof(displayService));
  private readonly IProductQueryService _queryService = queryService ?? throw new ArgumentNullException(nameof(queryService));
  private readonly Dictionary<int, IExercise> _exercises = exercises?.ToDictionary(e => e.Number, e => e)
    ?? throw new ArgumentNullException(nameof(exercises));

  // Inicia el bucle principal de la aplicación con el menú interactivo.
  public void Run()
  {
    var products = _dataSource.GetProducts();
    
    while (true)
    {
      _menuService.PrintMenu();
      Console.Write("\nSelecciona un ejercicio (0 para salir): ");
      var input = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Entrada inválida. Por favor ingresa un número.");
        continue;
      }

      if (input.Trim() == "0")
      {
        Console.WriteLine("\n¡Hasta pronto!\n");
        return;
      }

      if (!int.TryParse(input, out var option))
      {
        Console.WriteLine("Entrada inválida. Ingresa un número del 1 al 40.");
        continue;
      }

      // Aplicación de OCP: si el ejercicio existe en el diccionario, se ejecuta
      // Sin necesidad de modificar este código al agregar nuevos ejercicios
      if (_exercises.TryGetValue(option, out var exercise))
      {
        try
        {
          exercise.Execute(products);
        }
        catch (Exception ex)
        {
          _displayService.PrintValue("Error al ejecutar el ejercicio", ex.Message);
        }
      }
      else
      {
        Console.WriteLine($"Opción no válida. Ingresa un número del 1 al {_exercises.Count}.");
      }
    }
  }
}
