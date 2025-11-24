using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private int idInterruptor;
    [SerializeField] private PuzzleManager puzzle;

    public void Activar()
    {
        Debug.Log("Interruptor Presionado: " + idInterruptor);
        puzzle.RecibirInput(idInterruptor);
    }
}
