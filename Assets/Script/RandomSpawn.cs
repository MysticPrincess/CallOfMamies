using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSpawn : MonoBehaviour
{
    public Animator animator;

    private float score = 0;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered");
        animator.SetTrigger("isEating");
        score = score + 0.25f;
        Debug.Log(score);
    }

    /* public GameObject[] lespositions;
     public GameObject prefab;


     // Start is called before the first frame update
     void Start()
     {
         //int [] RandomIndice = new int[5];
         List<int> indice = new List<int>();
         HashSet<int> hashset = new HashSet<int>();
         //int size = 0; 
         indice.Add(Random.Range(0, 10));
         int temp = 0;

         //Debug.Log("before la boucle");
         for (int i = 0; i < 5; i++)
         {
             int flag = 0;
             //Debug.Log("indice i=");
             //Debug.Log(i);           
             int ok = 0;

             while (ok != 1)
             {
                 temp = Random.Range(0, 10);
                 for (int j = 0; j < indice.Count; j++)
                 {
                        /* if (temp== indice[j])
                         {
                             flag = 1;
                             j = indice.Count;

                         }*/
    /*    }


            if (flag == 0)
            {
                ok = 1;
                indice.Add(temp);
            }
     }



        //  Debug.Log(temp);

    }



    //transform.position = lespositions[randomNb].transform.position;
    //Instantiate(prefab, lespositions[randomNb].transform.position, Quaternion.identity);


}
    */

}

