using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
  public static ControlManager Instance { get { return m_instance; } }
  private static ControlManager m_instance;

  public void OnAwake()
  {
    if (m_instance != this)
      m_instance = this;
  }

  public Player Player;

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
      Player.Move(InputDirectionType.Left);
    }
    else if (Input.GetKeyDown(KeyCode.RightArrow))
    {
      Player.Move(InputDirectionType.Right);
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow))
    {
      Player.Move(InputDirectionType.Down);
    }
    else if (Input.GetKeyDown(KeyCode.UpArrow))
    {
      Player.Move(InputDirectionType.Up);
    }
  }

}
