using UnityEngine;
using System.Collections;

abstract public class InteracibleObject_Script : MonoBehaviour {

	protected Vector3 _lastMousePos;
	protected SceneManager_Script _SceneManager_Script;
	protected Select_Object_Script _select_Object_Script;

	public GameObject[] _menu;
	public int _menuNum;

	public Color _saveColor;
	public LightManager_Script lights;
	public bool lightIsActiv = true;
	public string _name;

	public float _timer;
	protected bool _blockMove;
    public int menuSideNum;

	// Use this for initialization
	protected void start () 
	{

        _SceneManager_Script = GameObject.Find ("SceneManager").GetComponent<SceneManager_Script> ();
		_select_Object_Script = GameObject.Find ("SceneManager").GetComponent<Select_Object_Script> ();
		_lastMousePos = Input.mousePosition;

		_saveColor = transform.GetComponent<Renderer> ().material.color;
		_menuNum = 0;
		lightIsActiv = true;
		_blockMove = false;
	}

	virtual public void ChangeColor(Color newColor)
	{
		//transform.GetComponent<MeshRenderer> ().material.color = newColor;
	}

	// Update is called once per frame
	virtual public void UpdateAll() {}
	virtual public void Changetexture(int num) {}

}
/*
You can or have to override a method if it is marked as abstract or virtual in the base class.

A method is abstract when the base class wants its children to implement it. 
A method is virtual when the base class offers an implementation of it but 
also offers an opportunity for the children to implement/modify that method.

*/