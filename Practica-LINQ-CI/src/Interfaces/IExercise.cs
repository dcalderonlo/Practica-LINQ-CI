using Practica_LINQ_CI.src.Models;

namespace Practica_LINQ_CI.src.Interfaces;

// Define el contrato para ejercicios ejecutables.
// Aplicación del principio OCP (Open/Closed Principle) -
// permite agregar nuevos ejercicios sin modificar código existente.
public interface IExercise
{
  // Número del ejercicio en el menú.
  int Number { get; }
  
  // Descripción del ejercicio.
  string Description { get; }
  
  // Ejecuta el ejercicio con la lista de productos proporcionada.
  void Execute(List<Product> products);
}
