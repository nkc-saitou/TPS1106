using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaController : MonoBehaviour {

    float speed;
    GameObject Parent;

	// Use this for initialization
	void Start ()
    {
        Parent = GameObject.FindGameObjectWithTag("Bulletparent");
        transform.parent = Parent.transform;
        speed = 5.0f;
        Destroy(gameObject, 10.0f);

	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
	}
}
