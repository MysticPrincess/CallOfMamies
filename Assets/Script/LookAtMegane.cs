using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMegane : MonoBehaviour
{

    public Transform target;
    public GameObject Megane;

    // Update is called once per frame
    private void Start()
    {
        Megane = GameObject.Find("Megane"); 
    }
    void Update()
    {
        transform.LookAt(Megane.transform); 
    }
}
