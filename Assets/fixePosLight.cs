using UnityEngine;
using System.Collections;

public class fixePosLight : MonoBehaviour {
	Vector3 pos;
	private bool b;
	private bool entrer_c1;

	bool waitActive = false; //so wait function wouldn't be called many times per frame

	void Start () {
		b = false;
		entrer_c1 = true;
		
	}
	void update()
	{
		
	}
	IEnumerator WaitAndMove(float delayTime, Vector3 _pos)
	{ 
		entrer_c1 = !entrer_c1;
		yield return new WaitForSeconds(delayTime); // start at time X
		float startTime = Time.time; // Time.time contains current frame time, so remember starting point
		float timer = 0;
		while (Time.time - startTime <= 0.25)
		{ // until one second passed
			transform.localPosition = Vector3.Lerp(transform.localPosition, _pos, timer); // lerp from A to B in one second
			timer += Time.deltaTime*5;
			yield return new WaitForEndOfFrame(); // wait for next frame
		}
		
		float startTime2 = Time.time; // Time.time contains current frame time, so remember starting point
		float timer2 = 0;
		while (Time.time - startTime2 <= 0.4)
		{ // until one second passed
			transform.localPosition = Vector3.Lerp( _pos+new Vector3(0,-0.6f,0),transform.localPosition, timer2); // lerp from A to B in one second
			timer2 += Time.deltaTime*2f;
			yield return new WaitForEndOfFrame(); // wait for next frame
		}
		
		
		Debug.Log ("te9leb");
		yield return 1;
	}
	void OnCollisionEnter(Collision collision) {
        /*
		if ((collision.collider.name == "plage")&&(b==false))
		{
			Debug.Log("traverser plage");
			pos = transform.position + new Vector3(0, 0.23f, 0);
			transform.position=pos;*/
			/*if(entrer_c1){

                ///int random = Random.Range(-20, 20);
               // float x = (float)random / 500.0f;
               // random = Random.Range(-20, 20);
                //float z = (float)random / 500.0f;
                StartCoroutine(WaitAndMove(0,pos+new Vector3(0, 0.5f, 0)));
			}*//*
			GetComponent<Rigidbody>().constraints =  RigidbodyConstraints.FreezePositionY;
			
		}*/
	}
	IEnumerator flotter()
	{ 
		waitActive = true;
		yield return new WaitForSeconds(1f);
		float startTime = Time.time; // Time.time contains current frame time, so remember starting point
		float timer = 0;
		while (Time.time - startTime <=1)
		{ // until one second passed
			transform.localPosition = Vector3.Lerp(transform.localPosition, pos+new Vector3(0,1.2f,0), timer); // lerp from A to B in one second
			timer += Time.deltaTime*0.1f;
			yield return new WaitForEndOfFrame(); // wait for next frame
		}
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
		yield return new WaitForSeconds(2f);
		waitActive = false;
		yield return 1;
	}
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		

		if (other.name == "Water")
		{
			Debug.Log("traverser eau");
			pos = transform.position ;
			transform.position=pos;
			
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			/*if(!waitActive){
			StartCoroutine(flotter());
			}
			b=true;
			*/
		}
	}
	
}