using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	//得点
	private int score;

	//得点表示用
	private GameObject scoreText;

	private int smallStarPoint = 1;
	private int largeStarPoint = 10;
	private int smallCloudPoint = 100;
	private int largeCloudPoint = 1000;

	// Use this for initialization
	void Start () {
		this.score = 0;
		this.scoreText = GameObject.Find("ScoreText");
		this.scoreText.GetComponent<Text> ().text = this.score.ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}

	//衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other) {
		
		if(other.gameObject.tag == "SmallStarTag"){
			score = score + this.smallStarPoint;
		}

		if(other.gameObject.tag == "LargeStarTag"){
			score = score + this.largeStarPoint;
		}

		if(other.gameObject.tag == "SmallCloudTag"){
			score = score + this.smallCloudPoint;
		}

		if(other.gameObject.tag == "LargeCloudTag"){
			score = score + this.largeCloudPoint;
		}

		this.scoreText.GetComponent<Text> ().text = this.score.ToString();
    }
}

