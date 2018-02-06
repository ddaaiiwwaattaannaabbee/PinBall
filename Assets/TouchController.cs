using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
	//画面中央線
	private int CenterLine;
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoint;
	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//画面サイズ取得
		this.CenterLine = Screen.width/2;

		//HingeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		this.SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {

		//タッチ数を取得
		foreach(Touch t in Input.touches){
		
			int id = t.fingerId;

			switch(t.phase){
			
				case TouchPhase.Began:
					//Debug.LogFormat("{0}:いまタッチした", id);
					this.flipFripper(t);
					break;

				case TouchPhase.Ended:
					//Debug.LogFormat("{0}:いま離された", id);
					this.returnFripper(t);
					break;

			}

		}
		
	}
	//フリッパーの傾きを設定
	private void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoint.spring = jointSpr;
	}

	//フリッパーを弾く
	private void flipFripper(Touch t){
		//画面左を押した時左フリッパーを動かす
		if ((t.position.x < this.CenterLine) && tag == "LeftFripperTag") {
		SetAngle (this.flickAngle);
		}
		//画面右を押した時右フリッパーを動かす
		if ((this.CenterLine < t.position.x) && tag == "RightFripperTag") {
		SetAngle (this.flickAngle);
		}
	}

	 //フリッパーを戻す
	 private void returnFripper(Touch t){
		//矢印キー離された時フリッパーを元に戻す
		if ((t.position.x < this.CenterLine) && tag == "LeftFripperTag") {
		SetAngle (this.defaultAngle);
		}
		if ((this.CenterLine < t.position.x) && tag == "RightFripperTag") {
		SetAngle (this.defaultAngle);
		}
	}
}
