using UnityEngine;
using System.Collections;

public class Texture_Script : MonoBehaviour {

	public int tex;

    void Awake ()
	{
		//Changetexture (tex);
	}
	
	// Use this for initialization
	void Start () 
	{
        //Changetexture (tex);
        tex = 0;
    }
	
	// Update is called once per frame
	void Update () 
	{
        //print("tex : " + tex);
	}

    public void ChangeNumTex(int i)
    {
        tex = i;
    }

    public void Loadtexture()
	{
		Object[] tex_tab = Resources.LoadAll ("Textures");
		GetComponent<MeshRenderer> ().material.mainTexture = (Texture)tex_tab[0];
	}
	
	public void ChangeColor(int color)
	{
		
		GetComponent<MeshRenderer> ().material.color = Color.red;
		
	}
	
	public void Changetexture(int numtex)
	{
		if (numtex != -1) 
		{
			tex = numtex;
			Texture newTex = GetComponent<MeshRenderer> ().material.mainTexture;
		
			if (numtex < 10)
				newTex = Resources.Load ("Textures/0" + numtex) as Texture;
			else
				newTex = Resources.Load ("Textures/" + numtex) as Texture;
		
			GetComponent<MeshRenderer> ().material.mainTexture = newTex;

		}
	}

	public void AddTex(string _path)
	{
		
	}

}
