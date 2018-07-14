using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

  public Node StartingNode;

  public AnimationCurve TranslationCurve;
  public float TranslationDuration;
  public LayerMask LayerMask;
  public Node m_currentNode;
  private Timer m_translationTimer;
  private Node m_currentMoveTargetNode;

  private bool m_isMoving;
  // Use this for initialization
  void Start()
  {
    m_currentNode = StartingNode;

    m_translationTimer = new Timer(TranslationDuration);
    m_translationTimer.OnComplete += MoveTimer_OnComplete;
  }



  // Update is called once per frame
  void Update()
  {
    m_translationTimer.Loop(Time.deltaTime);

    if (m_isMoving)
    {
      Translate();
    }
  }

  private void MoveTimer_OnComplete()
  {
    transform.position = m_currentNode.transform.position;
    m_isMoving = false;
  }


  private void DetectCurrentNode()
  {
    Collider2D[] nodes = Physics2D.OverlapBoxAll(transform.position, new Vector2(0.6f, 0.6f), 0, LayerMask);
    m_currentNode = MovementHelper.GetClosestNode(transform, nodes);
  }

  private void Translate()
  {
    DetectCurrentNode();
    transform.position = Vector3.Lerp(transform.position, m_currentMoveTargetNode.transform.position, TranslationCurve.Evaluate(m_translationTimer.GetNormalizedTime()));
  }

  public void Move(InputDirectionType _directionType)
  {
    m_currentMoveTargetNode = null;

    switch (_directionType)
    {
      case InputDirectionType.Left:
        m_currentMoveTargetNode = GridManager.Instance.GetNeighborNode(m_currentNode, Vector2.left);
        break;

      case InputDirectionType.Right:
        m_currentMoveTargetNode = GridManager.Instance.GetNeighborNode(m_currentNode, Vector2.right);
        break;

      case InputDirectionType.Down:
        m_currentMoveTargetNode = GridManager.Instance.GetNeighborNode(m_currentNode, Vector2.down);
        break;

      case InputDirectionType.Up:
        m_currentMoveTargetNode = GridManager.Instance.GetNeighborNode(m_currentNode, Vector2.up);
        break;
    }

    if (m_currentMoveTargetNode != null)
    {
      m_isMoving = true;
      m_translationTimer.Start();
    }
    else
    {
      //MOVE FAILED
    }
  }

}
