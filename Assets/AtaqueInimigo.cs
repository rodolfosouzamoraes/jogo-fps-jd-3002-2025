using UnityEngine;

public class AtaqueInimigo : MonoBehaviour
{
    public MovimentarInimigo movimentarInimigo;
    public float tempoAtaque;
    public float tempoProximoAtaque;
    public float valorDano;
    public float tempoAtual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tempoAtual = Time.time;
        tempoProximoAtaque = tempoAtual + tempoAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o inimigo está vendo o player
        if (movimentarInimigo.estaVendoPlayer == true) {
            //Verificar o tempo de ataque
            if (Time.time > tempoProximoAtaque) {
                //Atualizar o tempo para o proximo ataque
                tempoProximoAtaque = Time.time + tempoAtaque;
                //Efetuar o ataque do inimigo
                CanvasGameMng.PnlStatusPlayer.ConsumirVida(valorDano);
            }
        }
    }
}
