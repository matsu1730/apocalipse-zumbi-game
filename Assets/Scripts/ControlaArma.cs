using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject CanoDaArma;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
        }
    }
}
