using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed;
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player =  GameObject.Find("Player");        
    }

    // Update is called once per frame
    void Update()
    {
        //game object moves to target object
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection*speed); 
        
        if(transform.position.y<-20){
            Destroy(gameObject);
        }

    }
}
