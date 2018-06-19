using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public float tilt;

    //Shots
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Update () {
        if (Input.GetKey("space") && Time.time > nextFire) {
        nextFire = Time.time + fireRate;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

	void FixedUpdate () {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        GetComponent<Rigidbody>().velocity = movement * speed;

        //Clamp the position of the space ship to be within the boundary of the game world
        GetComponent<Rigidbody>().position = new Vector3 (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax));

        GetComponent<Rigidbody>().rotation = Quaternion.Euler (
            0.0f,
            0.0f,
            GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
