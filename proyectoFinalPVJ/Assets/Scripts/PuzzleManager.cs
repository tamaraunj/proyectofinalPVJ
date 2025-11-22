using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    private int[] patronCorrecto = { 2, 0, 1, 3 };
    private int indice = 0;
    [SerializeField] private Light luz;
    [SerializeField] private Renderer esfera;
    [SerializeField] private Material materialVerde;
    private bool puzzleResuelto = false;
    public void RecibirInput(int idInterruptor)
    {
        if (puzzleResuelto)
        {
            Debug.Log("Puzzle TERMINADO");
            return;
        }

        if (idInterruptor == patronCorrecto[indice])
        {
            Debug.Log("Correcto: " + idInterruptor);
            indice++;

            if(indice >= patronCorrecto.Length)
            {
                ResolverPuzzle();

            }
        }
        else
        {
            /* Reiniciar si el jugador se equivoca*/
            Debug.Log("Incorrecto. Reiniciando...");
            indice = 0;
            
        }
    }
    public void ResolverPuzzle()
    {
        Debug.Log("Puzzle CORRECTO");
        indice = 0;
        puzzleResuelto = true;    

        if (luz != null)
        {
            luz.enabled = true;
        }
        if (esfera != null && materialVerde != null)
        {
            esfera.material = materialVerde;
        }
            
    }
}
