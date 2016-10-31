using UnityEngine;
using System.Collections;

public class hitObjSender : MonoBehaviour {
	GameObject parentObj;
	// Use this for initialization
	void Start () {
		parentObj = GameObject.Find ("script");
	}
	
	void OnTriggerEnter(Collider collider)
	{
		Debug.Log (collider.tag);
		parentObj.SendMessage("RedirectedOnTriggerEnter", collider);
	}
}
