using UnityEngine;
using System.Collections;

public class BulletEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(this.gameObject,2.5f);
	}
}
