using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeatroyObj : MonoBehaviour {
	public int scoreValue;  // これが敵を倒すと得られる点数になる
	private ScoreManager sm;

	// ★追加
	void Start(){

		// 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
		sm = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();
	}
	// このメソッドはぶつかった瞬間に呼び出される
	void OnTriggerEnter(Collider other){

		// もしもぶつかった相手のTagにShellという名前が書いてあったならば（条件）
		if(other.CompareTag("Bullet")){

			// このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
			Destroy(this.gameObject);

			// ぶつかってきたオブジェクトを破壊する
			Destroy(other.gameObject);

			sm.AddScore(scoreValue);
		}
	}
}
