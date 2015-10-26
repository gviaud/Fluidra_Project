using UnityEngine;
using System.Collections;

public class fixePosLight : MonoBehaviour {
	Vector3 pos;
	private bool b;
	void Start () {
		b = false;
	}
	void update()
	{
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){

        if ((other.name == "plage")&&(b==false))
        {
            Debug.Log("D5al");
            pos = transform.position + new Vector3(0, 0.1f, 0);
			transform.position=pos;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
        }
        if (other.name == "Water")
        {
            Debug.Log("D5al");
			pos = transform.position;
			transform.position=pos;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			b=true;
		}
	}

}
