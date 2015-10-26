using UnityEngine;
using System.Collections;

public class Luminon_Script : MonoBehaviour {

    public bool ralentissement;

	// Use this for initialization
	void Start () {
        ralentissement = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(ralentissement)
        {
            // GetComponent<Buoyancy>().Density = GetComponent<Buoyancy>().Density - Time.deltaTime*1500.0f;
            //print(GetComponent<Buoyancy>().Density);
            //GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            //GetComponent<Buoyancy>().Density = 100000;
        }


    }
}
