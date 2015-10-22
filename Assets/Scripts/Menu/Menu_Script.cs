using UnityEngine;
using System.Collections;

abstract public class Menu_Script : MonoBehaviour {

	public Select_Object_Script  _select_Object_Script;

	// Use this for initialization
	protected void start () 
	{
		_select_Object_Script = GameObject.Find ("SceneManager").GetComponent<Select_Object_Script> ();
	}
	
	// Update is called once per frame
	protected void update () 
	{
	
	}

	virtual public void Reinit() {}
}
