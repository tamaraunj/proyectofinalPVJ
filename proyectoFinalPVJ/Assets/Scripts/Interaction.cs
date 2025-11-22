using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform camara;
    [SerializeField] private float rango;

    void Update()
    {
        if (Physics.Raycast(camara.position, camara.forward, out RaycastHit hit, rango))
        {
                if (hit.collider.GetComponent<Switch>()!=null && Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.GetComponent<Switch>().Activar();
                }
            
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(camara.position, camara.forward * rango);
    }
}
