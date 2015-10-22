using UnityEngine;
using System.Collections;

public class Decal_Script : InteracibleObject_Script {

	public float _scale;
	public float _rotation;

	public bool _axisZ;

	public float _ratioX;
	public float _ratioY;

	Vector3 _startPpos;
	public float _speed = 2.0f;
	float _currentSpeed;

    public Vector3 myPosition;

    // Use this for initialization
    void Start () 
	{
		start();
		_scale = 1f;
        if(name.StartsWith("Decal"))
        {
            _scale = 3.0f;
        }
		_rotation = 180.0f;
        _saveColor = new Color(1, 1, 1, 1);
		_name = "Visuel";
		_ratioX = 1.0f;
		_ratioY = 1.0f;
		_startPpos = transform.position;
		_currentSpeed = _speed;

        myPosition = transform.position;
        
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

    public void ResetPosition()
    {

        if (name == "EnseigneRight" || name == "EnseigneLeft")
        {
            transform.position = new Vector3(transform.position.x, myPosition.y, myPosition.z);
        }
        else if (name == "EnseigneFront" || name == "EnseigneBack")
        {
            transform.position = new Vector3(myPosition.x, myPosition.y, transform.position.z);
        }

    }

	override public void UpdateAll()
	{
		MoveDecal ();
		_lastMousePos = Input.mousePosition;
	}

	public void Reinit(int _X = 0,int _Z = 0)
	{
		if (_ratioX <= 0.01f)
			_ratioX = 1;
		if (_ratioY <= 0.01f)
			_ratioY = 1;
        transform.localPosition = new Vector3(_X,0,_Z);
		transform.localScale = new Vector3 (_ratioX,_ratioY, 1);
    }

    public void Rotate(float rotation)
    {

        _rotation = rotation;
        if (name == "DecalRight" || name == "EnseigneRight")
        {
            transform.eulerAngles = new Vector3(0, 270, -_rotation + 180);
        }
        else if (name == "EnseigneBack" )
        {
            transform.eulerAngles = new Vector3(0, 180, _rotation);
        }
        else
        {
            if (_axisZ)
                transform.eulerAngles = new Vector3(0, 0, _rotation);
            else
                transform.eulerAngles = new Vector3(0, 270, _rotation);
        }
    }

    public void Scale(float scale)
    {

        if (_SceneManager_Script != null)
        {
            //print ("scale : "+scale);
            bool ok = true;
            transform.localScale = new Vector3(scale * _ratioX, scale * _ratioY, 1f);

            if (name.StartsWith("Enseigne"))
            {

                if (transform.position.y + transform.localScale.y / 2 > 10.0f)
                    ok = false;
                else if (transform.position.y - transform.localScale.y / 2 < 8.0f)
                    ok = false;

                float longueurEnseigne = _SceneManager_Script._enseigneLongueur;

                if (name == "EnseigneBack" || name == "EnseigneFront")
                {
                    if (transform.position.x - transform.lossyScale.x / 2 < -longueurEnseigne || transform.position.x + transform.lossyScale.x / 2 > longueurEnseigne)
                        ok = false;
                }
                else if (name == "EnseigneLeft" || name == "EnseigneRight")
                {
                    if (transform.position.z - transform.lossyScale.x / 2 < -longueurEnseigne || transform.position.z + transform.lossyScale.x / 2 > longueurEnseigne)
                        ok = false;
                }

            }
            else
            {

                float longueur = _SceneManager_Script._longueur;
                float largeur = _SceneManager_Script._largeur;

                if (transform.position.y + transform.localScale.y / 2 > 5.0f)
                    ok = false;
                else if (transform.position.y - transform.localScale.y / 2 < 0.0f)
                    ok = false;

                if (name == "DecalMain")
                {
                    if (name == "DecalMain" && transform.position.x + transform.lossyScale.x / 2 > longueur || name == "DecalMain" && transform.position.x - transform.lossyScale.x / 2 < -longueur)
                        ok = false;
                }
                else if (name == "DecalLeft" || name == "DecalRight")
                {
                    if (transform.position.z + transform.lossyScale.x / 2 > largeur || transform.position.z - transform.lossyScale.x / 2 < -largeur)
                        ok = false;
                }

            }

            if (ok)
                _scale = scale;
            else
                Scale(scale - 0.01f);
        }
    }
    override public void ChangeColor(Color newColor)
	{
		transform.GetComponent<Renderer> ().material.color = newColor;
	}

	override public void Changetexture(int num)
	{
		
		Texture tex = GetComponent<MeshRenderer> ().material.mainTexture;
		tex = Resources.Load ("TexturesDecal/"+num) as Texture;
		GetComponent<MeshRenderer> ().material.mainTexture = tex;
		
	}

	void Left_Right()
	{
		if (Input.GetKey (KeyCode.LeftArrow) && !_blockMove)
		{

			Vector3 MousePos = Input.mousePosition;
			Vector3 posObject =transform.position;
			
			float longueur = _SceneManager_Script._longueur;
			float largeur = _SceneManager_Script._largeur;
			float longueurEnseigne = _SceneManager_Script._enseigneLongueur;	
			float largeurEnseigne = _SceneManager_Script._enseigneLargeur;	

			//Ne doit pas sortir du mur
			if( name == "DecalMain" ||
			   name == "EnseigneBack" ||
			   name == "EnseigneFront"
			   )
			{

                if ( name == "EnseigneBack" )
					transform.position = new Vector3( transform.position.x + (_currentSpeed*Time.deltaTime),transform.position.y,transform.position.z );
				else
					transform.position = new Vector3( transform.position.x - (_currentSpeed*Time.deltaTime),transform.position.y,transform.position.z );

				if(name == "DecalMain"&& transform.position.x+transform.lossyScale.x/2 > longueur 
				   || name == "DecalMain"&& transform.position.x-transform.lossyScale.x/2 < -longueur
				   || name.StartsWith("Enseigne") &&  transform.position.x-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.x+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
				}
			}
			else if( name == "DecalLeft" ||
			        name == "EnseigneLeft" )
			{
				transform.position = new Vector3( transform.position.x,transform.position.y,transform.position.z - (_currentSpeed*Time.deltaTime) );
				if( name == "DecalLeft" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   || name == "DecalLeft" && transform.position.z  - transform.lossyScale.x/2< -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -largeurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > largeurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			else if( name == "DecalRight" ||
			        name == "EnseigneRight")
			{
				transform.position = new Vector3( transform.position.x,transform.position.y,transform.position.z + (_currentSpeed*Time.deltaTime) );
				if( name == "DecalRight" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   || name == "DecalRight" && transform.position.z - transform.lossyScale.x/2 < -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}

			float Verif = (transform.position - posObject).magnitude;
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;
			
			if( name.StartsWith("Enseigne") )
			{
				
				if( transform.position.y+transform.localScale.y/2 > 10.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 8.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				
			}
			else
			{
				if( transform.position.y+transform.localScale.y/2 > 5.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 0.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
			}

			if( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}
			
		}
		else if (Input.GetKey (KeyCode.RightArrow) && !_blockMove) 
		{
			
			Vector3 MousePos = Input.mousePosition;
			Vector3 posObject =transform.position;
			
			float longueur = _SceneManager_Script._longueur;
			float largeur = _SceneManager_Script._largeur;
			float longueurEnseigne = _SceneManager_Script._enseigneLongueur;	
			float largeurEnseigne = _SceneManager_Script._enseigneLargeur;	
			
			//Ne doit pas sortir du mur
			if( name == "DecalMain" ||
			   name == "EnseigneBack" ||
			   name == "EnseigneFront"
			   )
			{
				
				if( name == "EnseigneBack" )
					transform.position = new Vector3( transform.position.x - (_currentSpeed*Time.deltaTime),transform.position.y,transform.position.z );
				else
					transform.position = new Vector3( transform.position.x + (_currentSpeed*Time.deltaTime),transform.position.y,transform.position.z );


                if (name == "DecalMain"&& transform.position.x+transform.lossyScale.x/2  > longueur 
				   || name == "DecalMain"&& transform.position.x-transform.lossyScale.x/2 < -longueur
				   || name.StartsWith("Enseigne") &&  transform.position.x-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.x+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
				}
			}
			else if( name == "DecalLeft" ||
			        name == "EnseigneLeft" )
			{
				transform.position = new Vector3( transform.position.x,transform.position.y,transform.position.z + (_currentSpeed*Time.deltaTime) );
				if( name == "DecalLeft" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   ||  name == "DecalLeft" && transform.position.z  - transform.lossyScale.x/2< -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -largeurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > largeurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			else if( name == "DecalRight" ||
			        name == "EnseigneRight")
			{
				transform.position = new Vector3( transform.position.x,transform.position.y,transform.position.z - (_currentSpeed*Time.deltaTime) );
				if (name == "DecalRight" && transform.position.z + transform.lossyScale.x/2 > largeur
                   || name == "DecalRight" && transform.position.z - transform.lossyScale.x/2 < -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			
			float Verif = (transform.position - posObject).magnitude;
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;
			
			if( name.StartsWith("Enseigne") )
			{
				
				if( transform.position.y+transform.localScale.y/2 > 10.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 8.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				
			}
			else
			{
				if( transform.position.y+transform.localScale.y/2 > 5.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 0.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
			}
			if( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}
		}
	}

	void Up_Down()
	{
		if (Input.GetKey (KeyCode.UpArrow) && !_blockMove)
		{
			
			Vector3 MousePos = Input.mousePosition;
			Vector3 posObject = transform.position;
			
			float longueur = _SceneManager_Script._longueur;
			float largeur = _SceneManager_Script._largeur;
			float longueurEnseigne = _SceneManager_Script._enseigneLongueur;	
			float largeurEnseigne = _SceneManager_Script._enseigneLargeur;	
			
			//Ne doit pas sortir du mur
			if( name == "DecalMain" ||
			   name == "EnseigneBack" ||
			   name == "EnseigneFront"
			   )
			{
	
				transform.position = new Vector3( transform.position.x,transform.position.y + (_currentSpeed*Time.deltaTime),transform.position.z );

                if (name == "DecalMain"&& transform.position.x+transform.lossyScale.x/2  > longueur 
				   || name == "DecalMain"&& transform.position.x-transform.lossyScale.x/2  < -longueur
				   || name.StartsWith("Enseigne") &&  transform.position.x-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.x+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
				}
			}
			else if( name == "DecalLeft" ||
			        name == "EnseigneLeft" )
			{
				transform.position = new Vector3( transform.position.x,transform.position.y + (_currentSpeed*Time.deltaTime),transform.position.z );
				if( name == "DecalLeft" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   ||  name == "DecalLeft" && transform.position.z  - transform.lossyScale.x/2< -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -largeurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > largeurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			else if( name == "DecalRight" ||
			        name == "EnseigneRight")
			{
				transform.position = new Vector3( transform.position.x,transform.position.y + (_currentSpeed*Time.deltaTime),transform.position.z );
				if (name == "DecalRight" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   || name == "DecalRight" && transform.position.z - transform.lossyScale.x/2 < -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			
			float Verif = (transform.position - posObject).magnitude;
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;
			
			if( name.StartsWith("Enseigne") )
			{
				
				if( transform.position.y+transform.localScale.y/2 > 10.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 8.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				
			}
			else
			{

                if ( transform.position.y+transform.localScale.y/2 > 5.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 0.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
			}

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
            
            Vector3 MousePos = Input.mousePosition;
			Vector3 posObject =transform.position;
			
			float longueur = _SceneManager_Script._longueur;
			float largeur = _SceneManager_Script._largeur;
			float longueurEnseigne = _SceneManager_Script._enseigneLongueur;	
			float largeurEnseigne = _SceneManager_Script._enseigneLargeur;	
			
			//Ne doit pas sortir du mur
			if( name == "DecalMain" ||
			   name == "EnseigneBack" ||
			   name == "EnseigneFront"
			   )
			{
				
				transform.position = new Vector3( transform.position.x,transform.position.y - (_currentSpeed*Time.deltaTime),transform.position.z );
				
				if(name == "DecalMain"&& transform.position.x+transform.lossyScale.x/2 > longueur 
				   || name == "DecalMain"&& transform.position.x-transform.lossyScale.x/2 < -longueur
				   || name.StartsWith("Enseigne") &&  transform.position.x-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.x+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
				}
			}
			else if( name == "DecalLeft" ||
			        name == "EnseigneLeft" )
			{
				transform.position = new Vector3( transform.position.x,transform.position.y - (_currentSpeed*Time.deltaTime),transform.position.z );
				if( name == "DecalLeft" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   ||  name == "DecalLeft" && transform.position.z  - transform.lossyScale.x/2< -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -largeurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > largeurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			else if( name == "DecalRight" ||
			        name == "EnseigneRight")
			{
				transform.position = new Vector3( transform.position.x,transform.position.y - (_currentSpeed*Time.deltaTime),transform.position.z );
				if(name == "DecalRight" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   || name == "DecalRight" && transform.position.z - transform.lossyScale.x/2 < -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > longueurEnseigne
				   )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			
			float Verif = (transform.position - posObject).magnitude;
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;
			
			if( name.StartsWith("Enseigne") )
			{
				
				if( transform.position.y+transform.localScale.y/2 > 10.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 8.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				
			}
			else
			{

                if ( transform.position.y+transform.localScale.y/2 > 5.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 0.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);

			}

			if( transform.position == posObject)
			{
				_currentSpeed = _speed;
			}
			else
			{
				_currentSpeed += Time.deltaTime*15.0f;;
			}

		}
	}

	public void MoveDecal()
	{

		Left_Right ();
		Up_Down ();

        //Vector3 up = -transform.up;
        //Vector3 down = transform.up;
        //Vector3 right = -transform.right;
        //Vector3 left = transform.right;

        /*
		_timer -= Time.deltaTime;
		if( Input.GetMouseButton(0) && _timer <= 0 && !_blockMove)
		{
				
			Vector3 MousePos = Input.mousePosition;
			Vector3 posObject = transform.position;
				
			float longueur = _SceneManager_Script._longueur;
			float largeur = _SceneManager_Script._largeur;
			float longueurEnseigne = _SceneManager_Script._enseigneLongueur;	
			float largeurEnseigne = _SceneManager_Script._enseigneLargeur;	

			//Ne doit pas sortir du mur
			if( name == "DecalMain" ||
				name == "EnseigneBack" ||
				name == "EnseigneFront"
			)
			{

				if( name == "EnseigneBack" )
					transform.position = new Vector3(posObject.x + (_lastMousePos.x - MousePos.x)*Time.deltaTime, posObject.y - (_lastMousePos.y - MousePos.y)*Time.deltaTime, posObject.z );
				else
					transform.position = new Vector3(posObject.x - (_lastMousePos.x - MousePos.x)*Time.deltaTime, posObject.y - (_lastMousePos.y - MousePos.y)*Time.deltaTime, posObject.z );

				if(name == "DecalMain"&& transform.position.x+transform.lossyScale.x/2 > longueur 
				   || name == "DecalMain"&& transform.position.x-transform.lossyScale.x/2 < -longueur
				   || name.StartsWith("Enseigne") &&  transform.position.x-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.x+transform.lossyScale.x/2 > longueurEnseigne
				)
				{
					transform.position = new Vector3(posObject.x,transform.position.y,transform.position.z);
				}
			}
			else if( name == "DecalLeft" ||
				     name == "EnseigneLeft" )
			{
				transform.position = new Vector3(posObject.x, posObject.y - (_lastMousePos.y - MousePos.y)*Time.deltaTime, posObject.z - (_lastMousePos.x - MousePos.x)*Time.deltaTime );
				if( name == "DecalLeft" && transform.position.z + transform.lossyScale.x/2 > largeur 
				   ||  name == "DecalLeft" && transform.position.z  - transform.lossyScale.x/2< -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -largeurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > largeurEnseigne
				)
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
			else if( name == "DecalRight" ||
				     name == "EnseigneRight")
			{
				transform.position = new Vector3(posObject.x, posObject.y - (_lastMousePos.y - MousePos.y)*Time.deltaTime, posObject.z + (_lastMousePos.x - MousePos.x)*Time.deltaTime );
				if( transform.position.z + transform.lossyScale.x/2 > largeur 
				   || transform.position.z - transform.lossyScale.x/2 < -largeur
				   || name.StartsWith("Enseigne") &&  transform.position.z-transform.lossyScale.x/2 < -longueurEnseigne
				   || name.StartsWith("Enseigne") &&  transform.position.z+transform.lossyScale.x/2 > longueurEnseigne
				 )
				{
					transform.position = new Vector3(transform.position.x,transform.position.y,posObject.z);
				}
			}
				
			float Verif = (transform.position - posObject).magnitude;
			//Quand Clique sur autre ecran, on deplace pas l'objet(bug)
			if( Verif >=5)
				transform.position = posObject;

			if( name.StartsWith("Enseigne") )
			{

				if( transform.position.y+transform.localScale.y/2 > 10.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 8.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);

			}
			else
			{
				if( transform.position.y+transform.localScale.y/2 > 5.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
				else if( transform.position.y-transform.localScale.y/2 < 0.0f )
					transform.position = new Vector3(transform.position.x,posObject.y,transform.position.z);
			}

		}
		*/
    }

}
