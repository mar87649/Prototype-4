using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public bool hasPowerUp;
    private float powerupStrength = 15f;
    public GameObject powerUpIndicator;

    
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();           //instantiate rigid body
        focalPoint = GameObject.Find("FocalPoint");     
    }

    // Update is called once per frame
    void Update()
    {        
        float forwardInput = Input.GetAxis("Vertical");         
        //add force to object attachet to rigif body
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);  
        powerUpIndicator.gameObject.transform.position = transform.position;       
              
    }

//on collison with tagged object "power up", destroy object
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PowerUp")){
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);  
            StartCoroutine(PowerupCountdownRoutine());          
        }
    }
    IEnumerator PowerupCountdownRoutine(){
        yield return new WaitForSeconds(7);
        Debug.Log("buff removed");
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision){
        Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp){
            enemyRB.AddForce(awayFromPlayer*powerupStrength, ForceMode.Impulse);
        }
    }
}
