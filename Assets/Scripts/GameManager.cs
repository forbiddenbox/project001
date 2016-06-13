using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {
	private int _level = 0;
	private int _world = 0;
    private bool _isPlaying = true;

	private static GameManager _instance = null;
	public static GameManager Instance 
	{
		get{ return _instance;}
	}

	void Awake (){
		GetInstance ();
        //DELETE THIS
        this.SetPreferences("Tutorial", -1);
	}

	void Start(){
		this._world = this.GetPreferences("world");

		if(this._world == -1){
			this._world = 1;
			this._level = 1;
			this.SetPreferences("world", 1);
			this.SetPreferences("level", 1);
		} else {
			this._level = this.GetPreferences("level");
		}
	}

	private void GetInstance (){
		if(_instance == null){
			_instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
	}

    public bool IsTutorial()
    {
        if(this.GetPreferences("Tutorial") == -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void FinishTutorial()
    {
        this.SetPreferences("Tutorial", 1);
    }

	public void SetPreferences(string key, int value){
		PlayerPrefs.SetInt(key, value);
	}

	public int GetPreferences(string key){
		return PlayerPrefs.GetInt(key, -1);
	}

	public void LoadWorld(){
        if (!this.IsTutorial())
        {
            string worldName = this._world.ToString().PadLeft(2, '0');
            SceneManager.LoadScene(worldName);
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }		
	}

	public void LoadLevel(int value){
		if(value <= this._level){
			string worldName = this._world.ToString().PadLeft(2, '0');
			string levelName = worldName + value.ToString().PadLeft(2, '0');
			SceneManager.LoadScene(levelName);
		}
	}

	public int GetWorld(){
		return this._world;
	}

	public int GetLevel(){
		return this._level;
	}

    public bool IsPlaying()
    {
        return this._isPlaying;
    }

    public void PausePlay()
    {
        Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
        this._isPlaying = (this._isPlaying) ? false : true;
    }
}
