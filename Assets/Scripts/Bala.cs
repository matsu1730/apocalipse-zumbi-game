using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidade = 30;
    void FixedUpdate()
    {
        //fazendo a bala ir para frente
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * velocidade * Time.deltaTime);
    }
}
