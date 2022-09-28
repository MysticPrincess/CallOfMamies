using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ThrowingObject : MonoBehaviour
{
    [Header("References")]
    public Camera cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    Vector3 targetPosition;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Input.mousePosition;
            Debug.Log(targetPosition); 
            Throw();
        }
        /*if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Invoke("", 0.35f);
            //Throw();
        }*/
    }


    private void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 200f))
        {
            Debug.Log("object detected");
            Throw();
        }
    }

    private void Throw()
    {


        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.transform.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = objectToThrow.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(attackPoint.transform.position, targetPosition, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;



    }

}
