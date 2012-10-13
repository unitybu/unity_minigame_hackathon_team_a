using UnityEngine;
using System.Collections;

public class NewEnemy : MonoBehaviour {
	
	public GameObject enemy;
	private int cnt=0;
	// Use this for initialization
	void Start () {
		makeNewEnemy();
	}
	
	void makeNewEnemy(){

		transform.position.Set (transform.position.x + cnt++,transform.position.y+cnt++,transform.position.z);
		var b = Instantiate(enemy, transform.position, transform.rotation) as GameObject;		
	}
	
	// Update is called once per frame
	void Update () {
		float timer=0;
		timer += Time.deltaTime;
	    if (timer > 5) { // 5秒毎に以下を実行。
	        timer = 0;
			print("Time=" + Time.time);
			makeNewEnemy();
	    }
	}
	
}
