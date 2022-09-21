using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script : MonoBehaviour
{
    public Transform[] waypoints;
    private int index;

    NavMeshAgent Megan; 
    
    void Start()
    {
        Megan = GetComponent<NavMeshAgent>();
        index = 0;
    }

  
    private void Update()
    {
        Megan.destination = waypoints[index].position;

        if (Vector3.Distance(transform.position, waypoints[index].position) <= 3f && index != waypoints.Length - 2)
        {
            Debug.Log(index);
            index = (index + 1);
            
        }
        else if (index == waypoints.Length -1) {
            Debug.Log("fin");
        }

    }
        


   
}


