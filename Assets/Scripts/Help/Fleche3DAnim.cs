using UnityEngine;
using System.Collections;

public class Fleche3DAnim : MonoBehaviour {

    public Transform go;
    Vector3 pos;
    bool anim;

    float yMax = 0.1f;
    float yMin = -0.1f;

    // Use this for initialization
    void Start ()
    {
        pos = transform.position;
        
    }
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 myPos = transform.position;

        if(go.gameObject.activeInHierarchy)
        {
            myPos.z = go.position.z;
            myPos.x = go.position.x;
			myPos.z -= 0.2f;
			if(transform.parent.name == "Background AideMultiFace2" && name != "Fleche3D2")
			{
				myPos.z -= 1.8f;
			}
			if(transform.parent.name == "Background AideMultiFace2" && name == "Fleche3D2")
			{
				myPos.z += 0.2f;
			}

        }

        if (anim)
        {
            transform.position = new Vector3(myPos.x, myPos.y + Time.deltaTime * 0.25f, myPos.z);
        }
        else
        {
            transform.position = new Vector3(myPos.x, myPos.y - Time.deltaTime * 0.25f, myPos.z);
        }

        myPos = transform.position;
        if (myPos.y >= pos.y + yMax)
            anim = false;
        else if (myPos.y <= pos.y + yMin)
            anim = true;
       
    }
}
