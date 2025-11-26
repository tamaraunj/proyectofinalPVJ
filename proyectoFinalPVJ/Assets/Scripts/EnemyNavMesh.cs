using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    public NavMeshAgent enemigo; //Referencia al enemigo
    [SerializeField] private Transform jugador; //Transform del jugador
    [SerializeField] private float velocidadEnemigo; //Velocidad de movimiento del enemigo
    [SerializeField] private float rango; //Rango que tiene el enemigo para empezar a seguir al jugador
    [SerializeField] private float radioPatrulla; //Rango para elegir puntos aleatorios donde el enemigo deambulará
    [SerializeField] private float tiempoEntrePuntos; //Tiempo para cambiar el punto si no llegó el enemigo

    private float temporizador; //Temporizador para saber cuándo hay que cambiar de punto
    private Vector3 puntoPatrulla; //Punto actual al que camina el enemigo
    private bool persiguiendo; //Para saber si el enemigo persigue o no al jugador
    private float distancia; //Distancia entre el enemigo y el jugador

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       enemigo = GetComponent<NavMeshAgent>(); //Para obtener el agente navmesh del enemigo
       BuscarNuevoPunto();
    }

    // Update is called once per frame
    void Update()
    {
        //Se calcula la distancia entre el enemigo y jugador
        distancia = Vector3.Distance(enemigo.transform.position, jugador.position);
        //Se evalua si el jugador está dentro del rango del enemigo
        persiguiendo = distancia <=rango;

        if(persiguiendo)
        {
            PerseguirJugador(); //Persigue al jugador
        }
        else
        {
            Deambular(); //Patrulla de forma aleatoria
        }
    }
    void PerseguirJugador()
    {
        enemigo.speed = velocidadEnemigo;
        enemigo.SetDestination(jugador.position);
    }

    void Deambular()
    {
        enemigo.speed = velocidadEnemigo * 0.5f; //Camina más lento cuando no persigue
        temporizador += Time.deltaTime; //Incrementa el temporizador

        //Si el enemigo llega al punto o pasa mucho tiempo, se elige otro punto
        if (Vector3.Distance(transform.position, puntoPatrulla) <1f || temporizador >= tiempoEntrePuntos)
        {
            BuscarNuevoPunto(); //Se elige otro punto aleatorio
        }
        enemigo.SetDestination(puntoPatrulla); //Mover al enemigo a ese punto aleatorio
    }

    void BuscarNuevoPunto()
    {
        temporizador = 0; //Se resetea al jugador
        Vector3 puntoAleatorio = transform.position + Random.insideUnitSphere * radioPatrulla; //Se crea un punto aleatorio dentro del radio de la patrulla
        puntoAleatorio.y = transform.position.y; //Igualamos la altura para evitar que busque puntos arriba/abajo
        NavMeshHit hit;

        //Si encuentra un punto valido dentro del navmesh
        if (NavMesh.SamplePosition(puntoAleatorio, out hit, 2f, NavMesh.AllAreas))
        {
            puntoPatrulla = hit.position; //Se asigna un punto válido del navmesh
        }
    }


    private void OnDrawGizmos()
    {
        //Dibuja rango de persecusion
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);

        //Dibuja el radio donde busca puntos aleatorios
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radioPatrulla);
    }
}
