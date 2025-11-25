using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    NavMeshAgent agente;
    [SerializeField] private Transform jugador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       agente = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        agente.destination = jugador.position;
    }
}
