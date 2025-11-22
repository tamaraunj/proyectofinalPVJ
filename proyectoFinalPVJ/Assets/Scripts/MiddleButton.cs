using UnityEngine;

public class MiddleButton : MonoBehaviour
{
    public Transform tubo1;
    public Transform tubo2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Presionar();
        }
    }
    public void Presionar()
    {
        Vector3 tempPos = tubo1.position;
        tubo1.position = tubo2.position;
        tubo2.position = tempPos;
    }
}
