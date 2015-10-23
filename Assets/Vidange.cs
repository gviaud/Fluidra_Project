using UnityEngine;
using System.Collections;

public class Vidange : MonoBehaviour {

    private Vector3 init_Position;
    private Vector3 last_Position;

    // Use this for initialization
    void Start () {
        init_Position = transform.localPosition;
        last_Position = new Vector3(0, -5.5f, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    IEnumerator WaitAndMove(float delayTime, Vector3 _pos)
    {
       
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point

        while (Time.time - startTime <= 1)
        { // until one second passed
            transform.localPosition = Vector3.Lerp(transform.localPosition, _pos, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
        yield return null;
    }
    
    public void EmptySPA()
    {
        
        StartCoroutine( WaitAndMove(0.2f, last_Position) );

    }
    public void FillSpa()
    {

        StartCoroutine(WaitAndMove(0.2f, init_Position) );

    }
}
