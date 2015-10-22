/*
Viaud Guillaume 20/10/2015

Script d'initiation du menu

*/
using UnityEngine;
using System.Collections;

public class MainMenu_Script : MonoBehaviour {

	SceneManager_Script _SceneManager_Script;
	public GameObject _Floor;

	bool _start;

	// Use this for initialization
	void Awake () {
		MySingleton.Instance.Start ();
		_SceneManager_Script = GameObject.Find ("SceneManager").GetComponent<SceneManager_Script>();

	}

	void Start () {
		_start = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (_start) {
			ChangeLength(4);
			ChangeWidth (3);
			Desactiv ();
			_start = false;
		}
		_SceneManager_Script.UpdateALL ();
	}

	public void ChangeColorFloor(int colorTexture)
	{
		MySingleton.Instance._colorTextureFloor = colorTexture;
		_Floor.GetComponent<Floor_Script>().ChangeColor (MySingleton.Instance._colorTextureFloor);
	
	}

	public void ChangeLength(int length)
	{
		MySingleton.Instance._length = length;
		_SceneManager_Script._longueur = length;
	}
	public void ChangeWidth(int width)
	{
		MySingleton.Instance._width = width;
		_SceneManager_Script._largeur = width;
	}

	public void Desactiv()
	{

		_SceneManager_Script.Start ();

		GetComponent<MainMenu_Script> ().enabled = false;

	}

}
