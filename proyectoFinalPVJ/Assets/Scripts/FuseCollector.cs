using UnityEngine;

public class FuseCollector : MonoBehaviour
{
    public bool tieneFusible = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fusible"))
        {
            tieneFusible=true;
            Destroy(other.gameObject);
        }
    }
}
