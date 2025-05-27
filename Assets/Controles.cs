using UnityEngine;

public class Controles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("Letra Q");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Letra W");
        }
        if (Input.GetKeyUp(KeyCode.E)) 
        {
            Debug.Log("Letra E");
        }
    }
}
