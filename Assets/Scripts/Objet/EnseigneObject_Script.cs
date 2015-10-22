using UnityEngine;
using System.Collections;

public class EnseigneObject_Script : InteracibleObject_Script {
 
        // Use this for initialization
        void Start () 
        {
			start();
			_name = "Enseigne";
            menuSideNum = 5;
            _saveColor = new Color(1, 1, 1, 1);
        }
        
        // Update is called once per frame
        void Update () 
        {
            
        }

}
