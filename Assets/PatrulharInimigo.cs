using UnityEngine;
using UnityEngine.AI;

public class PatrulharInimigo : MovimentarInimigo
{
    public float distanciaParaNovoDestino; //Defini uma tolerancia de distancia nova
    private Vector3 destinoDoInimigo; //Inimigo irá se posicionar
    private DanoInimigo danoInimigo; //Informações sobre o dano do inimigo
    private bool definiuDestinoInicial; //Dizer que o destino inicial foi definido
    void Start()
    {
        //Referenciar a IA do inimigo
        agent = GetComponent<NavMeshAgent>();

        //Definir a velocidade de movimentacao do inimigo
        agent.speed = velocidade;

        //Configurar a variavel danoInimigo
        danoInimigo = GetComponent<DanoInimigo>();
    }

    // Update is called once per frame
    void Update()
    {
        //Definir o destino inicial apenas uma vez
        if (definiuDestinoInicial == false)
        {
            definiuDestinoInicial = true;
            destinoDoInimigo = transform.position;
        }

        //verificar se o inimigo deve perseguir o player
        if (danoInimigo.sofreuDano == true) {
            PerseguirPlayer();
        }
        else
        {
            Patrulhar();
        }
    }

    private void Patrulhar()
    {
        //Verificar se ele chegou ao destino
        if (Vector3.Distance(transform.position, destinoDoInimigo) <0.005f)
        {
            
            //Gerar um novo destino
            //Definir a posição em Z aleatóriamente onde o inimigo irá ir
            float posicaoZ = Random.Range(
                transform.position.z - distanciaParaNovoDestino,
                transform.position.z + distanciaParaNovoDestino
            );

            //Definir a posição em X que o inimigo irá ir
            float posicaoX = Random.Range(
                transform.position.x - distanciaParaNovoDestino,
                transform.position.x + distanciaParaNovoDestino
            );

            //Definir a posição no NavMesh
            NavMeshHit posicaoFinal;
            NavMesh.SamplePosition(
                new Vector3(posicaoX, 0, posicaoZ),
                out posicaoFinal,
                Mathf.Infinity,
                1
            );

            //definir o novo destino
            destinoDoInimigo = new Vector3(
                posicaoFinal.position.x, 
                transform.position.y, 
                posicaoFinal.position.z
            );

        }
        else
        {
            //mandar o inimigo para a posicao
            agent.destination = destinoDoInimigo;
        }
    }
}
