using UnityEngine;

public class DoorController : MonoBehaviour
{
    public void AbrirPuerta()
    {
        transform.position += new Vector3(0, 3, 0); 
    }
}
