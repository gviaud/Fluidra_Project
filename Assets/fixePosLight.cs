using UnityEngine;
using System.Collections;

public class fixePosLight : MonoBehaviour {
	Vector3 pos;

	void Start () {

	}
	void update()
	{
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){

if (other.name == "plage") {
			Debug.Log ("D5al");
			pos=transform.position;
			GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
		}
		if (other.name == "Water") {
			Debug.Log ("D5al");
			pos=transform.position;
			GetComponent<Rigidbody>().constraints=RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		}
	}

}
