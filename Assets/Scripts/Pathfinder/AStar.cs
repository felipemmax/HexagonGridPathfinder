using System.Collections.Generic;
using HexagonGridPathfinder.Pathfinder.Interfaces;
using UnityEngine;

namespace HexagonGridPathfinder.Pathfinder
{
    public class AStar : IPathFinder
    {
        private class Node
        {
            public ICell Cell { get; }
            public Node Parent { get; set; }
            public float CostFromStart { get; set; }
            private float EstimateCostToEnd { get; }
            public float TotalCost => CostFromStart + EstimateCostToEnd;

            public Node(ICell cell, Node parent, float costFromStart, float estimateCostToEnd)
            {
                Cell = cell;
                Parent = parent;
                CostFromStart = costFromStart;
                EstimateCostToEnd = estimateCostToEnd;
            }
        }

        public IList<ICell> FindPathOnMap(ICell cellStart, ICell cellEnd, IMap map)
        {
            List<Node> openList = new() { new Node(cellStart, null, 0, GetHeuristic(cellStart, cellEnd)) };
            HashSet<ICell> closedList = new();

            while (openList.Count > 0)
            {
                openList.Sort((nodeA, nodeB) => nodeA.TotalCost.CompareTo(nodeB.TotalCost));
                Node currentNode = openList[0];
                openList.RemoveAt(0);

                if (currentNode.Cell.GridPosition == cellEnd.GridPosition)
                    return RetracePath(currentNode);

                closedList.Add(currentNode.Cell);

                foreach (ICell neighbor in map.GetNeighbors(currentNode.Cell))
                {
                    if (!neighbor.IsWalkable || closedList.Contains(neighbor))
                        continue;

                    float currentNodeCostFromStart = currentNode.CostFromStart + GetDistance(currentNode.Cell, neighbor);
                    Node existingNode = openList.Find(node => node.Cell == neighbor);

                    if (existingNode == null)
                    {
                        float heuristicCost = GetHeuristic(neighbor, cellEnd);
                        openList.Add(new Node(neighbor, currentNode, currentNodeCostFromStart, heuristicCost));
                    }
                    else if (currentNodeCostFromStart < existingNode.CostFromStart)
                    {
                        existingNode.Parent = currentNode;
                        existingNode.CostFromStart = currentNodeCostFromStart;
                    }
                }
            }

            return null; 
        }

        private static IList<ICell> RetracePath(Node endNode)
        {
            List<ICell> path = new();
            Node currentNode = endNode;

            while (currentNode != null)
            {
                path.Add(currentNode.Cell);
                currentNode = currentNode.Parent;
            }

            path.Reverse();
            return path;
        }

        private static float GetHeuristic(ICell selectedCell, ICell targetedCell)
        {
            return (selectedCell.GridPosition.x - targetedCell.GridPosition.x) +
                   (selectedCell.GridPosition.y - targetedCell.GridPosition.y);
        }

        private static float GetDistance(ICell selectedCell, ICell targetedCell)
        {
            return Vector2Int.Distance(selectedCell.GridPosition, targetedCell.GridPosition);
        }
    }
}
