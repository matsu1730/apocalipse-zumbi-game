using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour
{
    public float hp = 10;
    public float velocidade = 5;
    public GameObject jogador;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // direção do jogador perante a posição do zumbi
        Vector3 direcao = jogador.transform.position - transform.position;
        Vector3 movimentacao = direcao.normalized * velocidade * Time.deltaTime;

        //cálculo de distancia do zumbi ao jogador
        float distancia = Vector3.Distance(transform.position, jogador.transform.position);

        //calculo de rotação, para o zumbi olhar para o jogador
        Quaternion rotacao = Quaternion.LookRotation(direcao);

        //checagem de distancia para movimentação ou ataque
        if (distancia > 2.5) {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + movimentacao);
            GetComponent<Rigidbody>().MoveRotation(rotacao);
        }
        //else if (distancia <= 2.5) {}
    }

    void OnTriggerEnter(Collider objetoDeColisao) 
    {
        if (objetoDeColisao.gameObject.tag == "Bala") {
            this.hp -= 5;
        }
        if (this.hp <= 0) {
            Object.Destroy(this.gameObject);
        }
    }
}
