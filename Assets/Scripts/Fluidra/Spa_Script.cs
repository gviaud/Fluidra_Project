using UnityEngine;
using System.Collections;

public class Spa_Script : MonoBehaviour {


    
    GameObject shell;
    GameObject skirt;



    // Use this for initialization
    void Start () {
        shell = transform.FindChild("coque").gameObject;
        skirt = transform.FindChild("jupe").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Change_Texture(GameObject _gameObject, Texture _tex)
    {
        if(_gameObject != null && ( _gameObject == shell || _gameObject == skirt))
            _gameObject.GetComponent<Renderer>().material.mainTexture = _tex;
    }


    public GameObject GetShell()
    {
        return shell;
    }
    public GameObject GetSkirt()
    {
        return skirt;
    }

}
