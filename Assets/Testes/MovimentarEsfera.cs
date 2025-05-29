using UnityEngine;

public class MovimentarEsfera : MonoBehaviour
{
    public float velocidade;
    public float forca;
    private Rigidbody corpo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        corpo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarPelaForca();
    }

    public void MovimentarPelaPosicao()
    {
        transform.position += Vector3.forward * velocidade * Time.deltaTime;
    }
    public void MovimentarPeloTranslate()
    {
        transform.Translate(Vector3.forward * velocidade * Time.deltaTime);
    }
    public void MovimentarPelaForca()
    {
        corpo.AddForce(Vector3.forward * forca * Time.deltaTime);
    }
}
