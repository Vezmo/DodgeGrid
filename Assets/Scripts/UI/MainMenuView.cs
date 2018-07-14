using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuView : View {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  public void UI_OnPlayButtonPressed()
  {
    ViewManager.Instance.SetActiveView(ViewManager.Instance.GameView);
  }
}
