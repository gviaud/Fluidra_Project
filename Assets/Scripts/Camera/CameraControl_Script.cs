/*
Viaud Guillaume 20/10/2015

Control de la cam principale

*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CameraControl_Script : MonoBehaviour 
{

	float _angle;
	float _rayon;
	public float _speedRotationCam = 0.5f;
	public float _speedMoveCam = 10.0f;
	Vector3 lastMousePos;
	public Slider slideMoveCam;

    bool _start;
    bool _changeRotate;
    bool _animFleche;
    public GameObject backgroundFleche;
	bool fade;
    // Use this for initialization
    void Start () 
	{

		InitCam ();
		lastMousePos = Input.mousePosition;
        _start = true;
        _changeRotate = true;

    }

	void InitCam()
	{

		_angle = 3*Mathf.PI/2;
		_rayon = (new Vector3 (0, 0, 0) - transform.position).magnitude;

		Vector3 centre = new Vector3(0,0,0);
		float newX = centre.x + _rayon * Mathf.Cos(_angle);
		float newZ = centre.z + _rayon * Mathf.Sin(_angle);
		
		transform.position = new Vector3(newX, transform.position.y, newZ);
		transform.forward = new Vector3(0,3.886f,0) - transform.position;

        Slide();

    }

    void StartRotate()
    {


        ///////////DROITEGAUCHE
        Vector2 posFleche = backgroundFleche.transform.FindChild("Fleche").GetComponent<RectTransform>().anchoredPosition;
        if( _changeRotate )
        {
            backgroundFleche.transform.FindChild("Fleche").GetComponent<RectTransform>().anchoredPosition = new Vector2(posFleche.x + Time.deltaTime * 5.2f, posFleche.y);
            slideMoveCam.value += Time.deltaTime * 3.0f;
        }   
        else
        {
            backgroundFleche.transform.FindChild("Fleche").GetComponent<RectTransform>().anchoredPosition = new Vector2(posFleche.x - Time.deltaTime * 5.2f, posFleche.y);
            slideMoveCam.value -= Time.deltaTime * 3.0f;
        }

        if (slideMoveCam.value <= 240)
            _changeRotate = true;
        else if (slideMoveCam.value >= 260)
            _changeRotate = false;


        ////////////HAUTBAS
        posFleche = backgroundFleche.transform.FindChild("Fleche").GetComponent<RectTransform>().anchoredPosition;
        if (_animFleche)
            backgroundFleche.transform.FindChild("Fleche").GetComponent<RectTransform>().anchoredPosition = new Vector2(posFleche.x , posFleche.y - Time.deltaTime * 17f);
        else
            backgroundFleche.transform.FindChild("Fleche").GetComponent<RectTransform>().anchoredPosition = new Vector2(posFleche.x, posFleche.y + Time.deltaTime * 17f);

        posFleche = backgroundFleche.transform.FindChild("Fleche").GetComponent<RectTransform>().anchoredPosition;
        if (posFleche.y <= -312.75f)
            _animFleche = false;
        else if (posFleche.y >= -300.75f)
            _animFleche = true;
   
 //////SLIDE      
        Slide();

        if (Input.GetMouseButtonDown(0))
        {
			fade = true;
			_start = false;

        }

       

    }

    // Update is called once per frame
    void Update () 
	{
		Control ();
        if (_start)
            StartRotate();

		if (fade) 
		{
			backgroundFleche.transform.GetChild(0).transform.GetComponent<Image>().color = new Color(1, 1, 1, backgroundFleche.transform.GetChild(0).transform.GetComponent<Image>().color.a - Time.deltaTime / 1.0f);
			backgroundFleche.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, backgroundFleche.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color.a - Time.deltaTime / 1.0f);
		}
    }
	
	bool Forward()
	{
//		if( Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow))
//			return true;
//		else if( Input.GetAxis("Mouse ScrollWheel") > 0 )
//		{
//			_speedMoveCam *= 10.0f;
//			return true;
//		}
		return false;
	}
	bool Backward()
	{
//		if( Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
//			return true;
//		else if( Input.GetAxis("Mouse ScrollWheel") < 0 )
//		{
//			_speedMoveCam *= 10.0f;
//			return true;
//		}
		return false;
	}
	bool Left()
	{
//		if (Input.GetKey (KeyCode.Q) || Input.GetKey (KeyCode.LeftArrow))
//			return true;
//		else if ((!Input.GetKey (KeyCode.Mouse0) && Input.GetKey (KeyCode.Mouse1)) && lastMousePos.x < Input.mousePosition.x) 
//		{
//			_speedRotationCam *= 2.5f;
//			return true;
//		}

		return false;
	}
	bool Right()
	{
//		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
//			return true;
//		else if ((!Input.GetKey (KeyCode.Mouse0) && Input.GetKey (KeyCode.Mouse1)) && lastMousePos.x > Input.mousePosition.x) 
//		{
//			_speedRotationCam *= 2.5f;
//			return true;
//		}
//		
		return false;
	}
	public void Slide(){
		Vector3 centre = new Vector3(0,0,0);
		float newX = centre.x + _rayon * Mathf.Cos(Mathf.Deg2Rad*slideMoveCam.value);
		float newZ = centre.z + _rayon * Mathf.Sin(Mathf.Deg2Rad*slideMoveCam.value);
		
		transform.position = new Vector3(newX, transform.position.y, newZ);

        Vector3 newVect = new Vector3(0, 0, 0) - transform.position;
        
        newVect.Normalize();
        
        transform.forward = newVect;
        transform.eulerAngles = new Vector3(13.52731f, transform.eulerAngles.y, transform.eulerAngles.z);

    }
    void Control()
	{

		float speedMoveCam = _speedMoveCam;
		float speedRotationCam = _speedRotationCam;

		if( Left() )
		{
			
			Vector3 centre = new Vector3(0,0,0);
			_angle -= Time.deltaTime * _speedRotationCam;
			
			float newX = centre.x + _rayon * Mathf.Cos(_angle);
			float newZ = centre.z + _rayon * Mathf.Sin(_angle);
			
			transform.position = new Vector3(newX, transform.position.y, newZ);
			
			transform.forward = new Vector3(0,3.886f,0) - transform.position;
			slideMoveCam.value = transform.eulerAngles.y;

		}
		else if( Right() )
		{
			
			Vector3 centre = new Vector3(0,0,0);
			_angle += Time.deltaTime * _speedRotationCam;
			
			float newX = centre.x + _rayon * Mathf.Cos(_angle);
			float newZ = centre.z + _rayon * Mathf.Sin(_angle);
			
			transform.position = new Vector3(newX, transform.position.y, newZ);
			
			transform.forward = new Vector3(0,3.886f,0) - transform.position;
			slideMoveCam.value = transform.eulerAngles.y;
		}
		
		if ( Forward() ) 
		{
			if( _rayon >= 11.0f)
			{
				Camera.main.transform.Translate (new Vector3 (0, 0, Time.deltaTime * _speedMoveCam));
				_rayon -= Time.deltaTime * _speedMoveCam;
			}
		}
		if ( Backward() ) 
		{
				
			if( _rayon <= 25.0f)
			{
				Camera.main.transform.Translate (new Vector3 (0, 0, -Time.deltaTime * _speedMoveCam));
				_rayon += Time.deltaTime * _speedMoveCam;
			}
		}
		//print (rayon);

		_speedMoveCam = speedMoveCam;
		_speedRotationCam = speedRotationCam;
		lastMousePos = Input.mousePosition;
	}

}
