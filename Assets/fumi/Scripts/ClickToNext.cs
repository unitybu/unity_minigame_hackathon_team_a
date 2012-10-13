using UnityEngine;
using System.Collections;

public class ClickToNext : MonoBehaviour
{
	void Update()
	{
		//スペースキーが押されたら.
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//次のシーンへ移動する。.
			SceneChange.Next();
		}
	}
}
