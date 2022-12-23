using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{

    public float Velocidade = 20;
    private Vector3 direcao;
    private Vector3 movimentacao;
    public LayerMask MascaraDoChao;
    public GameObject TextoGameOver;
    public bool Vivo = true;
    private Rigidbody rigidBodyJogador;
    private Animator animatorJogador;

    void Start() {
        Time.timeScale = 1;
        rigidBodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        // definindo eixos
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        // criando direção de acordo com os eixos definidos -> nesse caso apenas movimentação nos eixos X e Z
        direcao = new Vector3(eixoX, 0, eixoZ);
        

        // definindo transição de animações de Idle e Correr
        if (direcao != Vector3.zero) {
            animatorJogador.SetBool("movendo", true);
        }
        else {
            animatorJogador.SetBool("movendo", false);
        }

        if (Vivo == false) {
            if(Input.GetButtonDown("Fire1")) {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate() {
        movimentacao = direcao * Velocidade * Time.deltaTime;
        rigidBodyJogador.MovePosition(rigidBodyJogador.position + movimentacao);

        //rotação do jogador

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //debuggando o raio
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;
        Vector3 posicaoMiraJogador;

        

        if(Physics.Raycast(raio, out impacto, 100, MascaraDoChao)) {
            posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            rigidBodyJogador.MoveRotation(novaRotacao);
        }

    }

}
