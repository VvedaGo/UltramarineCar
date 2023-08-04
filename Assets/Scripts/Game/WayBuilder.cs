using System.Collections.Generic;
using Infrastructure.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game
{
    public class WayBuilder : MonoBehaviour
    {
        [SerializeField] private BaseTile _startTile;
        [SerializeField] private BaseTile[] _tile;
        [SerializeField] private Car _car;

        private readonly Vector3 _sizeTile = new Vector3(80, 0, 80);
       
        private Vector3 _currentDirection = new Vector3(1, 0, 0);
        private Vector3 _currentPositionTile = new Vector3(0, 0, 0);
        
        private List<Vector2Int> _directionsTiles;
        private BaseTile _lastTile;
        private Queue<BaseTile> _tileOnMap;
        private GameFactory _gameFactory;
        
        private bool _first = false;


        private void Start()
        {
            _tileOnMap = new Queue<BaseTile>();
            _tileOnMap.Enqueue(_startTile);
            _lastTile = _startTile;
            SpawnNextTile();
            SpawnNextTile();
        }

        public void Initialize(GameFactory gameFactory, Car car)
        {
            _gameFactory = gameFactory;
            _car = car;
        }

        private void SpawnStartTile()
        {
            
        }


        public void EndTile()
        {
            if (_first)
            {
                SpawnNextTile();
            }

            if (!_first)
                _first = true;
        }

        private void SpawnNextTile()
        {
            BaseTile nextTile = GetNextTile();
            nextTile.transform.position = NextTilePosition();
            RotateNextTile(nextTile);
            Vector3 bias = BiasNextTile(nextTile);
            Vector3 nextPosition = nextTile.transform.position + bias;
            _currentPositionTile += bias;
            nextTile.transform.position = nextPosition;
            _lastTile = nextTile;
            _currentDirection = _lastTile.Finish.SideTile.DirectionBySide();
            _tileOnMap.Enqueue(_lastTile);
            if (_tileOnMap.Count > 3)
            {
                var tile = _tileOnMap.Dequeue();
                Destroy(tile.gameObject);
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
            var til = Instantiate(_tile[Random.Range(0, _tile.Length)]);
            return til;
        }
    }
}