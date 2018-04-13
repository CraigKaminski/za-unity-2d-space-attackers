using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 1.5f;
    public float horizontalLimit = 2.5f;
    public float firingSpeed = 3f;
    public GameObject missilePrefab;

    private bool fired = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(
            Input.GetAxis("Horizontal") * speed,
            0
        );

        if (transform.position.x > horizontalLimit)
        {
            transform.position = new Vector3(horizontalLimit, transform.position.y, transform.position.z);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (transform.position.x < -horizontalLimit)
        {
            transform.position = new Vector3(-horizontalLimit, transform.position.y, transform.position.z);
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (Input.GetAxis("Fire1") == 1f)
        {
            if (fired == false)
            {
                fired = true;
                GameObject missileInstance = Instantiate(missilePrefab);
                missileInstance.transform.SetParent(transform);
                missileInstance.transform.position = transform.position;
                missileInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, firingSpeed);
                Destroy(missileInstance, 2f);
            }
        } else
        {
            fired = false;
        }
	}
}
