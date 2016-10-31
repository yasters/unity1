using UnityEngine;
using System.Collections;
using UnityEngine.UI;//UIを使用するのに必要
using UnityEngine.SceneManagement;//シーン遷移をするのに必要

public class myQuest : MonoBehaviour {

	[SerializeField, HeaderAttribute ("経由地の数")]
	public int points;

	//sound
	[SerializeField, HeaderAttribute ("効果音をドロップ")]
	public AudioClip getSound;
	public AudioClip tickSE;


	//default time
	[SerializeField, HeaderAttribute ("カウントダウンの初期時間")]
	public int gameTime;
	[SerializeField, HeaderAttribute ("残時間のUItextをドロップ")]
	public Text timeText;
	[SerializeField, HeaderAttribute ("残りの経由地数表示UIをドロップ")]
	public Text nokoriText;

	[SerializeField, HeaderAttribute ("エンディングのシーン名を入力")]
	public string endSceneName;

	//audio source get from this script attached
	AudioSource myaudio;


	// Use this for initialization
	void Start () {

		myaudio =	GetComponent<AudioSource>();
		timeText.text = "残り時間" + gameTime.ToString () + "秒";
		nokoriText.text = "のこり" + points.ToString () + "個";
		//start after nSec
		Invoke("timeCount", 3.5f);

	
	}


	
	// Update is called once per frame
	void Update () {
	
	}



	//if hit destroy obj

	void RedirectedOnTriggerEnter(Collider mycollider) {
		//Debug.Log (mycollider.gameObject.tag);
		if (mycollider.gameObject.tag == "pointObj") {
			points--;
			nokoriText.text = "のこり" + points.ToString () + "個";
			myaudio.PlayOneShot (getSound, 0.7F);
			Destroy (mycollider.gameObject);

			if (points < 1) {
				//go end
				StopCoroutine("loop");
				Invoke("goEnd", 2f);
			}
		}
	}



	void timeCount(){
		StartCoroutine("loop");

	}


	private IEnumerator loop() {
		while (true) {
			gameTime--;//

			timeText.text = "残り時間" + gameTime.ToString () + "秒";
			myaudio.PlayOneShot(tickSE, 0.7F);
			yield return new WaitForSeconds (1f);
		}
	}


	void goEnd(){
		PlayerPrefs.SetInt ("mytime", gameTime);//save time
		SceneManager.LoadScene (endSceneName);//go end scene
	}



}
