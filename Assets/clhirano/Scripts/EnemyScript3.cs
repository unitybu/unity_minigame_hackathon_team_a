using UnityEngine;
using System.Collections;

/**
 * This is a class of yellow enemy
 */
public class EnemyScript3 : EnemyScript {
	private Vector3 mEndPoint;
	private float mDuration = 1.0f;
	private Vector3 mStartPoint;
	private float mStartTime;
	
	// Use this for initialization
	void Start () {
		// set the score
		SetScore(SCORE_FIVE);
		
		// record the position
		mStartPoint = transform.position;
		// record the time
		mStartTime = Time.time;
	}
	
	void Update() {
		// update the location of enemy object
		transform.position = Vector3.Lerp(mStartPoint, mEndPoint, (Time.time -mStartTime) / mDuration);
		
		if(transform.position.x<=0 || transform.position.z <=0) {
			// vanish
			Destroy(this.gameObject);
		}
	}
}
