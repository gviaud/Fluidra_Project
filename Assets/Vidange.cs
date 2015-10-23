using UnityEngine;
using System.Collections;

public class Vidange : MonoBehaviour {
    private Vector3 posA;
    private Vector3 posB;
    // Use this for initialization
    void Start () {
        posA = this.transform.localPosition;
        posB = posA - (new Vector3(0, 6, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            transform.position = Vector3.Lerp(posA,posB , Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
    }
    public void ViderPiscine()
    {
        WaitAndMove(1);
    }
}
