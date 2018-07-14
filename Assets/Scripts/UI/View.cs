using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
	}


  public virtual void OnActivate()
  {
    gameObject.SetActive(true);
  }

  public virtual void OnDeactivate()
  {
    gameObject.SetActive(false);
  }
}
