using System.Collections.Generic;
using RunnerGame.LevelItems;
using TriInspector;
using UnityEngine;

namespace RunnerGame.Segments
{
    public class Segment : MonoBehaviour
    {
        [SerializeField] private Coin coinPrefab;
        [SerializeField] private Transform coinPositionsLayer;
        [SerializeField] private List<Vector3> coinPositions;
        [SerializeField] private List<Coin> generatedCoins = new();
        private IAbstractFactory<Coin> _coinFactory;
        public void SetPosition(float newPosition)
        {
            var position = transform.position;
            position.z = newPosition;
            transform.position = position;
        }
        public void ClearOldCointAndGenerateNew(IAbstractFactory<Coin> coinFactory)
        {
            if (_coinFactory == null) _coinFactory = coinFactory;
            ClearOldCoins();
            GenerateNewCoins();
        }
        private void GenerateNewCoins()
        {
            foreach (var coinPosition in coinPositions)
            {
                var coin = CreateCoin(coinPosition);
                generatedCoins.Add(coin);
            }
        }
        private Coin CreateCoin(Vector3 coinPosition)
        {
            var coin = CreateNewCoin();
            coin.transform.SetParent(transform);
            coin.SetRandomType();
            coin.transform.position = coinPosition + transform.position;
            coin.SetSegment(this);
            return coin;
        }
        private Coin CreateNewCoin()
        {
            return _coinFactory.Create();
        }
        public void RemoveCoin(Coin coin)
        {
            generatedCoins.Remove(coin);
            _coinFactory.Release(coin);
        }
        public void ClearOldCoins()
        {
            for (var i = generatedCoins.Count - 1; i >= 0; i--)
                RemoveCoin(generatedCoins[i]);
        }
        [Button]
        private void LoadPositions()
        {
            coinPositions.Clear();
            for (var i = 0; i < coinPositionsLayer.childCount; i++)
                coinPositions.Add(coinPositionsLayer.GetChild(i).position);
        }
    }
}