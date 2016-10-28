using UnityEngine;
using System.Collections;
using UnityEngine.UI;//UIを使用するのに必要
using UnityEngine.SceneManagement;//シーン遷移をするのに必要

public class endScript : MonoBehaviour {

	int _mytime;

	[SerializeField, HeaderAttribute ("リザルト表示用テキストUI")]
	public Text result;
	[SerializeField, HeaderAttribute ("オープニングシーン名")]
	public string opSceneName;

	// Use this for initialization
	void Start () {
		_mytime = PlayerPrefs.GetInt ("mytime");
		result.text = "リザルト：" + _mytime.ToString () + "ポイント";
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goOp(){
		SceneManager.LoadScene (opSceneName);
	}
}
