using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

using SimpleObjExtensions;

public class DropOnUnityCtrl : MonoBehaviour {

	public GameObject _chargementTXT;

	public int maxFileSizeInMB = 4;
	public string maxFileSizeMessage = "File too big";
	public TextAsset dragDropJavaScript;
	public string[] plainTextFileExtensions;
	public GameObject targetObject;
	public bool targetObjectUnderCursor;

	private GameObject lastDragTarget = null;
	private string base64String = null;
	private int nrOfFilesToExpect = 0;
	private int nrOfFilesReceived = 0;

//	private string logStr1 = "";
//	private string logStr2 = "";

	/* ----------------- add Javascript functions to webpage ----------------*/
	/* ----------------------------------------------------------------------*/
	void Start() {
		if(dragDropJavaScript == null) {
			Debug.Log("EDragDropCtrl.Start(): dragDropJavaScript not assigned");
			return;
		}

		// filter quotes from maxFileSizeMessage
		maxFileSizeMessage = maxFileSizeMessage.Replace("\'",""); // filter quotes from maxFileSizeMessage
		maxFileSizeMessage = maxFileSizeMessage.Replace("\"",""); // filter quotes from maxFileSizeMessage
		maxFileSizeMessage = maxFileSizeMessage.Replace("<br>","\n"); // put in new lines
		Application.ExternalEval(dragDropJavaScript.text +
			"\n_edd_dragDrop('" + gameObject.name + "'," + maxFileSizeInMB + ",'" + maxFileSizeMessage + "');");
//		Application.ExternalEval("_edd_dragDrop('" + gameObject.name + "'," + maxFileSizeInMB + ");");
	}

	/* -------------------- functions called by webpage ---------------------*/
	/* ----------------------------------------------------------------------*/

	public void ExternalDragOver(string positionString) {
		int begin = 0;
		int commaPos = positionString.IndexOf(",", begin);
		int index = 0;
		float[] values = new float[4];
		while(commaPos > begin && index < 4) {
			values[index++] = FloatFromString(positionString.Substring(begin, commaPos-begin));
			if(index < 4) {
				begin = commaPos+1;
				if(begin < positionString.Length) commaPos = positionString.IndexOf(",", begin);
				if(commaPos<=begin) commaPos = positionString.Length;
			}
		}
		if(values[2] > 0f && values[3] > 0f) {
			BroadcastExternalDragOver(new Vector3(values[0] * (Screen.width / values[2]), 
				Screen.height - (values[1] * (Screen.height / values[3])), 
				0f));
        } else {
			BroadcastExternalDragOver(new Vector3(values[0], 
				Screen.height - values[1], 
				0f));
        }
	}
	public void ExternalDragCancel(string dummy) {
		base64String = null;
		if(targetObject != null) {
			targetObject.BroadcastMessage("OnExternalDragCancel", null, SendMessageOptions.DontRequireReceiver);
		}
	    if(lastDragTarget != null) {
	    	lastDragTarget.BroadcastMessage("OnExternalDragCancel", null, SendMessageOptions.DontRequireReceiver);
	    	lastDragTarget = null;
	    }
	}

	public void ExternalDragDataChunk(string base64Chunk) {
		if(base64String == null) base64String = base64Chunk;
		else base64String = base64String + base64Chunk;
	}
	public void ExternalDroppedFilesCount(string filesCount) {
		nrOfFilesToExpect = filesCount.MakeInt();
		nrOfFilesReceived = 0;
		if(targetObject != null) {
			targetObject.BroadcastMessage("OnExternalDragFilesToExpect", nrOfFilesToExpect, SendMessageOptions.DontRequireReceiver);
		}
	    if(lastDragTarget != null) {
	    	lastDragTarget.BroadcastMessage("OnExternalDragFilesToExpect", nrOfFilesToExpect, SendMessageOptions.DontRequireReceiver);
	    }
	}

