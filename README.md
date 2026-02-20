# Proyecto LINQ - Consultas sobre Productos

Aplicación de consola en C# que demuestra consultas LINQ sobre una colección de productos, implementando **completamente los principios SOLID**.

---

## 📋 Tabla de Contenidos

- [Características](#características)
- [Principios SOLID Aplicados](#principios-solid-aplicados)
- [Arquitectura del Proyecto](#arquitectura-del-proyecto)
- [Estructura de Carpetas](#estructura-de-carpetas)
- [Cómo Agregar un Nuevo Ejercicio](#cómo-agregar-un-nuevo-ejercicio)
- [Requisitos](#requisitos)
- [Ejecución](#ejecución)

---

## ✨ Características

- **40 ejercicios LINQ** que cubren desde consultas básicas hasta operaciones complejas
- **Menú interactivo** en consola para ejecutar ejercicios individuales
- **Arquitectura extensible** basada en interfaces y patrones de diseño
- **100% SOLID** - Totalmente desacoplado y testeable
- **Sin dependencias externas** - Solo usa las bibliotecas estándar de .NET

---

## 🏗️ Principios SOLID Aplicados

### ✅ **S**ingle Responsibility Principle (SRP)

Cada clase tiene **una única responsabilidad**:

- `ProductQueryService` → Solo ejecuta consultas LINQ
- `ConsoleDisplayService` → Solo presenta resultados en consola
- `ConsoleMenuService` → Solo muestra el menú
- `MockProductDataSource` → Solo provee datos de productos
- `ApplicationRunner` → Solo orquesta el flujo de la aplicación
- Cada `ExerciseXX` → Solo ejecuta un ejercicio específico

### ✅ **O**pen/Closed Principle (OCP)

El código está **abierto a extensión, cerrado a modificación**:

- Para agregar un nuevo ejercicio, solo necesitas:
  1. Crear una clase que implemente `IExercise`
  2. Registrarla en `ConfigureApplication()`
- No es necesario modificar `ApplicationRunner`, el switch gigante fue eliminado
- El patrón **Strategy** permite agregar ejercicios sin tocar código existente

### ✅ **L**iskov Substitution Principle (LSP)

Todas las implementaciones son **sustituibles por sus abstracciones**:

- Cualquier `IProductQueryService` puede reemplazar a `ProductQueryService`
- Cualquier `IDisplayService` puede reemplazar a `ConsoleDisplayService`
- Cualquier `IExercise` funciona con el runner sin cambios

### ✅ **I**nterface Segregation Principle (ISP)

Las interfaces son **pequeñas y específicas**:

- `IProductDataSource` → Solo un método: `GetProducts()`
- `IMenuService` → Solo un método: `PrintMenu()`
- `IDisplayService` → Métodos específicos de presentación
- `IExercise` → Solo tres miembros: `Number`, `Description`, `Execute()`
- `IProductQueryService` → Métodos LINQ específicos (no un "megainterfaz")

### ✅ **D**ependency Inversion Principle (DIP)

Todo depende de **abstracciones (interfaces), no de implementaciones concretas**:

- `ApplicationRunner` no conoce las clases concretas, solo interfaces
- Todos los servicios reciben dependencias via constructor (Dependency Injection)
- El único lugar donde se crean instancias concretas es el **Composition Root** en `Program.cs`

---

## 🧱 Arquitectura del Proyecto

```
┌─────────────────────────────────────────────────────────────┐
│                      Program.cs                             │
│                  (Composition Root)                         │
│  - Configura todas las dependencias                         │
│  - Único lugar con clases concretas                         │
└──────────────────┬──────────────────────────────────────────┘
                   │
                   ▼
┌─────────────────────────────────────────────────────────────┐
│              ApplicationRunner                              │
│   - Orquesta el flujo principal                             │
│   - Depende solo de interfaces                              │
└───┬──────────┬──────────┬──────────┬────────────────────────┘
    │          │          │          │
    ▼          ▼          ▼          ▼
┌─────────┐ ┌────────┐ ┌────────┐ ┌─────────┐
│ Data    │ │ Query  │ │Display │ │ Menu    │
│ Source  │ │Service │ │Service │ │ Service │
└─────────┘ └────────┘ └────────┘ └─────────┘
                   │          │
                   └────┬─────┘
                        │
                        ▼
              ┌──────────────────┐
              │  40 Ejercicios   │
              │  (IExercise)     │
              └──────────────────┘
```

---

## 📁 Estructura de Carpetas

```
Practica-LINQ-CI/
│
├── Program.cs                          ← Composition Root + Entry Point
│
├── src/
│   ├── Interfaces/                     ← Contratos (ISP + DIP)
│   │   ├── IProductQueryService.cs
│   │   ├── IProductDataSource.cs
│   │   ├── IDisplayService.cs
│   │   ├── IMenuService.cs
│   │   └── IExercise.cs
│   │
│   ├── Services/                       ← Implementaciones (SRP)
│   │   ├── ProductQueryService.cs
│   │   ├── MockProductDataSource.cs
│   │   ├── ConsoleDisplayService.cs
│   │   ├── ConsoleMenuService.cs
│   │   └── ApplicationRunner.cs
│   │
│   ├── Exercises/                      ← Ejercicios individuales (OCP)
│   │   └── AllExercises.cs            ← 40 ejercicios (Exercise01-Exercise40)
│   │
│   ├── Models/                         ← Entidades de dominio
│   │   └── product.cs
│   │
│   ├── Queries/                        ← Clase legacy (mantienen compatibilidad)
│   │   └── ProductQueries.cs
│   │
│   ├── Data/                           ← Clase legacy (mantienen compatibilidad)
│   │   └── ProductMocks.cs
│   │
│   └── Helpers/                        ← Clases legacy (mantienen compatibilidad)
│       ├── DisplayHelper.cs
│       └── MenuHelpers.cs
│
└── products.json                       ← Datos de ejemplo (no usado actualmente)
```

---

## 🆕 Cómo Agregar un Nuevo Ejercicio

### Paso 1: Crear la clase del ejercicio

Crea una nueva clase en `src/Exercises/AllExercises.cs` (o en un archivo separado):

```csharp
public class Exercise41 : BaseExercise
{
  public Exercise41(IProductQueryService queryService, IDisplayService displayService)
    : base(41, "Tu descripción aquí", queryService, displayService) { }

  public override void Execute(List<Product> products)
  {
    // Tu lógica LINQ aquí
    var resultado = QueryService.AlgunMetodo(products);
    DisplayService.PrintProducts("41. Tu título", resultado);
  }
}
```

### Paso 2: Registrar en el Composition Root

En `Program.cs`, método `ConfigureApplication()`, agrega:

```csharp
var exercises = new List<IExercise>
{
  // ... ejercicios existentes ...
  new Exercise41(queryService, displayService), // ← Nueva línea
};
```

### Paso 3: (Opcional) Agregar método en IProductQueryService

Si necesitas una nueva consulta LINQ:

1. Agregar firma en `IProductQueryService.cs`
2. Implementar en `ProductQueryService.cs`

**¡Listo!** No necesitas tocar `ApplicationRunner`, ni el menú, ni ningún switch/case.

---

## 🔧 Requisitos

- .NET 10.0 o superior
- Sistema operativo: Windows, macOS o Linux

---

## ▶️ Ejecución

```bash
# Compilar
dotnet build

# Ejecutar
dotnet run

# El menú interactivo te permitirá seleccionar ejercicios del 1 al 40
```

---

## 📚 Conceptos LINQ Cubiertos

Los 40 ejercicios cubren:

- **Proyecciones**: `Select`, `SelectMany`
- **Filtros**: `Where`, `OfType`
- **Ordenamiento**: `OrderBy`, `OrderByDescending`, `ThenBy`
- **Agregaciones**: `Count`, `Sum`, `Average`, `Min`, `Max`
- **Cuantificadores**: `Any`, `All`, `Contains`
- **Particionamiento**: `Take`, `Skip`, `TakeWhile`
- **Agrupamiento**: `GroupBy`
- **Operaciones de conjuntos**: `Distinct`, `Union`, `Intersect`, `Except`
- **Operaciones avanzadas**: `MaxBy`, `MinBy`, predicados complejos

---

## 🎯 Ventajas de esta Arquitectura

✅ **Testeable** - Cada componente puede probarse aisladamente con mocks  
✅ **Mantenible** - Cambios en un componente no afectan a otros  
✅ **Extensible** - Agregar funcionalidad no requiere modificar código existente  
✅ **Legible** - Cada clase tiene un propósito claro y único  
✅ **Desacoplado** - Bajo acoplamiento entre módulos  
✅ **Profesional** - Sigue las mejores prácticas de la industria  

---

## 👤 Autor

Desarrollado como proyecto académico para demostrar la aplicación práctica de principios SOLID en C#.

---

## 📄 Licencia

Proyecto académico - Uso libre para fines educativos.
