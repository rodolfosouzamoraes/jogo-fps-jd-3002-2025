using UnityEngine;

public class MoverParaDireita : MonoBehaviour
{
    public float velocidade;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * velocidade * Time.deltaTime;
    }
}
