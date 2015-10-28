using UnityEngine;
using System.Collections;

public class Vidange : MonoBehaviour {

    private Vector3 init_Position;
    private Vector3 last_Position;

    bool empty = false;

    // Use this for initialization
    void Start () {
        init_Position = transform.localPosition;
        last_Position = new Vector3(0, -10.0f, 0);

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator WaitAndMove(float delayTime, Vector3 _pos)
    {
       
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        float timer = 0;
        while (Time.time - startTime <= 3)
        { // until one second passed
            transform.localPosition = Vector3.Lerp(transform.localPosition, _pos, timer); // lerp from A to B in one second
			timer += Time.deltaTime*0.1f;
            yield return new WaitForEndOfFrame(); // wait for next frame
        }
        yield return 1;
    }
    
    public void Emptying()
    {
        if(!empty)
        {
            StartCoroutine( WaitAndMove(0.2f, last_Position) );
            empty = true;
        }
        else
        {
            StartCoroutine(WaitAndMove(0.2f, init_Position));
            empty = false;
        }
    }

}
