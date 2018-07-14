using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MovementHelper
{
  public static Node GetClosestNode(Transform _playerTransform, Collider2D[] _nodes)
  {
    float minDistance = 100;
    Node potentialCurrentNode = null;

    for (int i = 0; i < _nodes.Length; i++)
    {
      float distance = Vector2.Distance(_playerTransform.position, _nodes[i].transform.position);

      if (distance <= minDistance)
      {
        minDistance = distance;
        potentialCurrentNode = _nodes[i].GetComponent<Node>();
      }
    }

    return potentialCurrentNode;
  }

}
