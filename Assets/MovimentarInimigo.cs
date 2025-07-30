using UnityEngine;
using UnityEngine.AI;

public class MovimentarInimigo : MonoBehaviour
{
    private NavMeshAgent agent; //IA do Inimigo
    public float velocidade; //velocidade da movimentação

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

    private void PerseguirPlayer()
    {
        //Fazer o inimigo ir até o jogador
        agent.destination = PlayerMng.Instance.transform.position;
    }
}
