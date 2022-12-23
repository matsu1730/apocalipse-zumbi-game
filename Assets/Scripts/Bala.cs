using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade = 30;
    private Rigidbody rigidBodyBala;

    void Start()
    {
        rigidBodyBala = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        //fazendo a bala ir para frente
        rigidBodyBala.MovePosition(rigidBodyBala.position + transform.forward * Velocidade * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        /*if(objetoDeColisao.gameObject.tag == "Zumbi") {
            Destroy(objetoDeColisao.gameObject);
            //Object.Destroy(objetoDeColisao.gameObject);
        }*/

        Destroy(this.gameObject);
    }
}
