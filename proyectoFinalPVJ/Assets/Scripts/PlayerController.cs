using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    //[SerializeField] private float velocidadRotacion;
    [SerializeField] private float salto;
    [SerializeField] private Camera camara;
    [SerializeField] private float sensibilidadMouse;
    private float rotacionX = 0f;
    private bool enPiso = true;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && enPiso) { 
            rb.AddForce(Vector3.up * salto, ForceMode.Impulse);
            enPiso = false;
        }

        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse;

        transform.Rotate(Vector3.up * mouseX);
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 70f);
        
        camara.transform.localRotation = Quaternion.Euler(rotacionX,0f, 0f);
    }

    private void FixedUpdate()
    {
        float moverZ = Input.GetAxis("Vertical");
        float moverX = Input.GetAxis("Horizontal");
       
        Vector3 movimiento = (transform.forward * moverZ + transform.right * moverX)*velocidadMovimiento*Time.fixedDeltaTime;
        rb.MovePosition(rb.position +  movimiento); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso")){
            enPiso=true;
        }
    }
}
