/*
Viaud Guillaume 20/10/2015

Drag and drop une image sur le collider de ce gameObject permet d'appeler le bon objet et de lui changer sa texture

*/
using UnityEngine;
using System.Collections;

public class DropOnUnityMenu : MonoBehaviour {
		
		public bool growOnExternalDragOver = true;
		public Select_Object_Script selectedObj;
		private Vector3 dftScale;
		private bool isDraging;
		void Start() {
			isDraging = false;
			//dftScale = selectedObj._select_GO.transform.localScale;
		}
		void Update(){
		/*
		if(!isDraging && selectedObj._select_GO != null)
			{
				dftScale = selectedObj._select_GO.transform.localScale;
			}
			*/
		}
		public void OnExternalDragOver(Vector3 cursorPosition) {
			isDraging = true;
			//selectedObj._select_GO.transform.localScale = dftScale*1.1f;
		}
		public void OnExternalDragCancel() {
			//selectedObj._select_GO.transform.localScale = dftScale;
			isDraging = false;
			
		}
		void Simplify(int[] numbers)
		{
			int gcd = GCD(numbers[0],numbers[1]);
			for (int i = 0; i < numbers.Length; i++)
				numbers[i] /= gcd;
		}
		int GCD(int a, int b)
		{
			while (b > 0)
			{
				int rem = a % b;
				a = b;
				b = rem;
			}
			return a;
		}
		
		public void OnExternalDragEnd(Texture2D aTexture) {
			
            if(selectedObj._select_GO != null)
            {
			    if (selectedObj._select_GO.GetComponent<DropOnUnityTarget> () != null) 
			    {
				    DropOnUnityTarget dropOnUnityTarget = selectedObj._select_GO.GetComponent<DropOnUnityTarget> ();
				    dropOnUnityTarget.OnExternalDragEnd (aTexture);
			    }
            }
            isDraging = false;
			/*
			Decal_Script decal_Script = GetComponent<Decal_Script>();
			
			int[] tab = new int[2];
			print (""+aTexture.width+ "   "+aTexture.height);
			tab[0] = aTexture.width;
			tab[1] = aTexture.height;
			Simplify(tab);
			float ratio = (float)tab[0]/(float)tab[1];
			print (""+ratio);
			
			decal_Script._ratioX = ratio;
			decal_Script._ratioY = 1;
			selectedObj._select_GO.transform.localScale = new Vector3(ratio,1f,1f);
			
			selectedObj._select_GO.GetComponent<Renderer>().material.mainTexture = aTexture;
			// what we receive is a newly instatiated texture, 
			// you may want to clean up the previous texture
			selectedObj._select_GO.transform.localScale = dftScale;
			isDraging = false;
			*/
		}
		public void OnExternalDragEnd(string text) {
			Debug.Log("text received. Length: "+text.Length);
		}
		public void OnExternalDragEnd(byte[] bytes) {
			Debug.Log(bytes.Length+" bytes received");
		}


}
