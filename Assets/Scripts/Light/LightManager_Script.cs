/*
Viaud Guillaume 20/10/2015

Création et suppression des lumière pour chaque Objet

*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightManager_Script : MonoBehaviour {


	public GameObject _light_Menu;

    public GameObject[] Light_ModelReserve;
    public GameObject[] Light_Model_Wall;
    public GameObject[] Light_Model_Enseigne;

    SceneManager_Script _sceneManager_Script;
	Select_Object_Script _select_Object_Script;

    public GameObject[] _Light_Main_Tab;
    public GameObject[] _Light_Left_Tab;
    public GameObject[] _Light_Right_Tab;

    public GameObject[] _Light_Reserve_Tab;

    public GameObject[] _Light_Enseigne_Tab;


	public int nbrLightWallMain;
	public int nbrLightWallLeft;
	public int nbrLightWallRight;

	public int nbrLightWallReserve;
	public int nbrLightWallEnseigne;

	// Use this for initialization
	void Start () 
	{
		_sceneManager_Script = GameObject.Find ("SceneManager").GetComponent<SceneManager_Script>();
		_select_Object_Script = GameObject.Find ("SceneManager").GetComponent<Select_Object_Script>();

	}
	
	// Update is called once per frame
	void Update () 
	{
 
    }


	public void activLightEnseigne(bool _activ)
	{
		if(_Light_Enseigne_Tab != null)
		{
			for( int i = 0; i < _Light_Enseigne_Tab.Length; i++ )
			{
				_Light_Enseigne_Tab[i].SetActive(_activ);
			}
			_sceneManager_Script._Enseigne.transform.GetChild(0).GetComponent<InteracibleObject_Script>().lightIsActiv =_activ;
			_sceneManager_Script._Enseigne.transform.GetChild(1).GetComponent<InteracibleObject_Script>().lightIsActiv =_activ;
			_sceneManager_Script._Enseigne.transform.GetChild(2).GetComponent<InteracibleObject_Script>().lightIsActiv =_activ;
			_sceneManager_Script._Enseigne.transform.GetChild(3).GetComponent<InteracibleObject_Script>().lightIsActiv =_activ;
            UpdateLight();
            //_light_Menu.transform.FindChild ("EnseigneToggle").GetComponent<Toggle> ().isOn = _activ;
        }
	}


	public void activLight(GameObject _obj)
	{

		switch( _select_Object_Script._select_GO.name )
		{
		case "Wall_Main":
			if(_Light_Main_Tab != null)
			{
				for( int i = 0; i < _Light_Main_Tab.Length; i++)
					_Light_Main_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_select_Object_Script._select_GO.GetComponent<InteracibleObject_Script>().lightIsActiv = _obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("MurFondToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;
		case "Wall_Left":
			if(_Light_Left_Tab != null)
			{
				for( int i = 0; i < _Light_Left_Tab.Length; i++)
					_Light_Left_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_select_Object_Script._select_GO.GetComponent<InteracibleObject_Script>().lightIsActiv = _obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("MurGaucheToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;
		case "Wall_Right":
			if(_Light_Right_Tab != null)
			{
				for( int i = 0; i < _Light_Right_Tab.Length; i++)
					_Light_Right_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_select_Object_Script._select_GO.GetComponent<InteracibleObject_Script>().lightIsActiv = _obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("MurDroiteToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;
		case "Reserve":
			if(_Light_Reserve_Tab != null)
			{
				for( int i = 0; i < _Light_Reserve_Tab.Length; i++)
					_Light_Reserve_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_select_Object_Script._select_GO.GetComponent<InteracibleObject_Script>().lightIsActiv = _obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("ReserveToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;
		case "EnseigneBack":
			if(_Light_Enseigne_Tab != null)
			{
				for( int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					_Light_Enseigne_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_sceneManager_Script._Enseigne.transform.GetChild(0).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(1).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(2).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(3).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("EnseigneToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;
		case "EnseigneFront":
			if(_Light_Enseigne_Tab != null)
			{
				for( int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					_Light_Enseigne_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_sceneManager_Script._Enseigne.transform.GetChild(0).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(1).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(2).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(3).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("EnseigneToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;
		case "EnseigneDroite":
			if(_Light_Enseigne_Tab != null)
			{
				for( int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					_Light_Enseigne_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_sceneManager_Script._Enseigne.transform.GetChild(0).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(1).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(2).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(3).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("EnseigneToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;
		case "EnseigneGauche":
			if(_Light_Enseigne_Tab != null)
			{
				for( int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					_Light_Enseigne_Tab[i].gameObject.SetActive(_obj.GetComponent<Toggle>().isOn);
				_sceneManager_Script._Enseigne.transform.GetChild(0).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(1).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(2).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_sceneManager_Script._Enseigne.transform.GetChild(3).GetComponent<InteracibleObject_Script>().lightIsActiv =_obj.GetComponent<Toggle>().isOn;
				_light_Menu.transform.FindChild ("EnseigneToggle").GetComponent<Toggle> ().isOn = _obj.GetComponent<Toggle>().isOn;
			}
			break;

		}

	}

    public void UpdateLight()
    {
        if (_sceneManager_Script != null)
        { 
            DeleteAllLightTable();

            UpdateMainWall_Light();
            UpdateLeftWall_Light();
            UpdateRightWall_Light();
            UpdateReserve_Light();
            UpdateEnseigne_Light();

            CheckAllLight();
        }
	}

	public void CheckLight(GameObject _obj)
	{

		
			switch (_obj.name) {
			case "Wall_Main":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallMain = 0;
				if (_Light_Main_Tab != null) {
					for (int i = 0; i < _Light_Main_Tab.Length; i++)
					{
						_Light_Main_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Main_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallMain++;
					}
				}
			}
			else
				nbrLightWallMain = 0;
				break;
			case "Wall_Left":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallLeft = 0;
				if (_Light_Left_Tab != null) {
					for (int i = 0; i < _Light_Left_Tab.Length; i++)
					{
						_Light_Left_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Left_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallLeft++;
					}
				}
			}
			else
			nbrLightWallLeft = 0;
				break;
			case "Wall_Right":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallRight = 0;
				if (_Light_Right_Tab != null) {
					for (int i = 0; i < _Light_Right_Tab.Length; i++)
					{
						_Light_Right_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Right_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallRight++;
					}
				}
			}
			else
				nbrLightWallRight = 0;
				break;
			case "Reserve":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallReserve = 0;
				if (_Light_Reserve_Tab != null) {
					for (int i = 0; i < _Light_Reserve_Tab.Length; i++)
					{
						_Light_Reserve_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Reserve_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallReserve++;
					}
				}
			}
			else
				nbrLightWallReserve = 0;
				break;
			case "EnseigneBack":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallEnseigne = 0;
				if (_Light_Enseigne_Tab != null) {
					for (int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					{
						_Light_Enseigne_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Enseigne_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallEnseigne++;
					}
				}
			}
			else
				nbrLightWallEnseigne = 0;
				break;
			case "EnseigneFront":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallEnseigne = 0;
				if (_Light_Enseigne_Tab != null) {
					for (int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					{
						_Light_Enseigne_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Enseigne_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallEnseigne++;
					}
				}
			}
			else
				nbrLightWallEnseigne = 0;
				break;
			case "EnseigneDroite":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallEnseigne = 0;
				if (_Light_Enseigne_Tab != null) {
					for (int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					{
						_Light_Enseigne_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Enseigne_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallEnseigne++;
					}
				}
			}
			else
				nbrLightWallEnseigne = 0;
				break;
			case "EnseigneGauche":
			if (_obj.gameObject.activeInHierarchy) 
			{
				nbrLightWallEnseigne = 0;
				if (_Light_Enseigne_Tab != null) {
					for (int i = 0; i < _Light_Enseigne_Tab.Length; i++)
					{
						_Light_Enseigne_Tab [i].gameObject.SetActive (_obj.GetComponent<InteracibleObject_Script> ().lightIsActiv);
						if( _Light_Enseigne_Tab [i].gameObject.activeInHierarchy)
							nbrLightWallEnseigne++;
					}
				}
			}
			else
				nbrLightWallEnseigne = 0;
				break;
			
			}
		
	}

	public void CheckAllLight()
	{

		for(int i = 0 ; i < _sceneManager_Script.Wall_Tab.Length ; i++)
			CheckLight (_sceneManager_Script.Wall_Tab[i]);

		CheckLight (_sceneManager_Script._Reserve);

		CheckLight (_sceneManager_Script._Enseigne.transform.GetChild(1).gameObject);
	}

	public void UpdateEnseigne_Light()
	{
		
		int longueur = _sceneManager_Script._enseigneLongueur;
		int largeur = _sceneManager_Script._enseigneLargeur;
		
		if( _sceneManager_Script._Enseigne.activeInHierarchy)
		{
			
			if( largeur <= 1 && longueur <= 1 )
				_Light_Enseigne_Tab = null;
			else if( largeur <= 1)
				_Light_Enseigne_Tab = new GameObject[ (longueur-1)*2 ];
			else if( longueur <= 1)
				_Light_Enseigne_Tab = new GameObject[ (largeur-1)*2 ];
			else
				_Light_Enseigne_Tab = new GameObject[ (longueur-1)*2 + (largeur-1)*2 ];
			
			
			Vector3 newPosition = _sceneManager_Script._Enseigne.transform.position;
			
			int maxl = ((longueur-1)*2);
			int i = 0;
			if( longueur > 1)
			{
				
				float addX = 2.0f;
				
				while( i < longueur-1)
				{
                    
					Transform child = _sceneManager_Script._Enseigne.transform.FindChild("EnseigneFront").transform;
					GameObject newLight = Instantiate(Light_Model_Enseigne[0], Light_Model_Enseigne[0].transform.position, Light_Model_Enseigne[0].transform.rotation) as GameObject;
                    newLight.transform.position = new Vector3((child.position.x - child.localScale.x / 2.0f) + addX, 10.438f, (child.position.z - child.localScale.z / 2.0f) - 0.4f);

                    newLight.SetActive(true);

					newLight.transform.parent = _sceneManager_Script._Enseigne.transform;
					_Light_Enseigne_Tab[i] = newLight;

                   addX += 2.0f;
                    
                    i++;
                    


                }
				addX = 2.0f;
				while( i < (longueur-1)*2)
				{


                    Transform child = _sceneManager_Script._Enseigne.transform.FindChild("EnseigneBack").transform;
                    GameObject newLight = Instantiate(Light_Model_Enseigne[1], Light_Model_Enseigne[1].transform.position, Light_Model_Enseigne[1].transform.rotation) as GameObject;
                    newLight.transform.position = new Vector3((child.position.x - child.localScale.x / 2.0f) + addX, 10.438f, (child.position.z + child.localScale.z / 2.0f) + 0.4f);

                    newLight.SetActive(true);

                    newLight.transform.parent = _sceneManager_Script._Enseigne.transform;
                    _Light_Enseigne_Tab[i] = newLight;

                    addX += 2.0f;

                    i++;

                }
				
			}
			else
				maxl = 0;
			
			if( largeur > 1)
			{
				
				float addZ = 2.0f;
				while( i < maxl + largeur-1)
				{

                    Transform child = _sceneManager_Script._Enseigne.transform.FindChild("EnseigneGauche").transform;
                    GameObject newLight = Instantiate(Light_Model_Enseigne[2], Light_Model_Enseigne[2].transform.position, Light_Model_Enseigne[2].transform.rotation) as GameObject;
                    newLight.transform.position = newLight.transform.position = new Vector3(child.position.x - 0.4f, 10.438f, (child.position.z - child.localScale.x / 2.0f) + addZ);

                    newLight.SetActive(true);

                    newLight.transform.parent = _sceneManager_Script._Enseigne.transform;
                    _Light_Enseigne_Tab[i] = newLight;

                    addZ += 2.0f;

                    i++;


                }
				addZ = 2.0f;
				while( i < maxl + (largeur-1)*2)
				{


                    Transform child = _sceneManager_Script._Enseigne.transform.FindChild("EnseigneDroite").transform;
                    GameObject newLight = Instantiate(Light_Model_Enseigne[3], Light_Model_Enseigne[3].transform.position, Light_Model_Enseigne[3].transform.rotation) as GameObject;

                    newLight.SetActive(true);

                    newLight.transform.position = new Vector3(child.position.x + 0.4f, 10.438f, (child.position.z - child.localScale.x / 2.0f) + addZ);
                    newLight.transform.parent = _sceneManager_Script._Enseigne.transform;
                    _Light_Enseigne_Tab[i] = newLight;

                    addZ += 2.0f;


                    i ++;

           

                }
				
			}
			
			
		}
	}







	public void UpdateReserve_Light()
	{

		int longueur = _sceneManager_Script._reserveLongueur;
		int largeur = _sceneManager_Script._reserveLargeur;
		
		if( _sceneManager_Script._Reserve.activeInHierarchy)
		{

			if( largeur <= 1 && longueur <= 1 )
				_Light_Reserve_Tab = null;
			else if( largeur <= 1)
				_Light_Reserve_Tab = new GameObject[ (longueur-1)*2 ];
			else if( longueur <= 1)
				_Light_Reserve_Tab = new GameObject[ (largeur-1)*2 ];
			else
				_Light_Reserve_Tab = new GameObject[ (longueur-1)*2 + (largeur-1)*2 ];


			Vector3 newPosition = _sceneManager_Script._Reserve.transform.position;

			int maxl = ((longueur-1)*2);
			int i = 0;
			if( longueur > 1)
			{

				float addX = 2.0f;

				while( i < longueur-1)
				{
                    
					GameObject newLight = Instantiate(Light_ModelReserve[0], newPosition, Light_ModelReserve[0].transform.rotation) as GameObject;

					newLight.SetActive(true);
                    newLight.transform.position = new Vector3( (_sceneManager_Script._Reserve.transform.position.x - _sceneManager_Script._Reserve.transform.localScale.x/2.0f)+ addX, 4.944f, (_sceneManager_Script._Reserve.transform.position.z - _sceneManager_Script._Reserve.transform.localScale.z/2.0f)-0.779f);

					_Light_Reserve_Tab[i] = newLight;
                    addX += 2.0f;
					i ++;
                    
                }
				addX = 2.0f;
				while( i < (longueur-1)*2)
				{

                    GameObject newLight = Instantiate(Light_ModelReserve[1], newPosition, Light_ModelReserve[1].transform.rotation) as GameObject;

                    newLight.SetActive(true);
                    newLight.transform.position = new Vector3((_sceneManager_Script._Reserve.transform.position.x - _sceneManager_Script._Reserve.transform.localScale.x / 2.0f) + addX, 4.944f, (_sceneManager_Script._Reserve.transform.position.z + _sceneManager_Script._Reserve.transform.localScale.z / 2.0f) + 0.779f);

                    _Light_Reserve_Tab[i] = newLight;
                    addX += 2.0f;
                    i++;
                }

			}
			else
				maxl = 0;
			
			if( largeur > 1)
			{
				
				float addZ = 2.0f;
				while( i < maxl + largeur-1)
				{

                    GameObject newLight = Instantiate(Light_ModelReserve[2], newPosition, Light_ModelReserve[2].transform.rotation) as GameObject;

                    newLight.SetActive(true);
                    newLight.transform.position = new Vector3((_sceneManager_Script._Reserve.transform.position.x - _sceneManager_Script._Reserve.transform.localScale.x / 2.0f) - 0.779f, 4.944f, (_sceneManager_Script._Reserve.transform.position.z - _sceneManager_Script._Reserve.transform.localScale.z / 2.0f) + addZ);

                    _Light_Reserve_Tab[i] = newLight;

                    addZ += 2.0f;
					i ++;

				}
				addZ = 2.0f;
				while( i < maxl + (largeur-1)*2)
				{

                    GameObject newLight = Instantiate(Light_ModelReserve[3], newPosition, Light_ModelReserve[3].transform.rotation) as GameObject;

                    newLight.SetActive(true);
                    newLight.transform.position = new Vector3((_sceneManager_Script._Reserve.transform.position.x + _sceneManager_Script._Reserve.transform.localScale.x / 2.0f) + 0.779f, 4.944f, (_sceneManager_Script._Reserve.transform.position.z - _sceneManager_Script._Reserve.transform.localScale.z / 2.0f) + addZ);

                    _Light_Reserve_Tab[i] = newLight;

                    addZ += 2.0f;
                    i++;

                }
				
			}


		}
	}
	
	public void UpdateRightWall_Light()
	{
		if(_sceneManager_Script != null)
        { 
		    int largeur = _sceneManager_Script._largeur;
		
		    if( _sceneManager_Script.Wall_Tab [2].activeInHierarchy)
		    {
			
			    _Light_Right_Tab = new GameObject[largeur-1];

			    float scaleWall = _sceneManager_Script.Wall_Tab [2].transform.localScale.x;
			    Vector3 newPosition = _sceneManager_Script.Wall_Tab[2].transform.position;
			    newPosition.x -= 0.841f;

                float addZ = 2.0f;
			    for( int i = 0; i < largeur-1; i++)
			    {
				
				    newPosition.y = 4.944f;
                    newPosition.z = -(scaleWall/2.0f)+addZ;
				
				    addZ += 2.0f;
                    GameObject newLight = Instantiate(Light_Model_Wall[2], newPosition, Light_Model_Wall[2].transform.rotation) as GameObject;

                    newLight.SetActive(true);
				    newLight.transform.parent = transform;

                    _Light_Right_Tab[i] = newLight;


                }
			
		    }
            
        }
    }


	public void UpdateLeftWall_Light()
	{
        if (_sceneManager_Script != null)
        { 
            int largeur = _sceneManager_Script._largeur;
		
            
		    if( _sceneManager_Script.Wall_Tab [1].activeInHierarchy)
		    {
			
			    _Light_Left_Tab = new GameObject[largeur-1];

			    float scaleWall = _sceneManager_Script.Wall_Tab [1].transform.localScale.x;
			    Vector3 newPosition = _sceneManager_Script.Wall_Tab[1].transform.position;
			    newPosition.x += 0.841f;

                float addZ = 2.0f;
			    for( int i = 0; i < largeur-1; i++)
			    {
				
				    newPosition.y = 4.944f;
                    newPosition.z = -(scaleWall/2.0f)+addZ;
				
				
				    addZ += 2.0f;

                    GameObject newLight = Instantiate(Light_Model_Wall[1], newPosition, Light_Model_Wall[1].transform.rotation) as GameObject;

                    newLight.SetActive(true);
				    newLight.transform.parent = transform;

                    _Light_Left_Tab[i] = newLight;

				
			    }
			
		    }
            
        }
    }

	public void UpdateMainWall_Light()
	{
        
        int longueur = 0;
        if (_sceneManager_Script != null)
        { 
		    longueur = _sceneManager_Script._longueur;

            
		    if( _sceneManager_Script.Wall_Tab [0].activeInHierarchy)
		    {
                
                _Light_Main_Tab = new GameObject[longueur-1];

			    float scaleWall = _sceneManager_Script.Wall_Tab [0].transform.localScale.x;
			    Vector3 newPosition = _sceneManager_Script.Wall_Tab[0].transform.position;
			    newPosition.z -= 0.841f;
			
			    float addX = 2.0f;
			    for( int i = 0; i < longueur-1; i++)
			    {
                    
                    newPosition.y = 4.944f;
                    newPosition.x = -(scaleWall/2.0f)+addX;
				
				    addX += 2.0f;
				
				    GameObject newLight = Instantiate(Light_Model_Wall[0], newPosition, Light_Model_Wall[0].transform.rotation) as GameObject;

                    newLight.SetActive(true);
				    newLight.transform.parent = transform;
		
                    _Light_Main_Tab[i] = newLight;
                   
                }

            }
           
        }
    }

	
	void DeleteAllLightTable()
	{
		if(_Light_Main_Tab != null)
		{
			for( int i = 0; i < _Light_Main_Tab.Length; i++)
			{
				DestroyImmediate( _Light_Main_Tab[i].gameObject );
			}
		}
		
		if(_Light_Left_Tab != null)
		{
			for( int i = 0; i < _Light_Left_Tab.Length; i++)
			{
				DestroyImmediate( _Light_Left_Tab[i].gameObject );
			}
		}
		
		if(_Light_Right_Tab != null)
		{
			for( int i = 0; i < _Light_Right_Tab.Length; i++)
			{
				DestroyImmediate( _Light_Right_Tab[i].gameObject );
			}
		}

		if(_Light_Reserve_Tab != null)
		{
			for( int i = 0; i < _Light_Reserve_Tab.Length; i++)
			{
				DestroyImmediate( _Light_Reserve_Tab[i].gameObject );
			}
		}

		if(_Light_Enseigne_Tab != null)
		{
			for( int i = 0; i < _Light_Enseigne_Tab.Length; i++)
			{
				DestroyImmediate( _Light_Enseigne_Tab[i].gameObject );
			}
		}
	}


    public void ChangePosReserveLight(Vector3 lastPos, Vector3 newPos)
    {

        Vector3 pos = newPos - lastPos;
        pos.y = 0;
        if (_Light_Reserve_Tab != null)
        {
            for (int i = 0; i < _Light_Reserve_Tab.Length; i++)
            {
                _Light_Reserve_Tab[i].transform.position += pos;
            }

        }
    }

}



