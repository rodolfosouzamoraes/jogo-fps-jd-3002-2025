using UnityEngine;
using UnityEngine.AI;

public class RondaInimigo : MovimentarInimigo
{
    public float distanciaPerseguicao;
    private Vector3 posicaoInicial;

    void Start()
    {
        //Referenciar a IA do inimigo
        agent = GetComponent<NavMeshAgent>();

        //Definir a velocidade de movimentacao do inimigo
        agent.speed = velocidade;

        posicaoInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar a distancia com o player para poder perseguir
        float distanciaPlayer = Vector3.Distance(transform.position,
            PlayerMng.Instance.transform.position);
        if (distanciaPlayer < distanciaPerseguicao) {
            //Perseguir o player
            PerseguirPlayer();
        }
        else
        {
            //Mandar para a posicao inicial
            agent.destination = posicaoInicial;
        }
    }
}
