using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private static int cnt;
	
	private float speed = 10.0f;
	private Vector3 forward;
	private GameObject tEnemy = null;
	private float tDistance = 100.0f;
	private float degToRad = Mathf.PI / 180;
	private int shotType = 0;
	
	// Use this for initialization
	void Start () {
		
		// set to destroy timing
		Destroy(this.gameObject, 3);
		
		// check target
		GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
		foreach(GameObject enemy in enemys){
			float distance = Vector3.Distance(this.transform.position, enemy.transform.position);
			print("distance : " + distance);
			if(distance < tDistance){
				tDistance = distance;
				tEnemy = enemy;
			}
		}
		print ("enemy name : " + tEnemy.name);
	}
	
	// Update is called once per frame
	void Update () {

		//  shot
		if(this.shotType == 0 && tEnemy != null && 1.0f < tDistance){
			// homing1

			// angle
			Vector3 angle = tEnemy.transform.position;
			angle.y = this.transform.position.y;	// y is fixed
			this.transform.LookAt(angle);
			float angleForTarget = transform.eulerAngles.y;
			
			// vector
			float x = Mathf.Sin(angleForTarget * degToRad) * Time.deltaTime;
			float z = Mathf.Cos(angleForTarget * degToRad) * Time.deltaTime;
			Vector3 moveVector = new Vector3(x, 0, z);
			this.transform.position += moveVector * speed;
			
		}else{
			// straight
			this.transform.position += this.forward * speed / 10;
		}
		
	}
	
	public void Init(Vector3 forward, int shotType) {
		print ("bullet init");
		this.gameObject.name = "bullet" + cnt++;
		this.forward = forward;
		this.shotType = shotType;
		this.transform.position += forward;
	}
}
