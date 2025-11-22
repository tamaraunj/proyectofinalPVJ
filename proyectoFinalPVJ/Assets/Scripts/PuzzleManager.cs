using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private int[] patronCorrecto = { 2, 0, 1, 3 };
    private int indice = 0;

    public void RecibirInput(int idInterruptor)
    {
        if (idInterruptor == patronCorrecto[indice])
        {
            Debug.Log("Correcto: " + idInterruptor);
            indice++;

            if(indice >= patronCorrecto.Length)
            {
                Debug.Log("Puzzle CORRECTO");
                indice = 0;
            }
        }
        else
        {
            /* Reiniciar si el jugador se equivoca*/
            Debug.Log("Incorrecto. Reiniciando...");
            indice = 0;
        }
    }

}
