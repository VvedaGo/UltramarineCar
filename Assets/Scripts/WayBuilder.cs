using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WayBuilder:MonoBehaviour
{
    [SerializeField] private BaseTile _startTile;
    [SerializeField] private BaseTile[] Tile;

    private Vector3 _sizeTile=new Vector3(80,0,80);
    private Vector3 CurrentDirection=new Vector3(1,0,0);
    private Vector3 CurrentPositionTile=new Vector3(0,0,0);
    private List<Vector2Int> directionsTiles;
    private BaseTile _lastTile;
    [SerializeField] private Car _car;
    public Queue<BaseTile> tileOnMap;
    private void Start()
    {
        tileOnMap=new Queue<BaseTile>();
        tileOnMap.Enqueue(_startTile);
        _lastTile = _startTile;
        SpawnFirstObject();
        SpawnFirstObject();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnFirstObject();
        }
    }

    private bool first = false;
    public void EndTile()
    {
        if (first)
        {
            SpawnFirstObject();
        }
        if (!first)
            first = true;
    }

    private void SpawnFirstObject()
    {
        BaseTile nextTile = GetNextTile();
        nextTile.transform.position =NextTilePosition();
        RotateNextTile(nextTile);
        Vector3 bias =  BiasNextTile(nextTile);
        Vector3 nextPosition= nextTile.transform.position +bias;
        CurrentPositionTile += bias;
        nextTile.transform.position = nextPosition;
        _lastTile = nextTile;
        CurrentDirection = _lastTile.Finish.SideTile.DirectionBySide();
        tileOnMap.Enqueue(_lastTile);
        if (tileOnMap.Count > 3)
        {
          var tile=  tileOnMap.Dequeue();
          Destroy(tile.gameObject);
        }
    }

    private void RotateNextTile(BaseTile tile)
    {
        while (tile.Start.SideTile != _lastTile.Finish.SideTile.GetInvertSide())
        {
            tile.RotateTile(new Vector3(0,90,0));
        }
    }

    private Vector3 NextTilePosition()
    {
        Debug.Log(CurrentDirection);
        return CurrentPositionTile +=
            new Vector3(_sizeTile.x * CurrentDirection.x, 0, _sizeTile.z * CurrentDirection.z);
    }

    private Vector3 BiasNextTile(BaseTile tile)
    {
        Vector3 courdinateToMove;
        int changeDirection=1;
        if (tile.Start.SideTile == Enums.SideTile.Up || tile.Start.SideTile == Enums.SideTile.Down)
        {
            courdinateToMove=new Vector3(1,0);
        }
        else
        {
            courdinateToMove=new Vector3(0,0,1);
        }

        if (CurrentDirection==new Vector3(0,0,1)||CurrentDirection==new Vector3(-1,0,0))
            changeDirection = -1;

                int bias = ((int)_lastTile.Finish.NumberOfWay.GetInvertNumberOfWay() - (int)tile.Start.NumberOfWay)*20*changeDirection;
        return courdinateToMove * bias;

    }
    private BaseTile GetNextTile()
    {
        var til = Instantiate(Tile[Random.Range(0, Tile.Length)]);
        return til ;
    }
}