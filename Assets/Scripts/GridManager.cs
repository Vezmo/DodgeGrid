using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

  public static GridManager Instance { get { return m_instance; } }
  private static GridManager m_instance;

  public void OnAwake()
  {
    if (m_instance != this)
      m_instance = this;

    PopulateNodeGrid();
  }

  //Probably serializable
  private Dictionary<Vector2, Node> m_nodeGrid = new Dictionary<Vector2, Node>();

  public void PopulateNodeGrid()
  {
    Node[] nodes = FindObjectsOfType<Node>();

    for (int i = 0; i < nodes.Length; i++)
    {
      int x = (int)nodes[i].Position.x;
      int y = (int)nodes[i].Position.y;
      Vector2 key = new Vector2(x, y);

      m_nodeGrid[key] = nodes[i];
    }
  }

  public Node GetNeighborNode(Node _currentNode, Vector2 _direction)
  {
    int currentX = (int)_currentNode.Position.x;
    int currentY = (int)_currentNode.Position.y;
    Vector2 potentialKey = new Vector2(currentX + _direction.x, currentY + _direction.y);
    Node potentialTargetNode = null;

    if (m_nodeGrid.ContainsKey(potentialKey) || m_nodeGrid[potentialKey].Accessible)
      potentialTargetNode = m_nodeGrid[potentialKey];

    return potentialTargetNode;
  }

  private bool isOutOfBounds(Vector2 _potentialNodePosition)
  {
    bool isOutOfBouds = false;

    if (!m_nodeGrid.ContainsKey(_potentialNodePosition) || !m_nodeGrid[_potentialNodePosition].Accessible)
      isOutOfBouds = true;

    return isOutOfBouds;
  }

}
