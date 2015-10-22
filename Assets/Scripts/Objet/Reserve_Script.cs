using UnityEngine;
using System.Collections;

public class Reserve_Script : InteracibleObject_Script {

	public GameObject cam;
	public CameraControl_Script camControl;
	public GameObject _lightManager;
    
    public GameObject _door;
	public float _speed = 2.0f;
	float _currentSpeed;

	void Awake () 
	{
		//Changetexture (1);
		_name = "Reserve";
	}
	
	// Use this for initialization
	void Start () 
	{
		_currentSpeed = _speed;
		start();
        menuSideNum = 3;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonUp (0)) 
			_blockMove = false;
		else if (Input.GetMouseButtonDown (0)) 
		{
			if( Camera.main && Camera.main.gameObject.activeInHierarchy)
			{
				Vector3 mousPos = Camera.main.ScreenToViewportPoint( Input.mousePosition);
				if( (mousPos.x >= 0 && mousPos.x <=0.2f) && (mousPos.y >= 0.1 && mousPos.y <= 0.9f) )
				{
					_blockMove = true;
				}
				else if( (mousPos.x >= 0.3 && mousPos.x <=0.7f) && (mousPos.y >= 0.03f && mousPos.y <= 0.05f) )
					_blockMove = true;
			}
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.UpArrow)) 
		{}
		else
			_currentSpeed = _speed;

	}
	public void activLight(bool b){
		lightIsActiv = b;
		lights.UpdateLight();
	}


	override public void UpdateAll()
	{
		MoveObject ();
		_lastMousePos = Input.mousePosition;
	}

	public void MoveObject ()
	{

		_timer -= Time.deltaTime;

		KeyCode left = KeyCode.LeftArrow;
		KeyCode right = KeyCode.RightArrow;
		KeyCode top = KeyCode.UpArrow;
		KeyCode bottom = KeyCode.DownArrow;


		if( cam.activeInHierarchy )
		{
		
			if( camControl.slideMoveCam.value <= 130 )
			{
				left = KeyCode.RightArrow;
				right = KeyCode.LeftArrow;
				top = KeyCode.DownArrow;
				bottom = KeyCode.UpArrow;
			}
			else if( camControl.slideMoveCam.value >= 410 )
			{
				left = KeyCode.RightArrow;
				right = KeyCode.LeftArrow;
				top = KeyCode.DownArrow;
				bottom = KeyCode.UpArrow;
			}
			else if( camControl.slideMoveCam.value <= 215)
			{
				left = KeyCode.DownArrow;
				right = KeyCode.UpArrow;
				top = KeyCode.LeftArrow;
				bottom = KeyCode.RightArrow;
			}
			else if( camControl.slideMoveCam.value >= 325 )
			{
				left = KeyCode.UpArrow;
				right = KeyCode.DownArrow;
				top = KeyCode.RightArrow;
				bottom = KeyCode.LeftArrow;
			}

		}
		if (Input.GetKey (left) && !_blockMove) {

			Vector3 posObject = transform.position;
			
			transform.position = new Vector3 (transform.position.x - (_currentSpeed * Time.deltaTime), transform.position.y, transform.position.z);

			float Verif = (transform.position - posObject).magnitude;	
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if (Verif >= 5)
				transform.position = posObject;
			
			// ---------------------- faux snap
			if (transform.position.z + (transform.localScale.z / 2.0f) > (_SceneManager_Script.Ground.transform.localScale.z / 2.0f) - 0.06f)
				transform.position = new Vector3 (transform.position.x, transform.position.y, posObject.z);
			else if (transform.position.z - (transform.localScale.z / 2.0f) < -(_SceneManager_Script.Ground.transform.localScale.z / 2.0f) + 0.06f)
				transform.position = new Vector3 (transform.position.x, transform.position.y, posObject.z);
			
			if (transform.position.x + (transform.localScale.x / 2.0f) > (_SceneManager_Script.Ground.transform.localScale.x / 2.0f) - 0.06f)
				transform.position = new Vector3 (posObject.x, transform.position.y, transform.position.z);
			else if (transform.position.x - (transform.localScale.x / 2.0f) < -(_SceneManager_Script.Ground.transform.localScale.x / 2.0f) + 0.06f)
				transform.position = new Vector3 (posObject.x, transform.position.y, transform.position.z);

            _lightManager.GetComponent<LightManager_Script>().ChangePosReserveLight(posObject, transform.position);

            if ( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;
			}

		} else if (Input.GetKey (right) && !_blockMove) {
			
			Vector3 posObject = transform.position;
			
			transform.position = new Vector3 (transform.position.x + (_currentSpeed * Time.deltaTime), transform.position.y, transform.position.z);
			
			float Verif = (transform.position - posObject).magnitude;	
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if (Verif >= 5)
				transform.position = posObject;
			
			// ---------------------- faux snap
			if (transform.position.z + (transform.localScale.z / 2.0f) > (_SceneManager_Script.Ground.transform.localScale.z / 2.0f) - 0.06f)
				transform.position = new Vector3 (transform.position.x, transform.position.y, posObject.z);
			else if (transform.position.z - (transform.localScale.z / 2.0f) < -(_SceneManager_Script.Ground.transform.localScale.z / 2.0f) + 0.06f)
				transform.position = new Vector3 (transform.position.x, transform.position.y, posObject.z);
			
			if (transform.position.x + (transform.localScale.x / 2.0f) > (_SceneManager_Script.Ground.transform.localScale.x / 2.0f) - 0.06f)
				transform.position = new Vector3 (posObject.x, transform.position.y, transform.position.z);
			else if (transform.position.x - (transform.localScale.x / 2.0f) < -(_SceneManager_Script.Ground.transform.localScale.x / 2.0f) + 0.06f)
				transform.position = new Vector3 (posObject.x, transform.position.y, transform.position.z);

            _lightManager.GetComponent<LightManager_Script>().ChangePosReserveLight(posObject, transform.position);

            if ( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}
		} 

		if (Input.GetKey (top) && !_blockMove)
		{
			
			Vector3 posObject = transform.position;
			
			transform.position = new Vector3( transform.position.x,transform.position.y,transform.position.z + (_currentSpeed*Time.deltaTime) );
			
			float Verif = (transform.position - posObject).magnitude;	
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;
			
			// ---------------------- faux snap
			if( transform.position.z + (transform.localScale.z/2.0f)  > (_SceneManager_Script.Ground.transform.localScale.z/2.0f)-0.06f)
				transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
			else if( transform.position.z - (transform.localScale.z/2.0f)  < -(_SceneManager_Script.Ground.transform.localScale.z/2.0f)+0.06f)
				transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
			
			if( transform.position.x + (transform.localScale.x/2.0f)  > (_SceneManager_Script.Ground.transform.localScale.x/2.0f)-0.06f)
				transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
			else if( transform.position.x - (transform.localScale.x/2.0f)  < -(_SceneManager_Script.Ground.transform.localScale.x/2.0f)+0.06f)
				transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);

            _lightManager.GetComponent<LightManager_Script>().ChangePosReserveLight(posObject, transform.position);

            if ( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}
		}
		else if (Input.GetKey (bottom) && !_blockMove)
		{
			
			Vector3 posObject = transform.position;
			
			transform.position = new Vector3( transform.position.x,transform.position.y,transform.position.z - (_currentSpeed*Time.deltaTime) );
			
			float Verif = (transform.position - posObject).magnitude;	
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;
			
			// ---------------------- faux snap
			if( transform.position.z + (transform.localScale.z/2.0f)  > (_SceneManager_Script.Ground.transform.localScale.z/2.0f)-0.06f)
				transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
			else if( transform.position.z - (transform.localScale.z/2.0f)  < -(_SceneManager_Script.Ground.transform.localScale.z/2.0f)+0.06f)
				transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
			
			if( transform.position.x + (transform.localScale.x/2.0f)  > (_SceneManager_Script.Ground.transform.localScale.x/2.0f)-0.06f)
				transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
			else if( transform.position.x - (transform.localScale.x/2.0f)  < -(_SceneManager_Script.Ground.transform.localScale.x/2.0f)+0.06f)
				transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);

            _lightManager.GetComponent<LightManager_Script>().ChangePosReserveLight(posObject, transform.position);

            if ( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}
		}
		/*
		if( Input.GetMouseButton(0) && _timer <= 0 && !_blockMove)
		{

			//_door.transform.parent = transform;

			Vector3 MousePos = Input.mousePosition;
			Vector3 posObject = transform.position;

			transform.position = new Vector3( (posObject.x - (_lastMousePos.x - MousePos.x)*Time.deltaTime), posObject.y, posObject.z - (_lastMousePos.y - MousePos.y)*Time.deltaTime*2.0f );

			//float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
			//Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * distance_to_screen);
			//transform.position = new Vector3(newPos.x,posObject.y,newPos.z);

			float Verif = (transform.position - posObject).magnitude;	
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;
			
			// ---------------------- faux snap
			if( transform.position.z + (transform.localScale.z/2.0f)  > (_SceneManager_Script.Ground.transform.localScale.z/2.0f)-0.06f)
				transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
			else if( transform.position.z - (transform.localScale.z/2.0f)  < -(_SceneManager_Script.Ground.transform.localScale.z/2.0f)+0.06f)
				transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
			
			if( transform.position.x + (transform.localScale.x/2.0f)  > (_SceneManager_Script.Ground.transform.localScale.x/2.0f)-0.06f)
				transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
			else if( transform.position.x - (transform.localScale.x/2.0f)  < -(_SceneManager_Script.Ground.transform.localScale.x/2.0f)+0.06f)
				transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);

		}
		*/
	}

	override public void Changetexture(int num)
	{
		if (num != -1) 
		{
			Texture tex = GetComponent<MeshRenderer> ().material.mainTexture;
		
			if (num < 10)
				tex = Resources.Load ("Textures/0" + num) as Texture;
			else
				tex = Resources.Load ("Textures/" + num) as Texture;

			GetComponent<MeshRenderer> ().material.mainTexture = tex;

			if (GetComponent<Texture_Script> ())
				GetComponent<Texture_Script> ().tex = num;
		}
	}

	void OnTriggerStay(Collider other)
	{
		//print (other.gameObject.tag);
		if( other.gameObject.tag == "Cylinder")
        {
            if (other.transform.parent.GetComponent<Light>().enabled)
            {
                if (other.name == "Cylinder_Wall_Front_Light_Model")
                    _lightManager.GetComponent<LightManager_Script>().nbrLightWallMain--;
                else if (other.name == "Cylinder_Wall_Left_Light_Model")
                    _lightManager.GetComponent<LightManager_Script>().nbrLightWallLeft--;
                else if (other.name == "Cylinder_wall_Right_Light_Model")
                    _lightManager.GetComponent<LightManager_Script>().nbrLightWallRight--;

                other.transform.parent.GetComponent<Light>().enabled = false;
                other.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            }
        }

	}

	void OnTriggerExit(Collider other)
	{


        //print (other.gameObject.tag);
        if (other.gameObject.tag == "Cylinder")
        {
            if (!other.transform.parent.GetComponent<Light>().enabled)
            {
                if (other.name == "Cylinder_Wall_Front_Light_Model")
                    _lightManager.GetComponent<LightManager_Script>().nbrLightWallMain++;
                else if (other.name == "Cylinder_Wall_Left_Light_Model")
                    _lightManager.GetComponent<LightManager_Script>().nbrLightWallLeft++;
                else if (other.name == "Cylinder_wall_Right_Light_Model")
                    _lightManager.GetComponent<LightManager_Script>().nbrLightWallRight++;

                other.transform.parent.GetComponent<Light>().enabled = true;
                other.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            }
        }

    }

}
