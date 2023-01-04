using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private GameObject Player;
    public string PlayerName;
    // Update is called once per frame
    private void Start()
    {
        Player = GameObject.Find(PlayerName); 
    }
    void Update()
    {
        transform.LookAt(Player.transform); 
    }
}
