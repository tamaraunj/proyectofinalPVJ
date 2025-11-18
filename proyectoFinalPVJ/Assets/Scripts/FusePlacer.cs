using UnityEngine;

public class FusePlacer : MonoBehaviour
{
    public GameObject fusibleVisible;
    public GameObject fusibleVacio;
    public GameObject luzVerdePanel;
    public Light luzPuerta;
    public GameObject puerta;
    private bool fusibleColocado = false;
    public Renderer esfera;
    public Material materialVerde;
    private void OnTriggerEnter(Collider other)
    {
        FuseCollector player = other.GetComponent<FuseCollector>();
        if (player != null && player.tieneFusible && !fusibleColocado)
        {
            fusibleColocado = true;
            player.tieneFusible = false;

            fusibleVisible.SetActive(true);
            fusibleVacio.SetActive(false);
            luzVerdePanel.SetActive(true);
            luzPuerta.color = Color.green;
            esfera.material = materialVerde;
            puerta.GetComponent<DoorController>().AbrirPuerta();
        }
    }
}
