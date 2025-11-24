using UnityEngine;

public class TubeManager : MonoBehaviour
{
    public Transform[] posiciones;
    public Tube[] tubos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < tubos.Length; i++)
        {
            tubos[i].transform.position = posiciones[i].position;
        }
    }
    // Update is called once per frame
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
        if (Input.GetKeyDown(KeyCode.F))
        {
            AgregarLiquido();
        }

    }
    public void Intercambiar(int i, int j)
    {

        Tube temp = tubos[i];
        tubos[i] = tubos[j];
        tubos[j] = temp;

        tubos[i].transform.position = posiciones[i].position;
        tubos[j].transform.position = posiciones[j].position;
    }

    public void IntercambiarMedio()
    {
        Intercambiar(0, 1);
    }

    public void IntercambiarDerecha()
    {
        Intercambiar(1, 2);
    }

    public void AgregarLiquido()
    {
        Tube tuboDestino = tubos[0];
        Tube tuboOrigen = tubos[1];

        float cantidadAEliminar = tuboOrigen.cantidadActual;
        float retirada = tuboOrigen.EliminarLiquido(cantidadAEliminar);
        tuboDestino.AgregarLiquido(retirada);
    }
}
