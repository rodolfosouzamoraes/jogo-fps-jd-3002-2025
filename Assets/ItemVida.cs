using TMPro;
using UnityEngine;

public class ItemVida : ItemPocao
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Atribuir a mana ao canvas
            CanvasGameMng.PnlStatusPlayer.IncrementarVidaPlayer(porcentagemPocao);

            //Destruir o objeto
            Destroy(gameObject, Time.deltaTime);
        }
    }
}
