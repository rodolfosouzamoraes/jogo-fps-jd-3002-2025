using UnityEngine;

public class ItemBau : MonoBehaviour
{
    public GameObject pnlInteracao;
    public Animator animator;
    public ParticleSystem particulaBau;
    private bool bauAberto = false;

    public void AbrirBau()
    {
        //Verificar se o bau ja foi aberto
        if(bauAberto == false)
        {
            //Definir que o bau será aberto
            bauAberto = true;

            //Ativo a animação de abertura
            animator.SetTrigger("abrir");

            //Destruir o painel de interação
            Destroy(pnlInteracao);
        }
    }

    public void ObterItemBau()
    {
        //Armazenar a informação da coleta do item do bau
        CanvasGameMng.PnlStatusPlayer.IncrementarBausAbertos();

        //Emitir a particula
        particulaBau.Play();
    }
}
