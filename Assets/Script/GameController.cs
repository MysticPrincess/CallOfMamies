using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 



public class GameController : MonoBehaviour
{
    public float score = 0;


    public GameObject[] lespositions;
    public GameObject[] lesanimaux;
    public int totalThrow;
    public TextMeshProUGUI ScoreValue;

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
            hashset.Add(r.Next(0, lespositions.Length - 1));
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


        for (int i = 0; i < NbIndice; i++)
        {
            GameObject pet =  Instantiate(lesanimaux[Random.Range(0,lesanimaux.Length)], lespositions[indice[i]].transform.position, Quaternion.identity);
            pet.GetComponent<PetsHit>().gameController = this;
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

    private void Update()
    {
        ScoreValue.text = score.ToString();
    }

}


