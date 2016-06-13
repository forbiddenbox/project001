using UnityEngine;
using System.Collections;

public class CanvasControl : MonoBehaviour {
    public void Close()
    {
        Destroy(this.GetComponent<Canvas>().gameObject);

        if (GameManager.Instance.IsTutorial())
        {
            TutorialControl.Instance.ChangeSteps();
        }
    }
}
