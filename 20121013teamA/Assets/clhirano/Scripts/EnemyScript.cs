using UnityEngine;
using System.Collections;

/**
 * This is a parent class of enemy
 */
public class EnemyScript : MonoBehaviour {
	// score 1pt
	protected static int SCORE_ONE = 1;
	// score 2pt
	protected static int SCORE_TWO = 2;
	// score 5pt
	protected static int SCORE_FIVE = 5;
	// the enemy's score
	private int mScore = 0;
	
	[SerializeField]
	private AudioClip audioClip;
	
	[SerializeField]
	private GameObject bulletExplosionEffect;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// OnTriggerEnter is called when the Collider other enters the trigger
	void OnTriggerEnter(Collider collider) {
		// check the collider's tag 
		if(collider.gameObject.tag=="Bullet") {
			// if the collider's tag is type of "Bullet"
			print("the bullet hits to "+this.gameObject.name);
			
			// add to the total score
			Score.Add(mScore);
			
			//bullet effect
			Instantiate(bulletExplosionEffect,this.gameObject.transform.position,this.gameObject.transform.rotation);
			
			Destroy(collider.gameObject);
			
			//ring sound
			AudioSource.PlayClipAtPoint(audioClip,new Vector3(0,0,0));
			
			// destroy this enemy object
			Destroy(this.gameObject);
		}
	}
	
	/**
	 * Set the enemy's score
	 * @params scoreInt the score
	 */
	protected void SetScore(int scoreInt) {
		mScore = scoreInt;
	}
}
