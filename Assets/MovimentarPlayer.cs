using UnityEngine;

public class MovimentarPlayer : MonoBehaviour
{
    [Header("Config Movimento")]
    public float velocidadeCaminhada; //Velocidade de caminhada do player
    public float velocidadeCorrida; //Velocidade de corrida do player
    public float forcaPulo; //Definir a força de subida do player
    public float forcaQueda; //Definir a força de queda do player
    public float valorConsumoStamina;//Definir o valor da stamina que será consumida
    private Vector3 direcaoMovimentacao; //Direção para onde o player deve ir
    private CharacterController playerControlador; //Variavel de controle do player

    [Header("Config Camera")]
    public float velocidadeCamera; //Velocidade de rotação da camera
    public float limiteCameraAnguloX; //Definir o limite do angulo X que o jogador possa olhar
    private Camera playerCamera; //Variavel com a referencia da camera do jogador
    private float cameraAnguloX; //Armazenar o valor do angulo X da camera


    private float velocidadeFrontal;
    private float velocidadeLateral;    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Configurar a character controller
        playerControlador = GetComponent<CharacterController>();

        //Definir direção inicial de zero
        direcaoMovimentacao = Vector3.zero;

        //Obter a referencia da camera principal da cena
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarXYZ();

        RotacionarY();

        RotacionarCameraX();
    }

    private void MovimentarXYZ()
    {
        //Obter a referencia frontal do player
        Vector3 frente = transform.TransformDirection(Vector3.forward);

        //Obter a referencia da direita do player
        Vector3 direita = transform.TransformDirection(Vector3.right);

        //Obter o input que faz o jogador correr
        bool estaCorrendo = Input.GetKey(KeyCode.LeftShift);

        //Verificar se tem stamina para poder correr
        if (CanvasGameMng.PnlStatusPlayer.TemStamina() == true)
        {
            //Calcular a velocidade frontal
            velocidadeFrontal = estaCorrendo == true ? velocidadeCorrida : velocidadeCaminhada;
            
            //Calcular a velocidade lateral
            velocidadeLateral = estaCorrendo == true ? velocidadeCorrida : velocidadeCaminhada;

            //Consumir a stamina
            if (estaCorrendo == true) {
                CanvasGameMng.PnlStatusPlayer.ConsumirStamina(valorConsumoStamina);
            }
        }
        else
        {
            //Definir a velocidade de caminhada
            velocidadeFrontal = velocidadeCaminhada;
            velocidadeLateral = velocidadeCaminhada;
        }

        //Definir o movimento para frente ou para tras do player
        velocidadeFrontal *= Input.GetAxis("Vertical");

        //Definir o movimento para direita ou esquerda do player
        velocidadeLateral *= Input.GetAxis("Horizontal");

        //Defini a direção em Y atual
        float direcaoY = direcaoMovimentacao.y;

        //Calcular a direção do player
        direcaoMovimentacao = (frente * velocidadeFrontal) + (direita * velocidadeLateral);

        //Verificar se o jogador está no chão para poder pular
        if(Input.GetButton("Jump") && playerControlador.isGrounded == true)
        {
            //Definir a direção em Y para efetuar o pulo
            direcaoMovimentacao.y = forcaPulo;
        }
        else
        {
            //Definir a direção atual da movimentação
            direcaoMovimentacao.y = direcaoY;
        }

        //Verificar se o jogador não está no chão para poder fazer ele cair
        if(playerControlador.isGrounded == false)
        {
            //Apontar a direção em Y para baixo para fazer o jogador cair
            direcaoMovimentacao.y -= forcaQueda * Time.deltaTime;
        }

        //Movimentar o Player
        playerControlador.Move(direcaoMovimentacao * Time.deltaTime);
    }

    private void RotacionarY()
    {
        //Obter o input X do mouse
        float rotacaoY = Input.GetAxis("Mouse X") * velocidadeCamera;

        //Rotacionar o corpo do player
        transform.rotation *= Quaternion.Euler(0, rotacaoY, 0);
    }

    private void RotacionarCameraX()
    {
        //Obter o input Y do mouse
        cameraAnguloX += -Input.GetAxis("Mouse Y") * velocidadeCamera;

        //Limitar a rotação em X da camera
        cameraAnguloX = Mathf.Clamp(cameraAnguloX,-limiteCameraAnguloX, limiteCameraAnguloX);

        //Rotacionar a camera para a posição em X
        playerCamera.transform.localRotation = Quaternion.Euler(cameraAnguloX,0,0);
    }
}
