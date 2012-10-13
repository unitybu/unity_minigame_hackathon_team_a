using UnityEngine;
using System.Collections;

public class Score :MonoBehaviour
{
	static int score; //現在のプレイのスコア.
	static int hiScore;//ハイスコア..
	 
	
	[SerializeField]//インスペクター上に表示する.
	private GUIText dispScore,dispHighScore;//スコアの表示用GUIText.
	
	const string RANKING_SAVE_NAME = "ranking";//保存用の名前のキー.
	static bool instance = false;//既に自分が居たら作らないようにするためのフラグ.
	static string scoreFormat = " : {0, 4} pts";//スコア表示のフォーマット.
	
	static bool isScoreUpdate = false;//スコアの更新をするかどうかのフラグ.
	
	void Awake()
	{
		if(!instance)
		{
			//ハイスコアの取得.
			hiScore = PlayerPrefs.GetInt(RANKING_SAVE_NAME,0);
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
	
	//シーン切替時に呼ばれる関数です。.
	void OnLevelWasLoaded()
	{
		Init();
	}
	
	void Init()
	{
		//タイトル画面なら.
		if(Application.loadedLevelName == "Title")
		{
			//スコアなど非表示に.
			dispScore.enabled = false;
			dispHighScore.enabled = false;
		}
		else if(Application.loadedLevelName == "Stage1")
		{
			//スコアだけ表示、場所を移動.
			dispScore.enabled = true;
			dispHighScore.enabled = false;			
			dispScore.transform.position = new Vector3(0.0f,1.0f,0);
			isScoreUpdate = true;
			score = 0;
		}
		else if(Application.loadedLevelName == "Result")
		{
			//ハイスコアも表示、場所を移動.
			dispScore.enabled = true;
			dispHighScore.enabled = true;				
			dispScore.text = string.Format("YourScore"+scoreFormat,score);
			dispHighScore.text = string.Format("HighScore"+scoreFormat,hiScore);
			
			dispScore.transform.position = new Vector3(0.25f,0.6f,0);
			dispHighScore.transform.position = new Vector3(0.25f,0.45f,0);
			
			//スコアを更新していたら.
			if(score > hiScore)
			{
				hiScore = score;
				//ハイスコアを保存。.
				PlayerPrefs.SetInt (RANKING_SAVE_NAME,hiScore);
				dispHighScore.text = string.Format("HighScore"+scoreFormat,hiScore);
				dispHighScore.text += "<= new!!";
			}
		}		
	}
	
	void Update()
	{
		if(!isScoreUpdate) return;
		
		//スコアが更新していたらテキストを更新.
		isScoreUpdate = false;
		dispScore.text = string.Format("Score"+scoreFormat,score);
	}
	
	public static void Add(int s)
	{
		//スコアの追加.
		score += s;
		//スコア更新フラグを立てる.
		isScoreUpdate = true;
	}
}
