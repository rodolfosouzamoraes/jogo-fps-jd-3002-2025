using UnityEngine;

public class ColidirProjetil : MonoBehaviour
{
    public float valorDano;
    private void OnCollisionEnter(Collision collision)
    {
        //Verificar se colidiu com o player
        if (collision.gameObject.tag.Equals("Player")) {
            //Dar dano no player
            CanvasGameMng.PnlStatusPlayer.ConsumirVida(valorDano);
        }
        
        Destroy(gameObject);
    }
}
