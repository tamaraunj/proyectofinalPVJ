using UnityEditor;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float sensibilidad = 100f;
    public float rotacionX = 0f;
    public Transform jugador; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        jugador.Rotate(Vector3.up * mouseX);
    }
}
