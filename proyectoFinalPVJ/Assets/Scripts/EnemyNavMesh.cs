using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public NavMeshAgent enemigo;
    [SerializeField] private Transform jugador;
    [SerializeField] private float velocidadEnemigo;
    [SerializeField] private float rango;
    [SerializeField] private float distancia;
    public bool persiguiendo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       enemigo = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(enemigo.transform.position, jugador.position);
        persiguiendo = distancia <=rango;
        if(persiguiendo)
        {
            enemigo.speed = velocidadEnemigo;
            enemigo.SetDestination(jugador.position);
        }
        else
        {
            enemigo.speed = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
