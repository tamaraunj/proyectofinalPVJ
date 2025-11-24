using UnityEngine;
public class Tube : MonoBehaviour
{
    public float capacidadMaxima = 100f;
    public float cantidadActual = 0f;
    public Transform liquidoVisual;

    public float AgregarLiquido(float cantidad)
    {
        float espacioDisponible = capacidadMaxima - cantidadActual;
        float cantidadAgregada = Mathf.Min(cantidad, espacioDisponible);
        cantidadActual += cantidadAgregada;
        return cantidadActual;
    }

    public float EliminarLiquido(float cantidad)
    {
        float cantidadEliminada =  Mathf.Min(cantidad, cantidadActual); 
        cantidadActual -= cantidadEliminada;
        return cantidadEliminada;
    }
    void Update()
    {
        ActualizarVisual();

    }
    void ActualizarVisual()
    {
        if (liquidoVisual == null) return;
        float porcentaje = cantidadActual/capacidadMaxima;
        liquidoVisual.localScale = new Vector3(liquidoVisual.localScale.x, porcentaje,liquidoVisual.localScale.z);

        liquidoVisual.localPosition = new Vector3(0,porcentaje / 2f,0);

        liquidoVisual.gameObject.SetActive(porcentaje > 0f);
    }
}
