using UnityEngine;

public class RightButton : MonoBehaviour
{
    public Transform tubo2;
    public Transform tubo3;
    public Transform[] posiciones; // 0=izquierda, 1=medio, 2=derecha
    public Transform[] tubos;      // tubos en cada posición actual

    void Start()
    {
        // Inicializa tubos en las posiciones físicas correctas
        for (int i = 0; i < tubos.Length; i++)
        {
            tubos[i].position = posiciones[i].position;
        }
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.R))
        {
            Intercambiar(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Intercambiar(1, 2);
        }
    }
    public void Intercambiar(int i, int j)
    {
        
        Transform temp = tubos[i];
        tubos[i] = tubos[j];
        tubos[j] = temp;

        tubos[i].position = posiciones[i].position;
        tubos[j].position = posiciones[j].position;
    }

    public void IntercambiarMedio()
    {
        Intercambiar(0, 1); 
    }

    public void IntercambiarDerecha()
    {
        Intercambiar(1, 2);
    }
}
