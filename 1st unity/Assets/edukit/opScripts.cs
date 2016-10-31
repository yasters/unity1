using UnityEngine;
using System.Collections;
using UnityEngine.UI;//UIを使用するのに必要
using UnityEngine.SceneManagement;//シーン遷移をするのに必要

public class opScripts : MonoBehaviour {
	[SerializeField, HeaderAttribute ("メインシーン名")]
	public string mainSceneName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void goMain(){
		SceneManager.LoadScene (mainSceneName);
	}
}
