using UnityEngine;

public class VisaoPlayer : MonoBehaviour
{
    private RaycastHit hitAlvo;//Variável para armazenar os dados do alvo "visto"
    private GameObject alvo;//Objeto do alvo visto
    public float distancia;//Distancia que o player vai enxergar

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastCamera();
    }

    private void RaycastCamera()
    {
        //Criar um raio que vai partir do centro da camera do player
        Ray raio = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        //Criar uma variavel para armazenar os dados do alvo temporariamente
        RaycastHit hit;

        //Emitir o raio e verificar se "viu" algum objeto
        if (Physics.Raycast(raio, out hit, distancia))
        {
            //Desenhar o raio que está sendo emitido
            Debug.DrawRay(
                transform.position,
                transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.red
            );

            //Armazenar o alvo visto
            hitAlvo = hit;

            //Armazenar o objeto do alvo visto
            alvo = hit.transform.gameObject;
        }
        else
        {
            //Remover o alvo do objeto
            alvo = null;
        }
    }

    public GameObject AlvoVisto()
    {
        return alvo;
    }
}
