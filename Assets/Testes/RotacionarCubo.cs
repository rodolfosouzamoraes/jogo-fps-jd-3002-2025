using UnityEngine;

public class RotacionarCubo : MonoBehaviour
{
    public float velocidade;
    private float angulo = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotacionarPeloVector3();
    }

    public void RotacionarPeloRotate()
    {
        transform.Rotate(0, -1, 0);
    }
    public void RotacionarPeloEuler()
    {
        //Incrementar o angulo a ser rotacionado
        angulo += velocidade * Time.deltaTime;
        //Inserir o angulo novo na rotacao
        transform.rotation = Quaternion.Euler(0, angulo, 0);
    }
    public void RotacionarPeloVector3()
    {
        //Incrementar o angulo a ser rotacionado
        angulo += velocidade * Time.deltaTime;
        //Inserir o angulo novo na rotacao
        transform.eulerAngles = new Vector3(0, angulo, 0);
    }
}
