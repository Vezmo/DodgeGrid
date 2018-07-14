using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : View
{
  public static ViewManager Instance { get { return m_instance; } }
  private static ViewManager m_instance;

  public View StartingView;

  public MainMenuView MainMenuView;
  public GameView GameView;
  public ShopView ShopView;

  public View[] Views;

  private View m_currentView;


  public void OnAwake()
  {
    if (m_instance != this)
    {
      m_instance = this;
    }

    SetActiveView(MainMenuView);

  }

  public void DeactivateAllViews()
  {
    for (int i = 0; i < Views.Length; i++)
    {
      Views[i].OnDeactivate();
    }
  }

  public void DeactivateAllViewsExcept(View _view)
  {
    for (int i = 0; i < Views.Length; i++)
    {
      if (_view != Views[i])
        Views[i].OnDeactivate();
    }
  }

  public void SetActiveView(View _view)
  {
    DeactivateAllViewsExcept(_view);
    _view.OnActivate();
    m_currentView = _view;
  }
}
