using UnityEngine;
using UnityEngine.AI;

public class InstanciarInimigos : MonoBehaviour
{
    public InimigoPorLevel[] inimigosPorLevel;
    private int maximoInimigosNaFase; //Definir um valor máximo de inimigos no level
    public float distanciaInicialParaNovoInimigo;// Distancia da qual o inimigo irá surgir no inicio em relação ao player
    public float distanciaParaNovoInimigo; //Distancia para novos inimigos que surgirem
    public float tempoEsperaNovoInimigo; //tempo para esperar cada novo inimigo surgir
    private float tempoProximoInimigo; //tempo para surgir um novo inimigo
    private int totalInimigosInstanciados;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Definindo 0 para o total de inimigos instanciados
        totalInimigosInstanciados = 0;

        //Definir o tempo para instanciar um novo inimigo
        tempoProximoInimigo = tempoEsperaNovoInimigo + Time.timeSinceLevelLoad;

        //Instanciar os primeiros inimigos
        foreach (var inimigoLevel in inimigosPorLevel)
        {
            //Instanciar a quantidade de inimigo por level
            for(int i = 0; i < inimigoLevel.quantidade; i++)
            {
                InstanciarInimigo(distanciaInicialParaNovoInimigo, inimigoLevel.inimigo);
            }
        }

        maximoInimigosNaFase = totalInimigosInstanciados;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se é possivel instanciar novos inimigos
        if((totalInimigosInstanciados < maximoInimigosNaFase) && 
            Time.timeSinceLevelLoad > tempoProximoInimigo)
        {
            //Atualizo o tempo de espera para o proximo inimigo
            tempoProximoInimigo = Time.timeSinceLevelLoad + tempoEsperaNovoInimigo;

            //Instancio o inimigo
            int inimigoSorteado = new System.Random().Next(0, inimigosPorLevel.Length);
            InstanciarInimigo(distanciaParaNovoInimigo, inimigosPorLevel[inimigoSorteado].inimigo);
        }
    }

    private void InstanciarInimigo(float distancia, GameObject inimigo)
    {
        //Definir a posição em Z aleatóriamente onde o inimigo irá surgir
        float posicaoZ = Random.Range(
            PlayerMng.Instance.transform.position.z - distancia,
            PlayerMng.Instance.transform.position.z + distancia
        );

        //Definir a posição em X que o inimigo irá surgir
        float posicaoX = Random.Range(
            PlayerMng.Instance.transform.position.x - distancia,
            PlayerMng.Instance.transform.position.x + distancia
        );

        //Definir a posição no NavMesh
        NavMeshHit posicaoFinal;
        NavMesh.SamplePosition(
            new Vector3(posicaoX, 0, posicaoZ),
            out posicaoFinal,
            Mathf.Infinity,
            1
        );

        //Instanciar um inimigo
        GameObject novoInimigo = Instantiate(inimigo);

        //Referencia do inimigo instanciado com o script InstanciarInimigo
        novoInimigo.GetComponent<DanoInimigo>().ReferenciarInimigo(this);

        //Posicionar o inimigo na posição definida
        NavMeshAgent agent = novoInimigo.GetComponent<NavMeshAgent>();
        agent.enabled = false;
        novoInimigo.transform.position = posicaoFinal.position;
        agent.enabled = true;

        //Sortear uma rotação para o inimigo
        var rotacaoSorteada = Quaternion.Euler(0, new System.Random().Next(0, 361), 0);

        //Definir a rotação do inimigo
        novoInimigo.transform.rotation = rotacaoSorteada;

        //Incrementar o inimigo na variavel para controle
        totalInimigosInstanciados++;
    }

    public void DecrementarInimigosInstanciados()
    {
        totalInimigosInstanciados--;
    }
}
