using UnityEngine;
using System.Collections;

public class Floor_Script : InteracibleObject_Script {

	// Use this for initialization
	void Start () 
	{
		start();
		//ChangeColor (MySingleton.Instance._colorTextureFloor);
		_name = "Sol";

	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	override public void UpdateAll()
	{

		_lastMousePos = Input.mousePosition;
	}

	public void ChangeColor(int color)
	{

		if(color == 0)
			GetComponent<MeshRenderer> ().material.color = new Color(13.0f/255.0f, 13.0f / 255.0f, 13.0f / 255.0f);//Noir
		else if(color == 1)
			GetComponent<MeshRenderer> ().material.color = new Color(54.0f / 255.0f, 10.0f / 255.0f, 10.0f / 255.0f);//Rouge
		else if(color == 2)
			GetComponent<MeshRenderer> ().material.color = new Color(14.0f / 255.0f, 14.0f / 255.0f, 41.0f / 255.0f);//Bleu
		else if(color == 3)
			GetComponent<MeshRenderer> ().material.color = new Color(0.85f,0.85f,0.85f);//Blanc	

		_saveColor = transform.GetComponent<MeshRenderer> ().material.color;

	}

	override public void Changetexture(int num)
	{
		
		Texture tex = GetComponent<MeshRenderer> ().material.mainTexture;
		
		if(num < 10)
			tex = Resources.Load ("Textures/0"+num) as Texture;
		else
			tex = Resources.Load ("Textures/"+num) as Texture;
		
		GetComponent<MeshRenderer> ().material.mainTexture = tex;
	
	}

}

