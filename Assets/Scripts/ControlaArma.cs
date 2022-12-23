using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject bala;
    public GameObject canoDaArma;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bala, canoDaArma.transform.position, canoDaArma.transform.rotation);
        }
    }
}
