using UnityEngine;
using UnityEngine.Rendering;

public class Tube : MonoBehaviour
{
    public float capacidadMaxima = 100f;
    public float cantidadActual = 0f;
    
    public float AgregarLiquido(float cantidad)
    {
        float espacioDisponible = capacidadMaxima - cantidadActual;
        float cantidadAgregada = Mathf.Min(cantidad, espacioDisponible);
        cantidadActual += cantidadAgregada;
        return cantidadActual;
    }

    public float EliminarCodigo(float cantidad)
    {
        float cantidadEliminada =  Mathf.Min(cantidad, cantidadActual); 
        cantidadActual -= cantidadEliminada;
        return cantidadEliminada;
    }
}
