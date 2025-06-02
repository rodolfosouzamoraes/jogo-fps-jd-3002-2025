using UnityEngine;

public class RotacionarLoucamente : MonoBehaviour
{
    public float velocidade;

    // Update is called once per frame
    void Update()
    {
        Vector3 velocidadeRotacao = Vector3.one * velocidade * Time.deltaTime;
        transform.Rotate(velocidadeRotacao);
    }
}
