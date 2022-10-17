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


    public GameObject[] lespositions;
    public GameObject[] lesanimaux; 
    public GameObject animal; 

    // Start is called before the first frame update
    void Start()
    {
        //tableau aléatoire des indices des positions
        int NbIndice = 4; 
        int[] indice = new int[NbIndice];
        HashSet<int> hashset = new HashSet<int>();
        System.Random r = new System.Random();

        while (hashset.Count < indice.Length)
        {
            hashset.Add(r.Next(0, lespositions.Length-1));
        }
        hashset.CopyTo(indice);

        //tableau aléatoire des animaux
        /*
        int[] animaux = new int[NbIndice];
        for(int j=0; j<NbIndice; j++)
        {
            animaux[j] = Random.Range(0, lesanimaux.Length - 1); 
        }
        */


        for (int i=0; i<NbIndice; i++)
        {
            Instantiate(animal, lespositions[indice[i]].transform.position, Quaternion.identity);
            Debug.Log(indice[i]);
        }


        //pour des animaux différent
        /*
        for (int i = 0; i < NbIndice; i++)
        {
            Instantiate(lesanimaux[i], lespositions[indice[i]].transform.position, Quaternion.identity);
            Debug.Log(indice[i]);
        }
        */

    }

}


