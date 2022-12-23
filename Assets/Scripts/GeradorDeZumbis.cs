using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeZumbis : MonoBehaviour
{
    public GameObject zumbi;
    float contadorTempo = 0;
    public float tempoGerarZumbi = 1;
    void Start()
    {
        
    }

    void Update()
    {

        contadorTempo += Time.deltaTime;

        if (contadorTempo >= tempoGerarZumbi) {
            Instantiate(zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }
        
    }
}
