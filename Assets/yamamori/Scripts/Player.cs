using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//[SerializeField]
	public Bullet bullet;
	
	public AudioClip audioClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// enter key
		if (Input.GetKeyDown(KeyCode.Space)) {
			this.shot(0);
		}else if(Input.GetKeyDown(KeyCode.N)){
			this.shot(1);
		}
		
		// -- ref ------
		//Instantiate(Resources.Load("Bullet"), transform.position, transform.rotation);
		//var go = new GameObject("bullet");
		//var b = go.AddComponent<Bullet>();
		//b.Init();
	}
	
	private void shot(int shotType){
	    var b = Instantiate(bullet, transform.position, transform.rotation) as Bullet;
		b.Init(this.gameObject.transform.forward, shotType);
		
		AudioSource.PlayClipAtPoint(audioClip,new Vector3(0,0,0));
	}

}
