using System.Collections.Generic;
using RunnerGame.Segments;
using UnityEngine;
using UnityEngine.Pool;

namespace RunnerGame
{
    public class SegmentFactory
    {
        private readonly List<Segment> _segments;
        private readonly ObjectPool<Segment> _pool;
        public SegmentFactory(List<Segment> segments)
        {
            _segments = segments;
            _pool = new ObjectPool<Segment>(CreateSegment,
                OnTakeSegmentFromPool,
                OnReturnSegment,
                OnDestroySegment,
                true, 15, 100 );
        }
        private Segment CreateSegment() => Object.Instantiate(_segments[0]);
        private void OnTakeSegmentFromPool(Segment segment)
        {
            // segment.gameObject.SetActive(true);
        }
        private void OnReturnSegment(Segment segment)
        {
            // segment.gameObject.SetActive(false);
        }
        private void OnDestroySegment(Segment segment) => Object.Destroy(segment.gameObject);
        public Segment Create() => _pool.Get();
        public void Release(Segment segment) => _pool.Release(segment);
    }
}