using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

	// bullet prefab
	public GameObject bullet;

	// 弾丸発射点
	public Transform muzzle;

	// 弾丸の速度
	public float speed = 1000;

	public int shotCount = 8;

	public Text BulletLabel;

	// Use this for initialization
	void Start () {
		// ★追加
			BulletLabel.text = "残り弾数：" + shotCount;
	}

	// Update is called once per frame
	void Update () {
		// 左クリックされた時
		if(Input.GetMouseButtonDown(0)){
			if(shotCount < 1){
				return;
			}
			// ★追加
			shotCount -= 1;

			// ★追加
			BulletLabel.text = "残り弾数：" + shotCount;
			// 弾丸の複製
			GameObject bullets = GameObject.Instantiate(bullet)as GameObject;

			Vector3 force;
			force = this.gameObject.transform.forward * speed;
			// Rigidbodyに力を加えて発射
			bullets.GetComponent<Rigidbody>().AddForce (force);
			// 弾丸の位置を調整
			bullets.transform.position = muzzle.position;
			bullets.transform.rotation = muzzle.rotation;
		}
	}
}