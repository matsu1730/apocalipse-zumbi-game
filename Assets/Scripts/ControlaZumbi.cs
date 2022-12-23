using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public float Hp = 10;
    public float Velocidade = 5;
    public GameObject Jogador;
    private Rigidbody rigidBodyZumbi;
    private Animator animatorZumbi;
    
    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        rigidBodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // direção do jogador perante a posição do zumbi
        Vector3 direcao = Jogador.transform.position - transform.position;
        Vector3 movimentacao = direcao.normalized * Velocidade * Time.deltaTime;

        //cálculo de distancia do zumbi ao jogador
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        //calculo de rotação, para o zumbi olhar para o jogador
        Quaternion rotacao = Quaternion.LookRotation(direcao);
        rigidBodyZumbi.MoveRotation(rotacao);

        //checagem de distancia para movimentação ou ataque
        if (distancia > 2.5) {
            rigidBodyZumbi.MovePosition(rigidBodyZumbi.position + movimentacao);

            animatorZumbi.SetBool("atacando", false);
        }
        else if (distancia <= 2.5) {
            animatorZumbi.SetBool("atacando", true);
        }
    }

    void OnTriggerEnter(Collider objetoDeColisao) 
    {
        if (objetoDeColisao.gameObject.tag == "Bala") {
            this.Hp -= 5;
        }
        if (this.Hp <= 0) {
            Object.Destroy(this.gameObject);
        }
    }

    void AtacaJogador() 
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Vivo = false;
    }
}
