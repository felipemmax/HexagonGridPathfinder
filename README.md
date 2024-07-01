# Unity Hexagon Grid Pathfinding
This project presents a utility for handling pathfinding on a hexagonal grid in Unity. It uses A* algorithm, a popular choice for grid-based path finding which is highly suitable for games, especially strategy and turn-based games.

## Core Elements
To work with hexagonal grids, we introduced the following elements:

- `ICell`: A cell in the hexagonal grid. It has a grid position (`GridPosition`) and a property indicating if it can be walked on (`IsWalkable`).

- `IMap`: A map of cells. Each ICell is placed according to `GridPosition` in `HexMap` that implements `IMap`. It allows fetching a cell by its position and getting its neighbours.

- `IPathFinder`: Interface defining a pathfinder. A pathfinder should be able to find a path between two cells on a given map. This implemented by `AStar` in our case.

- `MapController`: A class that sets up a hexagon grid map and coroutine for finding path between selected cells.
   
### Built With
   Unity 2022.3.35f1 and C# 9.0 using .NETFramework,Version=v4.7.1.
