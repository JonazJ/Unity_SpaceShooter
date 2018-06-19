using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroy : MonoBehaviour {

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    private GameController controller;

    void Start()
    {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController> ();
        if (controller == null)
        {
            Debug.LogError("Unable to find the GameController script");
        }
    }


    void OnTriggerEnter (Collider other) {
        //Check if we collide with boundary
        if (other.tag == "boundary")
        {
            //If so do nothing
            return;
        }

        if (other.tag != "Player")
        {
            controller.AddScore (10);
        }
        //Destroy the collision object = bolt
        Destroy (other.gameObject);

        //Destroy the Bolt
        Destroy (gameObject);
        //Initiate explosion animation
        GameObject tmp = Instantiate(asteroidExplosion, transform.position, transform.rotation) as GameObject;
        Destroy(tmp, 1);

        

        if (other.tag == "Player")
        {
           tmp = Instantiate (playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(tmp, 1);
        }
	}
}
