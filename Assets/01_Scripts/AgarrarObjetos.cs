using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    public GameObject Objeto;
    public Transform mano;

    public Transform FirePoint;
    public float Distance = 3f;

    private bool activo = true;
    private bool sujetando = false;

    void Update()
    {
        if (activo)
        {
            
            if (Input.GetKeyDown(KeyCode.E) && !sujetando )
            {
                if(Detect())
                {
                    RecogerCubo();
                }
            }
            else if (Input.GetKeyDown(KeyCode.G) && sujetando && Objeto != null)
            {
                SoltarCubo();
            }
        }
    }

    void RecogerCubo()
    {
        Objeto.transform.SetParent(mano);
        Objeto.transform.position = mano.position;
        Objeto.transform.rotation = mano.rotation;
        Objeto.GetComponent<Rigidbody>().isKinematic = true;
        Objeto.GetComponent<Collider>().enabled = false; 
        sujetando = true; 
    }

    void SoltarCubo()
    {
        Objeto.transform.SetParent(null);
        Objeto.GetComponent<Rigidbody>().isKinematic = false;
        Objeto.GetComponent<Collider>().enabled = true; 
        sujetando = false;
        Objeto = null;
    }

    bool Detect()
    {
        RaycastHit hit;

        if (Physics.Raycast(FirePoint.position, FirePoint.forward, out hit, Distance))
        {
            if (hit.collider.CompareTag("recogible"))
            {
                Objeto = hit.collider.gameObject; 
                return true;
            }
        }
        else
        {
            Objeto = null; 
        }
        return false;
    }


}
