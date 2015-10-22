using UnityEngine;
using System.Collections;

public class Trigger_LightDoor_Script : MonoBehaviour {

	public GameObject _lightManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other)
	{
        
        if (other.gameObject.tag == "CylinderObj")
        {

            if (other.transform.parent.GetComponent<Light>().enabled)
            {
                _lightManager.GetComponent<LightManager_Script>().nbrLightWallReserve--;
            }

            other.transform.parent.GetComponent<Light>().enabled = false;
            other.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;

        }

    }
	
	void OnTriggerExit(Collider other)
	{

        //print (other.gameObject.name);
        if (other.gameObject.tag == "CylinderObj")
        {

            if (!other.transform.parent.GetComponent<Light>().enabled)
            {
                _lightManager.GetComponent<LightManager_Script>().nbrLightWallReserve++;
            }

            other.transform.parent.GetComponent<Light>().enabled = true;
            other.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;


        }

    }

}
