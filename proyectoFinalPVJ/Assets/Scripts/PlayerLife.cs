using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int vidaTotal;
    private int vidaActual;

    private void Start()
    {
        vidaActual = vidaTotal;
    }

    public void RestarVida(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log("Vidas restantes: " + vidaActual);

        if (vidaActual <= 0) Morir();
       
    }
    public void Morir()
    {
        Debug.Log("GAME OVER");
    }
}
