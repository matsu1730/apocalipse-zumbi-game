using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour
{

    public float velocidade = 20;
    Vector3 direcao;
    Vector3 movimentacao;
    public LayerMask mascaraDoChao;

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
            GetComponent<Animator>().SetBool("movendo", true);
        }
        else {
            GetComponent<Animator>().SetBool("movendo", false);
        }
    }

    void FixedUpdate() {
        movimentacao = direcao * velocidade * Time.deltaTime;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movimentacao);

        //rotação do jogador

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //debuggando o raio
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, mascaraDoChao)) {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }

    }

}
