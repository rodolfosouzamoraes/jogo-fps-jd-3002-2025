using UnityEngine;

public class OlharParaPlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {        
        //Definir um alvo
        Vector3 alvo = new Vector3(
            PlayerMng.Instance.transform.position.x,
            transform.position.y,
            PlayerMng.Instance.transform.position.z
        );

        //Fazer o objeto olhar para um alvo
        transform.LookAt(alvo);
    }
}
