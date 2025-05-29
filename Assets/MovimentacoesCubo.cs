using UnityEngine;

public class MovimentacoesCubo : MonoBehaviour
{
    public float velocidade;
    public float forcaRotacao;
    private float angulo = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            angulo -= forcaRotacao * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, angulo, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            angulo += forcaRotacao * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, angulo, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * velocidade * Time.deltaTime);
        }
    }
}
