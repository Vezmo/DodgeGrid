using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : View {

	// Update is called once per frame
	void Update () {
		
	}

  public void UI_OnBackToGameButtonPressed()
  {
    ViewManager.Instance.SetActiveView(ViewManager.Instance.GameView);
  }
}
