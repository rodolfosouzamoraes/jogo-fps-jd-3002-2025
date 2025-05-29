using UnityEngine;

public class Colisoes : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entrou em Colisão!");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Havendo Colisão!");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Saiu da Colisão!");
    }
}