	public void ExternalDragEnd(string positionString) {

		ExternalDragOver(positionString);
		nrOfFilesReceived++;
		if(base64String == null) {
			ExternalDragCancel(null);
			return;
		}
		string fileName = "";
		string fileExtension = "";
		string fileType = "";
		int pos = base64String.IndexOf(";");
		if(pos>=0) fileName = base64String.Substring(0, pos);
		else pos = 0;
		int dotPos = fileName.LastIndexOf(".");
		if(dotPos>=0) fileExtension = fileName.Substring(dotPos+1).ToLower();

		pos = base64String.IndexOf("data:", pos);
		if(pos >= 0) {
			pos += 5;
			int end = base64String.IndexOf(";", pos);
			if(end >= 0) {
				fileType = base64String.Substring(pos, end-pos);
				pos = end+1;
			}
		}
		for(int i=0;i<plainTextFileExtensions.Length;i++) {
			if(fileExtension == plainTextFileExtensions[i].ToLower()) fileType = "text/plain";
		}

		pos = base64String.IndexOf("base64,");
		if(pos >= 0) pos += 7;
		byte[] bytes = System.Convert.FromBase64String(base64String.Substring(pos));

		if(targetObject != null) {
			targetObject.BroadcastMessage("OnExternalDragFileName", fileName, SendMessageOptions.DontRequireReceiver);
			targetObject.BroadcastMessage("OnExternalDragFileExtension", fileExtension, SendMessageOptions.DontRequireReceiver);
		}
	    if(lastDragTarget != null) {
	    	lastDragTarget.BroadcastMessage("OnExternalDragFileName", fileName, SendMessageOptions.DontRequireReceiver);
	    	lastDragTarget.BroadcastMessage("OnExternalDragFileExtension", fileExtension, SendMessageOptions.DontRequireReceiver);
	    }

		if(fileType == "image/jpeg" || fileType == "image/png") {
			Texture2D tex = new Texture2D(1, 1);
			tex.LoadImage(bytes);
			if(targetObject != null) {
				targetObject.BroadcastMessage("OnExternalDragEnd", tex, SendMessageOptions.DontRequireReceiver);
			}
		    if(lastDragTarget != null) {
		    	lastDragTarget.BroadcastMessage("OnExternalDragEnd", tex, SendMessageOptions.DontRequireReceiver);
		    }
		} else if(fileType == "text/plain") {
			string fileContents = System.Text.Encoding.UTF8.GetString(bytes); 
			if(targetObject != null) {
				targetObject.BroadcastMessage("OnExternalDragEnd", fileContents, SendMessageOptions.DontRequireReceiver);
			}
		    if(lastDragTarget != null) {
		    	lastDragTarget.BroadcastMessage("OnExternalDragEnd", fileContents, SendMessageOptions.DontRequireReceiver);
		    }
		} else {
			if(targetObject != null) {
				targetObject.BroadcastMessage("OnExternalDragEnd", bytes, SendMessageOptions.DontRequireReceiver);
			}
		    if(lastDragTarget != null) {
		    	lastDragTarget.BroadcastMessage("OnExternalDragEnd", bytes, SendMessageOptions.DontRequireReceiver);
		    }
		}
		base64String = null;

		Debug.Log("received "+nrOfFilesReceived+" of "+nrOfFilesToExpect+" files");
		if(nrOfFilesReceived == nrOfFilesToExpect) {
			if(targetObject != null) {
				targetObject.BroadcastMessage("OnExternalDragAllFilesReceived", null, SendMessageOptions.DontRequireReceiver);
			}
		    if(lastDragTarget != null) {
		    	lastDragTarget.BroadcastMessage("OnExternalDragAllFilesReceived", null, SendMessageOptions.DontRequireReceiver);
		    	lastDragTarget = null;
		    }
		}

	}

	/* --------- Find object under cursor and broadcast DragOver ------------*/
	/* ----------------------------------------------------------------------*/
	private void BroadcastExternalDragOver(Vector3 screenPoint) {
		if(targetObject != null) {
			targetObject.BroadcastMessage("OnExternalDragOver", screenPoint, SendMessageOptions.DontRequireReceiver);
		}
		if(targetObjectUnderCursor) {
	        Ray ray = Camera.main.ScreenPointToRay(screenPoint);
	        RaycastHit hit;
		    if (Physics.Raycast(ray, out hit, 1000f)) {
	    	    GameObject gameObjectUnderCursor = hit.transform.gameObject;
	    	    if(lastDragTarget != null && gameObjectUnderCursor != lastDragTarget) {
	    	    	lastDragTarget.BroadcastMessage("OnExternalDragCancel", SendMessageOptions.DontRequireReceiver);
	    	    }
	    	    gameObjectUnderCursor.BroadcastMessage("OnExternalDragOver", screenPoint, SendMessageOptions.DontRequireReceiver);
	    	    lastDragTarget = gameObjectUnderCursor;
	    	} else {
	    	    if(lastDragTarget != null) {
	    	    	lastDragTarget.BroadcastMessage("OnExternalDragCancel", screenPoint, SendMessageOptions.DontRequireReceiver);
	    	    }
	    	}
	    }
	}


	private float FloatFromString(string aStr) {
		float parsedFloat = 0.0f;
        if (aStr!=null && float.TryParse(aStr, out parsedFloat)) return parsedFloat;
        else return 0.0f;
	}

}
