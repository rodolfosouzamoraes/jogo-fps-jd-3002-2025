using UnityEngine;

public class ColisoesTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Houve Colis�o Trigger.");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Havendo Colis�o Trigger.");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Saiu Colis�o Trigger.");
    }
}
