using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;
    public float velocidadRotacion = 100f;
    public float salto = 5f;
    private bool enPiso = true;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && enPiso) { 
            rb.AddForce(Vector3.up * salto, ForceMode.Impulse);
            enPiso = false;
        }
    }

    private void FixedUpdate()
    {
        float moverVertical = Input.GetAxis("Vertical");
        Vector3 movimientoVertical = transform.forward * moverVertical * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movimientoVertical);
     
        float moverHorizontal = Input.GetAxis("Horizontal");
        //Vector3 movimientoHorizontal = transform.right * moverHorizontal * velocidad * Time.fixedDeltaTime;
    
        //Vector3 movimientoFinal = movimientoVertical + movimientoHorizontal;
        //rb.MovePosition(rb.position + movimientoFinal);

        float rotacion = moverHorizontal * velocidadRotacion * Time.fixedDeltaTime;
        Quaternion giroRotacion=Quaternion.Euler(0f, rotacion, 0f);
        rb.MoveRotation(rb.rotation * giroRotacion );
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piso")){
            enPiso=true;
        }
    }
}
