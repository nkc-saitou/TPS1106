using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameObject tama;
    public GameObject muzzle;
    GameObject Tama;
    float jikan;

	// Use this for initialization
	void Start ()
    {
        jikan = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        jikan += Time.deltaTime;
        if (jikan >= 1.0f)
        {
            if (Input.GetMouseButton(0))
            {
                Tama = Instantiate(tama,new Vector3(muzzle.transform.position.x,muzzle.transform.position.y,muzzle.transform.position.z),Quaternion.identity);
                Tama.transform.forward = muzzle.transform.forward;
                jikan = 0.0f;
            }
        }
	}

    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "Goal")
        {
            SceneManager.LoadScene("title");
        }
    }
}
