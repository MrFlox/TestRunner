using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace RunnerGame
{
    public class ItemFactory<T> : IAbstractFactory<T> where T: MonoBehaviour
    {
        private readonly List<T> _variants;
        private readonly ObjectPool<T> _pool;
        public ItemFactory(List<T> variants, int defaultCapacity = 15)
        {
            _variants = variants;
            _pool = new ObjectPool<T>(CreateSegment,
                OnTakeSegmentFromPool,
                OnReturnSegment,
                OnDestroySegment,
                true, defaultCapacity, defaultCapacity * 10);
        }
        private T CreateSegment() =>
            Object.Instantiate(_variants[Random.Range(0, _variants.Count)]);
        private void OnTakeSegmentFromPool(T segment) => segment.gameObject.SetActive(true);
        private void OnReturnSegment(T segment) => segment.gameObject.SetActive(false);
        private void OnDestroySegment(T segment) => Object.Destroy(segment.gameObject);
        public T Create() => _pool.Get();
        public void Release(T segment) => _pool.Release(segment);
    }
}