using UnityEngine;
using System.Collections;

public class ChangePosCol : MonoBehaviour {

    Camera cam;
    Vector3 _myPos;
    float fov = 44;
    

	// Use this for initialization
	void Start ()
    {
        cam = transform.parent.GetComponent<Camera>();
        _myPos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {

        float newPosZ = (cam.fieldOfView - fov)/5.0f;
        
        if (newPosZ < 0.1f)
            newPosZ = 0;
        //print(newPosZ);

        transform.localPosition = new Vector3(_myPos.x, _myPos.y , _myPos.z - newPosZ);

    }
}
