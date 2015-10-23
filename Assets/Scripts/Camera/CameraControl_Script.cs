/*
Viaud Guillaume 20/10/2015

Control de la cam principale

*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraControl_Script : MonoBehaviour 
{

	float _rayon;
	public Slider slideMoveCam;

    Vector3 last_MousePos;

    // Use this for initialization
    void Start () 
	{

        InitCam();
    }

	void InitCam()
	{

		_rayon = (new Vector3 (0, transform.position.y, 0) - transform.position).magnitude;

    }


    // Update is called once per frame
    void Update()
    {

        Slide_Mouse();
        Zoom_Mouse();
    }

    void Zoom_Mouse()
    {

        _rayon -= Input.mouseScrollDelta.y;
        if (_rayon < 3)
            _rayon = 3;
        else if (_rayon > 30)
            _rayon = 30;

        Slide();

    }

    void Slide_Mouse()
    {

        if (Input.GetMouseButton(1))
        {

            if (Input.mousePosition != last_MousePos)
            {
                slideMoveCam.value += last_MousePos.x - Input.mousePosition.x;
                Slide();
            }

        }

        last_MousePos = Input.mousePosition;
    }

    public void Slide()
    {
		Vector3 centre = new Vector3(0, transform.position.y, 0);
		float newX = centre.x + _rayon * Mathf.Cos(Mathf.Deg2Rad*slideMoveCam.value);
		float newZ = centre.z + _rayon * Mathf.Sin(Mathf.Deg2Rad*slideMoveCam.value);
		
		transform.position = new Vector3(newX, transform.position.y, newZ);

        Vector3 newVect = new Vector3(0, 5, 0) - transform.position;
        
        newVect.Normalize();
        
        transform.forward = newVect;


    }
    

}
