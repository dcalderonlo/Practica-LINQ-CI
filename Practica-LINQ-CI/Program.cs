using Practica_LINQ_CI.src.Exercises;
using Practica_LINQ_CI.src.Interfaces;
using Practica_LINQ_CI.src.Services;

//  PRINCIPIOS SOLID APLICADOS:
//
//  ✓ SRP (Single Responsibility Principle)
//    Cada clase tiene una única responsabilidad claramente definida
//
//  ✓ OCP (Open/Closed Principle)
//    Se pueden agregar nuevos ejercicios sin modificar código existente
//    mediante la implementación de IExercise
//
//  ✓ LSP (Liskov Substitution Principle)
//    Todas las implementaciones son sustituibles por sus interfaces
//
//  ✓ ISP (Interface Segregation Principle)
//    Interfaces pequeñas y específicas para cada responsabilidad
//
//  ✓ DIP (Dependency Inversion Principle)
//    Dependemos de abstracciones (interfaces), no de implementaciones concretas
//
// ═══════════════════════════════════════════════════════════════════════════════

// Composition Root: configuración manual de inyección de dependencias
var app = ConfigureApplication();
app.Run();

// ─────────────────────────────────────────────────────────────────────────────
//  CONFIGURACIÓN DE DEPENDENCIAS (Manual Dependency Injection)
// ─────────────────────────────────────────────────────────────────────────────

// Configura todas las dependencias de la aplicación (Composition Root).
// Este es el único lugar donde se crean instancias concretas.
// Aplica DIP: el resto del código solo conoce interfaces.
static ApplicationRunner ConfigureApplication()
{
  // Servicios básicos (implementaciones concretas)
  IProductDataSource dataSource = new MockProductDataSource();
  IMenuService menuService = new ConsoleMenuService();
  IDisplayService displayService = new ConsoleDisplayService();
  IProductQueryService queryService = new ProductQueryService();

  // Creación de todos los ejercicios (aplicación de OCP)
  // Para agregar un nuevo ejercicio, solo se necesita agregar una línea aquí
  var exercises = new List<IExercise>
  {
    new Exercise01(queryService, displayService),
    new Exercise02(queryService, displayService),
    new Exercise03(queryService, displayService),
    new Exercise04(queryService, displayService),
    new Exercise05(queryService, displayService),
    new Exercise06(queryService, displayService),
    new Exercise07(queryService, displayService),
    new Exercise08(queryService, displayService),
    new Exercise09(queryService, displayService),
    new Exercise10(queryService, displayService),
    new Exercise11(queryService, displayService),
    new Exercise12(queryService, displayService),
    new Exercise13(queryService, displayService),
    new Exercise14(queryService, displayService),
    new Exercise15(queryService, displayService),
    new Exercise16(queryService, displayService),
    new Exercise17(queryService, displayService),
    new Exercise18(queryService, displayService),
    new Exercise19(queryService, displayService),
    new Exercise20(queryService, displayService),
    new Exercise21(queryService, displayService),
    new Exercise22(queryService, displayService),
    new Exercise23(queryService, displayService),
    new Exercise24(queryService, displayService),
    new Exercise25(queryService, displayService),
    new Exercise26(queryService, displayService),
    new Exercise27(queryService, displayService),
    new Exercise28(queryService, displayService),
    new Exercise29(queryService, displayService),
    new Exercise30(queryService, displayService),
    new Exercise31(queryService, displayService),
    new Exercise32(queryService, displayService),
    new Exercise33(queryService, displayService),
    new Exercise34(queryService, displayService),
    new Exercise35(queryService, displayService),
    new Exercise36(queryService, displayService),
    new Exercise37(queryService, displayService),
    new Exercise38(queryService, displayService),
    new Exercise39(queryService, displayService),
    new Exercise40(queryService, displayService),
  };

  // Retorna el runner completamente configurado con todas sus dependencias
  return new ApplicationRunner(dataSource, menuService, displayService, queryService, exercises);
}
