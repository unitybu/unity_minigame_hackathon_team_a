using UnityEngine;
using System.Collections;

//将来的にはここにフェードを追加する予定。

public class SceneChange : MonoBehaviour
{
	static public void Next()
	{
		//次のシーン番号を計算
		int nextLevel = (Application.loadedLevel+1) % Application.levelCount;
		
		print("NextScene=>"+nextLevel);
		//次のシーンへ移動する
		Application.LoadLevel(nextLevel);
	}
}
