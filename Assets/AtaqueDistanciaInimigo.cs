using UnityEngine;

public class AtaqueDistanciaInimigo : MonoBehaviour
{
    private float distancia;
    public float distanciaDeAtaque;
    public GameObject projetil;
    public float tempoEspera;
    private float tempoAtaque;

    private void Start()
    {
        tempoAtaque = Time.time + tempoEspera;
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector3.Distance(transform.position, 
            PlayerMng.Instance.transform.position);

        if (distancia < distanciaDeAtaque)
        {            
            //Olhar para o player
            OlharParaPlayer();

            //Fazer o inimigo atacar
            AtirarProjetil();
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
    }

    private void AtirarProjetil()
    {
        //verificar se está no tempo de atirar
        if (Time.time > tempoAtaque)
        {
            //atualizo o tempo de ataque
            tempoAtaque = Time.time + tempoEspera;

            //Instancio o projetil
            GameObject novoProjetil = Instantiate(projetil);

            //Coloco o projetil na mesma posição e rotação do inimigo
            novoProjetil.transform.position = transform.position;
            novoProjetil.transform.rotation = transform.rotation;

            //Incremento uma distancia em z para o projetil instanciar na frente do inimigo
            novoProjetil.transform.Translate(new Vector3(0, 0, 1.24f));
        }
    }
}
