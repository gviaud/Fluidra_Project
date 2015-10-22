using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Obj_Button : MonoBehaviour {

	public GameObject _go;
	Select_Object_Script _selectObject_Script;
	public GameObject _backgroundObject;
	public Select_Object_Script _select_Object_Script;

	// Use this for initialization
	void Start () {
		_selectObject_Script = GameObject.Find("SceneManager").GetComponent<Select_Object_Script>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreateButtonOnClick()
	{
		GetComponent<Button>().onClick.AddListener( () => CreateObject() );
	}

	public void CreateObject(   )
	{
        /*
		print (name);

		GameObject objectPrefab = _go;
		string objectname = objectPrefab.name;
		GameObject newGameobject = GameObject.Instantiate(objectPrefab);
		
		//Initialisation object
		newGameobject.transform.position = new Vector3(0,objectPrefab.transform.localScale.y/2.0f,0);
		newGameobject.layer = 8;
		
		newGameobject.AddComponent<Object_Script>();
		newGameobject.name = objectname;

		InteracibleObject_Script interactible_Script = newGameobject.GetComponent<InteracibleObject_Script>();
		interactible_Script._name = objectname;
		if( newGameobject.GetComponent<InitialisationObject>()._menuName.Length > 0 )
		{
			newGameobject.GetComponent<Object_Script>()._menuNum = 0;
			for(int x =0; x < 0; x++)
			{
				newGameobject.GetComponent<Object_Script>()._menu[x] = GameObject.Find(newGameobject.GetComponent<InitialisationObject>()._menuName[x]);
			}
		}

		_selectObject_Script.DeselectObject();
		_selectObject_Script._select_GO = newGameobject;

		interactible_Script.ChangeColor(new Color (0.2f, 1, 0.2f));
			
		GameObject.Find("SceneManager").GetComponent<SceneManager_Script>().DesactiveMenuDeroulant();
		interactible_Script._timer = 0.05f;

		if (interactible_Script._menuNum > -1) 
		{
			int lght = newGameobject.GetComponent<InitialisationObject>()._menuName.Length;
			if( lght > 0)
				interactible_Script._menu = new GameObject[lght];

			for( int i = 0; i < lght; i++)
			{
				if( _selectObject_Script.BackgroundMenuInGameOBJ.name == newGameobject.GetComponent<InitialisationObject>()._menuName[i])
				{
					interactible_Script._menu[i] = _selectObject_Script.BackgroundMenuInGameOBJ;
					interactible_Script._menu[i].GetComponent<Menu_Script> ().Reinit ();

				}
			}

		}
		_selectObject_Script.BackgroundMenu.SetActive(true);

		_selectObject_Script.BackgroundObject.SetActive(true);
		//_selectObject_Script.BackgroundMain.SetActive(false);
		_selectObject_Script.BackgroundAutre.SetActive(false);

		newGameobject.transform.parent = GameObject.Find ("BundleManager").transform;

		_backgroundObject.GetComponent<Animator>().runtimeAnimatorController = _select_Object_Script._anim[2];
	  */
    }

}
