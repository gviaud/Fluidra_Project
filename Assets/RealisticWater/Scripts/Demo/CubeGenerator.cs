using UnityEngine;
using System.Collections;

public class CubeGenerator : MonoBehaviour
{
	public Camera cam;
    public GameObject cubes;

    // Use this for initialization
    void Start () {
     
    }

    bool On_GUI()
    {
        Vector3 mousePos = Input.mousePosition;
        print(mousePos);

        bool pass = true;

        if (mousePos.y >= 718 || mousePos.y <= 40)
            return pass;
        if (mousePos.y >= 398 && mousePos.x >= 836)
            return pass;

        return false;

    }

	void Update()
    {

        if (Input.GetButtonDown ("Fire1") && !On_GUI()) 
		{
			var mousePos = Input.mousePosition;
			mousePos.z = 11;       // we want 2m away from the camera position
			var objectPos = Camera.main.ScreenToWorldPoint(mousePos);
			//Debug.Log(objectPos);
			var go = Instantiate(cubes, objectPos, Quaternion.identity)  as GameObject;
			go.AddComponent<Buoyancy>().Density = Random.Range(700, 850);
			go.AddComponent<Rigidbody>().mass = Random.Range(100, 150);
			Destroy(go, 30);
		}

	}
	// Update is called once per frame
	void UpdateCube ()
	{
	    var pos = transform.position;
	    pos.y += 10;
	    pos.z -= 4;
	    pos += Random.insideUnitSphere *0.01f;
        var go = Instantiate(cubes, pos, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360))) as GameObject;
		go.AddComponent<Buoyancy>().Density = Random.Range(700, 850);
		go.AddComponent<Rigidbody>().mass = Random.Range(100, 150);
		Destroy(go, 30);
	}
}
