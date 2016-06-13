using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine.UI;

public class WorldButtonsControl : MonoBehaviour {
	void Start(){
		
		foreach (Transform child in transform){
			/////// NEED TO CHECK THE WORLD AS WELL ///////
			int buttonValue = Int32.Parse(child.name);
			int currentLevel = GameManager.Instance.GetLevel ();

			if (buttonValue > currentLevel) {
				child.GetComponent<Button> ().interactable = false;
			}
		}
	}

    public void LoadLevel(int level)
    {
        GameManager.Instance.LoadLevel(level);
    }
}
