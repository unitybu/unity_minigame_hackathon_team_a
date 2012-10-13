using UnityEngine;
using System.Collections;

//これ、ゲームマスターとかクラスになってるけど、現状時計管理しかしてないです。.
public class GameMaster : MonoBehaviour
{
	[SerializeField]
	private float TIME_MAX = 30;//時間制限の最大値.
	bool isActive = true;//時計を動かすかどうか.
	
	static bool instance = false;//既に自分が居たら作らないようにするためのフラグ.
	
	[SerializeField]
	private GUIText dispTime;//時間の表示用GUIText.
	
	// Use this for initialization
	void Awake ()
	{
		if(!instance)
		{
			//次のシーンでも消えないようにする.
			DontDestroyOnLoad(this.gameObject);
			instance = true;
			Init();
		}
		else
		{
			//既に自分が居たら削除する。.
			Destroy(this.gameObject);
		}		
	}
	
	void OnLevelWasLoaded()
	{
		Init();
	}	
	
	// Update is called once per frame
	void Update ()
	{
		if(!isActive) return;
		
		//残り時間を計測する。.
		float time = TIME_MAX - Time.timeSinceLevelLoad;
		
		if(time < 0)
		{
			time = 0;
			//次のシーンへ.
			SceneChange.Next();
		}
		
		//表示時間を更新.
		dispTime.text = string.Format("Time :{0:00.00}",time);
	}
	
	void Init()
	{
		if(Application.loadedLevelName == "Title" || Application.loadedLevelName == "Result")
		{
			//タイトルとリザルトでは時計を表示しない。.
			isActive = false;
			dispTime.enabled = false;
		}
		else
		{
			//それ以外なら時計を表示、更新もする。.
			isActive = true;
			dispTime.enabled = true;				
			dispTime.text = string.Format("Time :{0:00.00}",TIME_MAX);
		}
	}
}
