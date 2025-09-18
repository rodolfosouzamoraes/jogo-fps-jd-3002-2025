using UnityEngine;
using UnityEngine.AI;

public class MovimentarInimigo : MonoBehaviour
{
    protected NavMeshAgent agent; //IA do Inimigo
    public SuporteAnimacaoInimigo animacaoInimigo;//Códigos da animação do inimigo
    public float velocidade; //velocidade da movimentação
    public float distanciaMinimaDoPlayer; //Definir a distancia minima entre o inimigo e o player
    public bool estaVendoPlayer; //Definir se o inimigo está vendo o player

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Referenciar a IA do inimigo
        agent = GetComponent<NavMeshAgent>();

        //Definir a velocidade de movimentacao do inimigo
        agent.speed = velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        PerseguirPlayer();
    }

    protected void PerseguirPlayer()
    {
        //Definir a distancia entre o player e o inimigo
        float distancia = Vector3.Distance(
            transform.position,
            PlayerMng.Instance.transform.position
        );

        //Verificar se a distancia chegou no limite
        if (distancia < distanciaMinimaDoPlayer) { 
            //Fazer o inimigo fique parado onde ele está
            agent.destination = transform.position;

            OlharParaPlayer();

            //Ativar animação de ataque
            animacaoInimigo?.PlayAtacando();
        }
        else
        {
            //Fazer o inimigo ir até o jogador
            agent.destination = PlayerMng.Instance.transform.position;

            estaVendoPlayer = false;

            //Ativar animação de corrida do inimigo
            animacaoInimigo?.PlayCorrendo();
        }        
    }

    private void OlharParaPlayer()
    {
        //Definir para onde o inimigo deve olhar
        Vector3 posicaoJogador = new Vector3(
            PlayerMng.Instance.transform.position.x,
            transform.position.y,
            PlayerMng.Instance.transform.position.z
        );

        //Fazer o inimigo olhar para o jogador
        transform.LookAt(posicaoJogador);

        //Definir que o inimigo estã vendo o jogador
        estaVendoPlayer = true;
    }
}
