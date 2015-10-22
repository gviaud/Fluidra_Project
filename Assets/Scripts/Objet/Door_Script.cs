using UnityEngine;
using System.Collections;

public class Door_Script : MonoBehaviour {

	GameObject _sceneManager;
	SceneManager_Script _sceneManager_Script;

	public GameObject _reserve;
	int etape = 1;

    Renderer _renderer;
    public Color _saveColor;

	// Use this for initialization
	void Start () 
	{
		_sceneManager = GameObject.Find ("SceneManager");
		_sceneManager_Script = _sceneManager.GetComponent<SceneManager_Script> ();
		etape = 1;

		transform.parent = _reserve.transform;

        _renderer = GetComponent<Renderer>();
        _saveColor = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
       
    }

	public void changeColor()
	{

        if (_saveColor == Color.white)
        {
            _renderer.material.color = new Color(30.0f / 255.0f, 30.0f / 255.0f, 30.0f / 255.0f, 1);
            _saveColor = new Color(30.0f / 255.0f, 30.0f / 255.0f, 30.0f / 255.0f, 1);
        }
        else if (_saveColor == new Color(30.0f/255.0f, 30.0f / 255.0f, 30.0f / 255.0f, 1) )
        {
            _renderer.material.color = Color.white;
            _saveColor = Color.white;
        }

    }

