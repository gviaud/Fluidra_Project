using UnityEngine;
using System.Collections;

public class Spa_Script : MonoBehaviour {

    Vector3 InitPosition;
    
    GameObject shell;
    GameObject skirt;
    GameObject plage;
    GameObject mask;

    // Use this for initialization
    void Start ()
    {

        InitPosition = transform.position;

        shell = transform.FindChild("coque").gameObject;
        skirt = transform.FindChild("jupe").gameObject;
        plage = transform.FindChild("plage").gameObject;
        mask = transform.FindChild("mask").gameObject;

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.F1))
            AboveGround();
        else if (Input.GetKeyDown(KeyCode.F2))
            Semi_Bury();
        else  if (Input.GetKeyDown(KeyCode.F3))
            Bury();

    }

    void Change_Texture(GameObject _gameObject, Texture _tex)
    {
        if(_gameObject != null && ( _gameObject == shell || _gameObject == skirt))
            _gameObject.GetComponent<Renderer>().material.mainTexture = _tex;
    }

    void Pump()
    {



    }


    

    void AboveGround()
    {

        plage.transform.localPosition = new Vector3(0, 0, 0);
        mask.transform.localPosition = new Vector3(0, 0, 0);
        transform.position = InitPosition - new Vector3(0, 0, 0);

    }
    void Semi_Bury()
    {

        plage.transform.localPosition = new Vector3(0, 0.4f, 0);
        mask.transform.localPosition = new Vector3(0, 0.4f, 0);
        transform.position = InitPosition - new Vector3(0, 0.4f, 0);

    }
    void Bury()
    {

        plage.transform.localPosition = new Vector3(0, 0.85f, 0);
        mask.transform.localPosition = new Vector3(0, 0.85f, 0);
        transform.position = InitPosition - new Vector3(0, 0.85f, 0);

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
