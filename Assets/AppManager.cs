using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {


  public ViewManager ViewManager;
  public GridManager GridManager;
  public ControlManager ControlManager;

  void Awake()
  {
    ViewManager.OnAwake();
    GridManager.OnAwake();
    ControlManager.OnAwake();
  }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
