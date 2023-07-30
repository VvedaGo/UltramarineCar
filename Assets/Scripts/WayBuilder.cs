using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WayBuilder:MonoBehaviour
{
    [SerializeField] private BaseTile _startTile;
    [SerializeField] private BaseTile[] Tile;

    private Vector2Int _sizeTile=new Vector2Int(20,20);
    private Vector2Int CurrentDirection=new Vector2Int(0,-1);
    private Vector2Int CurrentPositionTile=new Vector2Int(30,50);
    private List<Vector2Int> directionsTiles;
    private BaseTile _lastTile;
    private void Start()
    {
        _lastTile = _startTile;
        SpawnFirstObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnFirstObject();
        }
    }

    private void SpawnFirstObject()
    {
        BaseTile nextTile = GetNextTile();
        nextTile.transform.position = (Vector2)NextTilePosition();
        RotateNextTile(nextTile);
        Vector2Int bias =  BiasNextTile(nextTile);
        Vector2 nextPosition= nextTile.transform.position + (Vector3)(Vector2)bias;
        CurrentPositionTile += bias;
        nextTile.transform.position = nextPosition;
        _lastTile = nextTile;
        CurrentDirection = _lastTile.Finish.SideTile.DirectionBySide();
    }

    private void RotateNextTile(BaseTile tile)
    {
        while (tile.Start.SideTile != _lastTile.Finish.SideTile.GetInvertSide())
        {
            tile.RotateTile(new Vector3(0,0,-90));
        }
    }

    private Vector2Int NextTilePosition()
    {
        return CurrentPositionTile += (_sizeTile * CurrentDirection);
    }

    private Vector2Int BiasNextTile(BaseTile tile)
    {
        Vector2Int courdinateToMove;
        int changeDirection=1;
        if (tile.Start.SideTile == Enums.SideTile.Up || tile.Start.SideTile == Enums.SideTile.Down)
        {
            courdinateToMove=new Vector2Int(1,0);
        }
        else
        {
            courdinateToMove=new Vector2Int(0,1);
        }

        if (CurrentDirection==new Vector2Int(0,1)||CurrentDirection==new Vector2Int(-1,0))
            changeDirection = -1;

                int bias = ((int)_lastTile.Finish.NumberOfWay.GetInvertNumberOfWay() - (int)tile.Start.NumberOfWay)*5*changeDirection;
        return courdinateToMove * bias;

    }
    private BaseTile GetNextTile()
    {
        var til = Instantiate(Tile[Random.Range(0, Tile.Length)]);
        return til ;
    }
}