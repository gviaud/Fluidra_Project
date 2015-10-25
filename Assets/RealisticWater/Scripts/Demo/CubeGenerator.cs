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
        //print(mousePos);

        bool pass = true;

        if (mousePos.y >= 718 || mousePos.y <= 40)
            return pass;
        if (mousePos.y >= 398 && mousePos.x >= 836)
            return pass;

        return false;

    }

    void Update()
    {

        if (!On_GUI())
        {
            RaycastHit Hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
            if (Physics.Raycast(ray, out Hit, 500))
            {
                Debug.Log(Hit.collider.name);
            }
            if (Input.GetButtonDown("Fire1") && Hit.collider && Hit.collider.name == "plage")
            {


                var go = Instantiate(cubes, Hit.point + new Vector3(0, 1f, 0), Quaternion.identity) as GameObject;
                go.AddComponent<Buoyancy>().Density = Random.Range(700, 850);
                go.AddComponent<Rigidbody>().mass = Random.Range(100, 150);
                Destroy(go, 5);
            }
            else if (Input.GetButtonDown("Fire1") && Hit.collider && Hit.collider.name == "Water")
            {

                Debug.Log(Hit.point);
				var go = Instantiate(cubes,Hit.point + new Vector3(0, 1f, 0), Quaternion.identity) as GameObject;
                go.AddComponent<Buoyancy>().Density = Random.Range(700, 850);
                go.AddComponent<Rigidbody>().mass = Random.Range(100, 150);
                Destroy(go, 5);
            }
        }
    }
    // Update is called once per frame
    void UpdateCube()
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
