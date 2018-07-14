using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameView : View {


  private State m_currentState;


  public override void OnActivate()
  {
    base.OnActivate();
    SetCurrentState(State.BeforeGame);

  }


  // Update is called once per frame
  void Update ()
  {
		switch (m_currentState)
    {
      case State.BeforeGame:
        if (Input.GetMouseButton(0))
        {
        }
        break;

      case State.InGame:
        if (Input.GetMouseButton(0))
        {
        }

        break;

      case State.AfterGame:
        if (Input.GetMouseButton(0))
        {
        }
        break;

    }
	}

  public void UI_OnBackToMainMenuButtonPressed()
  {
    ViewManager.Instance.SetActiveView(ViewManager.Instance.MainMenuView);
  }

  public void UI_OnShopButtonPressed()
  {
    ViewManager.Instance.SetActiveView(ViewManager.Instance.ShopView);
  }

  private void SetCurrentState(State _state)
  {
    m_currentState = _state;
  }

  private void TransitionToInGame()
  {

  }

  private enum State
  {
    BeforeGame = 1,
    InGame = 2,
    AfterGame = 3
  }
}