	public void ChangePosHandle()
	{

		transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+180.0f,transform.eulerAngles.z);
	}

    public void Replace()
    {



    }

    public void ReplaceDoor_Left()
	{
		
		transform.parent = _sceneManager.transform;
		
		int longueurReserve = _sceneManager_Script._reserveLongueur;
		int largeurReserve = _sceneManager_Script._reserveLargeur;
		
		//devant
		if( etape == 1)
		{
			
			Vector3 newPos = transform.position;
			newPos.x -= 1.0f;
            
            transform.position = newPos;
			
			if( transform.position.x - transform.localScale.x/2.0f < _reserve.transform.position.x - _reserve.transform.localScale.x/2.0f )
			{
				etape = 4;
				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+90.0f,transform.eulerAngles.z);

				newPos = _reserve.transform.position;
				newPos.y = 2.1f;
				
				newPos.x -= _reserve.transform.localScale.x / 2.0f;
				newPos.x += transform.localScale.x / 2.0f;
				newPos.x -= 0.01f;
				
				if(largeurReserve > 1)
				{
					newPos.z -= largeurReserve-1;
				}
				
				transform.position = newPos;
				//print ("GO etape == 2");
			}
		}
		else if( etape == 2)
		{
			
			Vector3 newPos = transform.position;
			newPos.z -= 1.0f;
         
            transform.position = newPos;
			
			if( transform.position.z - transform.localScale.z/2.0f < _reserve.transform.position.z - _reserve.transform.localScale.z/2.0f )
			{

				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+90.0f,transform.eulerAngles.z);

				etape = 1;
				newPos = _reserve.transform.position;
				newPos.y = 2.1f;
				
				newPos.z -= _reserve.transform.localScale.z / 2.0f;
				newPos.z += transform.localScale.z / 2.0f;
				newPos.z -= 0.01f;
				
				if(longueurReserve > 1)
				{
					newPos.x += longueurReserve-1;
				}
				
				transform.position = newPos;
				//print ("GO etape == 3");
			}
		}
		else if( etape == 3)
		{
			
			Vector3 newPos = transform.position;
			newPos.x += 1.0f;

            transform.position = newPos;
			
			if( transform.position.x + transform.localScale.x/2.0f > _reserve.transform.position.x + _reserve.transform.localScale.x/2.0f )
			{

				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+90.0f,transform.eulerAngles.z);

				etape = 2;
				newPos = _reserve.transform.position;
				newPos.y = 2.1f;
				
				newPos.x += _reserve.transform.localScale.x / 2.0f;
				newPos.x -= transform.localScale.x / 2.0f;
				newPos.x += 0.01f;
				
				if(largeurReserve > 1)
				{
					newPos.z += largeurReserve-1;
				}
				
				transform.position = newPos;
				//print ("GO etape == 4");
			}
		}
		else if( etape == 4)
		{
			
			Vector3 newPos = transform.position;
			newPos.z += 1.0f;
           
            transform.position = newPos;
			
			if( transform.position.z + transform.localScale.z/2.0f > _reserve.transform.position.z + _reserve.transform.localScale.z/2.0f )
			{

				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y+90.0f,transform.eulerAngles.z);

				etape = 3;
				newPos = _reserve.transform.position;
				newPos.y = 2.1f;
				
				newPos.z += _reserve.transform.localScale.z / 2.0f;
				newPos.z -= transform.localScale.z / 2.0f;
				newPos.z += 0.01f;
				
				if(longueurReserve > 1)
				{
					newPos.x -= longueurReserve-1;
				}
				
				transform.position = newPos;
				//print ("GO etape == 1");
			}
		}
		
		transform.parent = _reserve.transform;
		
	}

	public void ReplaceDoor_Right()
	{

		transform.parent = _sceneManager.transform;

		int longueurReserve = _sceneManager_Script._reserveLongueur;
		int largeurReserve = _sceneManager_Script._reserveLargeur;

		//devant
		if( etape == 1)
		{

			Vector3 newPos = transform.position;
			newPos.x += 1.0f;
            
            transform.position = newPos;

			if( transform.position.x + transform.localScale.x/2.0f > _reserve.transform.position.x + _reserve.transform.localScale.x/2.0f )
			{

				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y-90.0f,transform.eulerAngles.z);

				etape = 2;
				newPos = _reserve.transform.position;
				newPos.y = 2.1f;
				
				newPos.x += _reserve.transform.localScale.x / 2.0f;
				newPos.x -= transform.localScale.x / 2.0f;
				newPos.x += 0.01f;

				if(largeurReserve > 1)
				{
					newPos.z -= largeurReserve-1;
				}

				transform.position = newPos;
				//print ("GO etape == 2");
			}
		}
		else if( etape == 2)
		{
			
			Vector3 newPos = transform.position;
			newPos.z += 1.0f;
			
			transform.position = newPos;
			
			if( transform.position.z + transform.localScale.z/2.0f > _reserve.transform.position.z + _reserve.transform.localScale.z/2.0f )
			{

				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y-90.0f,transform.eulerAngles.z);

				etape = 3;
				newPos = _reserve.transform.position;
				newPos.y = 2.1f;

				newPos.z += _reserve.transform.localScale.z / 2.0f;
				newPos.z -= transform.localScale.z / 2.0f;
				newPos.z += 0.01f;

				if(longueurReserve > 1)
				{
					newPos.x += longueurReserve-1;
				}

				transform.position = newPos;
				//print ("GO etape == 3");
			}
		}
		else if( etape == 3)
		{
			
			Vector3 newPos = transform.position;
			newPos.x -= 1.0f;
			
			transform.position = newPos;
			
			if( transform.position.x - transform.localScale.x/2.0f < _reserve.transform.position.x - _reserve.transform.localScale.x/2.0f )
			{

				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y-90.0f,transform.eulerAngles.z);

				etape = 4;
				newPos = _reserve.transform.position;
				newPos.y = 2.1f;
				
				newPos.x -= _reserve.transform.localScale.x / 2.0f;
				newPos.x += transform.localScale.x / 2.0f;
				newPos.x -= 0.01f;

				if(largeurReserve > 1)
				{
					newPos.z += largeurReserve-1;
				}

				transform.position = newPos;
				//print ("GO etape == 4");
			}
		}
		else if( etape == 4)
		{
			
			Vector3 newPos = transform.position;
			newPos.z -= 1.0f;
			
			transform.position = newPos;
			
			if( transform.position.z - transform.localScale.z/2.0f < _reserve.transform.position.z - _reserve.transform.localScale.z/2.0f )
			{

				transform.eulerAngles = new Vector3(transform.eulerAngles.x,transform.eulerAngles.y-90.0f,transform.eulerAngles.z);

				etape = 1;
				newPos = _reserve.transform.position;
				newPos.y = 2.1f;
				
				newPos.z -= _reserve.transform.localScale.z / 2.0f;
				newPos.z += transform.localScale.z / 2.0f;
				newPos.z -= 0.01f;

				if(longueurReserve > 1)
				{
					newPos.x -= longueurReserve-1;
				}

				transform.position = newPos;
				//print ("GO etape == 1");
			}
		}

		transform.parent = _reserve.transform;

	}

	public void ReinitDoor()
	{

		etape = 1;
		Vector3 newPos = _reserve.transform.position;
		newPos.y = 2.1f;
		
		newPos.z -= _reserve.transform.localScale.z / 2.0f;
		newPos.z += transform.localScale.z / 2.0f;
		newPos.z -= 0.01f;
    
        transform.position = newPos;

	}


}
