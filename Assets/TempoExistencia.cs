using UnityEngine;

public class TempoExistencia : MonoBehaviour
{
    public float tempoDestruicao;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, tempoDestruicao);
    }
}
