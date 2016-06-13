using UnityEngine;
using System.Collections;

enum Steps { FIRST, SECOND, THIRD, FOURTH, FIFTH, SIXTH, SEVENTH }

public class TutorialControl : MonoBehaviour {
    public GameObject player;
    public GameObject tutorialMsg1;
    public GameObject tutorialMsg2;
    public GameObject tutorialMsg3;
    public GameObject tutorialMsg4;

    public Transform[] points;
    public GameObject tutorialPoint;
    //public GameObject[] tutorialPoints;

    private GameObject _point;
    private int _countPoint = 0;

    private Steps _step;
    private GameObject _canvas;

    private static TutorialControl _instance = null;
    public static TutorialControl Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        this._step = Steps.FIRST;
        GetInstance();
    }

    void Update()
    {
        Debug.Log(this._step);
        switch (this._step)
        {
            case Steps.FIRST:
                if (_canvas == null)
                {
                    _canvas = (GameObject)Instantiate(tutorialMsg1);
                }
                break;
            case Steps.SECOND:
                if (_canvas == null)
                {
                    _canvas = (GameObject)Instantiate(tutorialMsg2);
                }
                break;
            case Steps.THIRD:
                if (_canvas == null)
                {
                    _canvas = (GameObject)Instantiate(tutorialMsg3);
                    GameManager.Instance.PausePlay();
                }

                if(!this.player.activeSelf)
                    this.player.SetActive(true);
                break;
            case Steps.FOURTH:
                GameManager.Instance.PausePlay();
                this.ChangeSteps();
                break;
            case Steps.FIFTH:
                if(this._countPoint == 5 && this._point == null)
                {
                    this.ChangeSteps();
                    break;
                }

                if(this._point == null)
                {
                    this._point = (GameObject)Instantiate(this.tutorialPoint, this.points[this._countPoint].position, Quaternion.identity);
                    this._point.gameObject.SetActive(true);
                    this._countPoint++;
                }
                break;
            case Steps.SIXTH:
                
                if (_canvas == null)
                {
                    _canvas = (GameObject)Instantiate(tutorialMsg4);
                    GameManager.Instance.PausePlay();
                }
                break;
            case Steps.SEVENTH:
                GameManager.Instance.FinishTutorial();
                GameManager.Instance.PausePlay();
                GameManager.Instance.LoadWorld();
                break;
        }
    }

    private void GetInstance()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void ChangeSteps() {
        int currentStep = (int) this._step;
        currentStep++;
        this._step = (Steps) currentStep;
    }
}
