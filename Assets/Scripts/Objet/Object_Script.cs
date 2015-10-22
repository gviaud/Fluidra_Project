using UnityEngine;
using System.Collections;

public class Object_Script : InteracibleObject_Script {

	public float _speed = 2.0f;
	float _currentSpeed;

	public float _scale;
	public float _rotation;

	public float _ratioX;
	public float _ratioY;

	void Awake()
	{
		_name = transform.name;
		_currentSpeed = _speed;

		_scale = 1.0f;
		_rotation = 180.0f;

		_ratioX = 1.0f;
		_ratioY = 1.0f;

		start();
	}

	// Use this for initialization
	public void Start () 
	{


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
	
	

	public void Rotate(float rotation)
	{ 
		_rotation = rotation;
		transform.eulerAngles = new Vector3(0,_rotation,0);
	}

	override public void UpdateAll()
	{
		MoveObject ();
		_lastMousePos = Input.mousePosition;
	}
	
	public void MoveObject ()
	{
		_timer -= Time.deltaTime;
		
		if (Input.GetKey (KeyCode.LeftArrow) && !_blockMove) {
			
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
			
			if( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;
			}
			
		} else if (Input.GetKey (KeyCode.RightArrow) && !_blockMove) {
			
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
			
			if( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}
		} 
		
		if (Input.GetKey (KeyCode.UpArrow) && !_blockMove)
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
			
			if( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}
		}
		else if (Input.GetKey (KeyCode.DownArrow) && !_blockMove)
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
			
			if( transform.position == posObject)
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
		
		Texture tex = GetComponent<MeshRenderer> ().material.mainTexture;
		
		if(num < 10)
			tex = Resources.Load ("Textures/0"+num) as Texture;
		else
			tex = Resources.Load ("Textures/"+num) as Texture;
		
		GetComponent<MeshRenderer> ().material.mainTexture = tex;
		
		if (transform.GetChild (0)) 
		{
			//transform.GetChild (0).GetComponent<MeshRenderer> ().material.mainTexture = tex;
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
        /*
		//print (other.gameObject.tag);
		if( other.gameObject.tag == "Cylinder")
		{
			other.transform.GetChild(0).gameObject.SetActive(false);
			other.GetComponent<MeshRenderer>().enabled = false;
		}
		*/
	}
	
	void OnTriggerExit(Collider other)
	{
        /*
		//print (other.gameObject.name);
		if( other.gameObject.tag == "Cylinder")
		{
			other.transform.GetChild(0).gameObject.SetActive(true);
			other.GetComponent<MeshRenderer>().enabled = true;
		}
		*/
	}
	
}
