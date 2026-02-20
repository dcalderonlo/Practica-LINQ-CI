# Proyecto LINQ - Consultas sobre Productos

Aplicación de consola en C# para practicar consultas LINQ sobre una colección de productos, con una arquitectura basada en interfaces y principios SOLID.

---

## 📋 Tabla de contenidos

- [Características](#-características)
- [Arquitectura actual](#-arquitectura-actual)
- [Estructura real del proyecto](#-estructura-real-del-proyecto)
- [Principios SOLID aplicados](#-principios-solid-aplicados)
- [Cómo agregar un nuevo ejercicio](#-cómo-agregar-un-nuevo-ejercicio)
- [Requisitos](#-requisitos)
- [Ejecución](#-ejecución)

---

## ✨ Características

- 40 ejercicios LINQ (`Exercise01` a `Exercise40`).
- Menú interactivo en consola para ejecutar ejercicios individuales.
- Arquitectura desacoplada con contratos (`Interfaces`) e implementaciones (`Services`).
- Datos mock en memoria (`MockProductDataSource`) con 100 productos.
- Sin dependencias externas: usa solo bibliotecas estándar de .NET.

---

## 🧱 Arquitectura actual

Flujo principal de la aplicación:

1. `Program.cs` (Composition Root) crea todas las dependencias concretas.
2. `ApplicationRunner` recibe dependencias por interfaces e inicia el ciclo principal.
3. `IMenuService` imprime el menú y el usuario selecciona un ejercicio.
4. `ApplicationRunner` busca el ejercicio en un `Dictionary<int, IExercise>`.
5. El ejercicio ejecuta una consulta de `IProductQueryService` y muestra resultados con `IDisplayService`.

Resumen visual:

```text
Program.cs (Composition Root)
            │
            ▼
     ApplicationRunner
   (orquesta el flujo)
      │      │      │
      ▼      ▼      ▼
 IProductDataSource  IMenuService  IExercise[]
      │                         │
      ▼                         ▼
 List<Product>          Execute(List<Product>)
                               │
                               ▼
                  IProductQueryService + IDisplayService
```
---

## 📁 Estructura real del proyecto

```text
Tarea práctica 4 - Unidad 4/
├── README.md
├── Tarea práctica 4 - Unidad 4.slnx
└── Practica-LINQ-CI/
    ├── Practica-LINQ-CI.csproj
    ├── Program.cs
    └── src/
        ├── Exercises/
        │   └── AllExercises.cs
        ├── Interfaces/
        │   ├── IDisplayService.cs
        │   ├── IExercise.cs
        │   ├── IMenuService.cs
        │   ├── IProductDataSource.cs
        │   └── IProductQueryService.cs
        ├── Models/
        │   └── Product.cs
        └── Services/
            ├── ApplicationRunner.cs
            ├── ConsoleDisplayService.cs
            ├── ConsoleMenuService.cs
            ├── MockProductDataSource.cs
            └── ProductQueryService.cs
```

---

## 🏗️ Principios SOLID aplicados

- **SRP**: cada clase tiene una responsabilidad clara (`ProductQueryService` consulta, `ConsoleDisplayService` presenta, `ApplicationRunner` orquesta).
- **OCP**: se agregan ejercicios nuevos implementando `IExercise` sin cambiar `ApplicationRunner`.
- **LSP**: las implementaciones son intercambiables por sus interfaces.
- **ISP**: interfaces pequeñas y específicas (`IMenuService`, `IProductDataSource`, etc.).
- **DIP**: la app depende de abstracciones; las clases concretas se instancian en `Program.cs`.

---

## 🆕 Cómo agregar un nuevo ejercicio

1. Crear `Exercise41` en `src/Exercises/AllExercises.cs` (o en otro archivo dentro de `Exercises`) implementando `IExercise` o heredando de `BaseExercise`.
2. Registrar la nueva instancia en la lista `exercises` dentro de `ConfigureApplication()` en `Program.cs`.
3. (Opcional) Si requiere una nueva consulta, agregarla en `IProductQueryService` e implementarla en `ProductQueryService`.

No es necesario modificar `ApplicationRunner` para que el nuevo ejercicio se ejecute.

---

## 🔧 Requisitos

- .NET 10.0 o superior.
- macOS, Windows o Linux.

---

## ▶️ Ejecución

Desde la carpeta del proyecto `Practica-LINQ-CI`:

```bash
dotnet build
dotnet run
```

El menú permite seleccionar opciones del 1 al 40 (0 para salir).

---

## 📚 Temas LINQ practicados

Incluye filtros, proyecciones, ordenamientos, agregaciones, cuantificadores, agrupaciones, condiciones compuestas y consultas sobre fechas/texto/números.

---

## 👤 Autor

Proyecto académico para práctica de LINQ y diseño orientado a SOLID en C#.
