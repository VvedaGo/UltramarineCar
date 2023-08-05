using System.Collections.Generic;
using Game.Road;
using Infrastructure.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class WayBuilder 
    {
        /*[SerializeField] private BaseTile _startTile;
        [SerializeField] private BaseTile[] _tile;
        [SerializeField]*/
        private Car.Car _car;
        private readonly Vector3 _sizeTile = new Vector3(80, 0, 80);
        private readonly Vector3 _sizeFirstTile = new Vector3(80, 0, 10);
       
        private Vector3 _currentDirection = new Vector3(0, 0, -1);
        private Vector3 _currentPositionTile = new Vector3(0, 0, 0);
        
        private List<Vector2Int> _directionsTiles;
        private BaseTile _lastTile;
        private Queue<BaseTile> _tileOnMap;
        private GameFactory _gameFactory;
        
        private bool _first = false;


        /*private void Start()
        {
            _tileOnMap = new Queue<BaseTile>();
            _tileOnMap.Enqueue(_startTile);
            _lastTile = _startTile;
            SpawnNextTile();
            SpawnNextTile();
        }*/

        public WayBuilder(GameFactory gameFactory, Car.Car car)
        {
            _gameFactory = gameFactory;
            _car = car;
            _tileOnMap = new Queue<BaseTile>();
           
        }

        public void SpawnStartTile()
        {
            var tile= _gameFactory.SpawnStartTile();
            Debug.Log(tile.transform.position);
            tile.transform.position=Vector3.zero;
            var baseTile = tile as StartBaseTile;
            _car.transform.position = baseTile.SpawnPosition.position;
            AddNewTile(tile);
        }

        public void SpawnFirstTiles()
        {
            SpawnNextTile(StartNextPosition());
            SpawnNextTile(NextTilePosition());
        }


        public void EndTile()
        {
            if (_first)
            {
                SpawnNextTile(NextTilePosition());
            }

            if (!_first)
                _first = true;
        }

        private Vector3 StartNextPosition()
        {
           return _currentPositionTile +=
            new Vector3(_sizeFirstTile.x * _currentDirection.x, 0, (_sizeFirstTile.z/2+_sizeTile.z/2) * _currentDirection.z);
        }
        private void SpawnNextTile(Vector3 position)
        {
            Debug.Log(position);
            BaseTile nextTile = GetNextTile();
            nextTile.transform.position = position;
            RotateNextTile(nextTile);
            Vector3 bias = BiasNextTile(nextTile);
            Vector3 nextPosition = nextTile.transform.position + bias;
            _currentPositionTile += bias;
            nextTile.transform.position = nextPosition;
            _currentDirection = nextTile.Finish.SideTile.DirectionBySide();
            AddNewTile(nextTile);
        }

        private void AddNewTile(BaseTile nextTile)
        {
            _lastTile = nextTile;
            _tileOnMap.Enqueue(_lastTile);
            if (_tileOnMap.Count > 3)
            {
                var tile = _tileOnMap.Dequeue();
                Object.Destroy(tile.gameObject);
            }
        }

        private void RotateNextTile(BaseTile tile)
        {
            while (tile.Start.SideTile != _lastTile.Finish.SideTile.GetInvertSide())
            {
                tile.RotateTile(new Vector3(0, 90, 0));
            }
        }

        private Vector3 NextTilePosition() =>
            _currentPositionTile +=
                new Vector3(_sizeTile.x * _currentDirection.x, 0, _sizeTile.z * _currentDirection.z);

        private Vector3 BiasNextTile(BaseTile tile)
        {
            Vector3 courdinateToMove;
            int changeDirection = 1;
            if (tile.Start.SideTile == Enums.SideTile.Up || tile.Start.SideTile == Enums.SideTile.Down)
            {
                courdinateToMove = new Vector3(1, 0);
            }
            else
            {
                courdinateToMove = new Vector3(0, 0, 1);
            }

            if (_currentDirection == new Vector3(0, 0, 1) || _currentDirection == new Vector3(-1, 0, 0))
                changeDirection = -1;

            int bias = ((int) _lastTile.Finish.NumberOfWay.GetInvertNumberOfWay() - (int) tile.Start.NumberOfWay) * 20 *
                       changeDirection;
            return courdinateToMove * bias;
        }

        private BaseTile GetNextTile()
        {
             return  _gameFactory.SpawnRandomTile();
            /*var til = Object.Instantiate(_tile[Random.Range(0, _tile.Length)]);
            return til;*/
        }
    }
}