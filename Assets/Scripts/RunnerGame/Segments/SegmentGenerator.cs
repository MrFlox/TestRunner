using System.Collections.Generic;
using RunnerGame.LevelItems;
using UnityEngine;

namespace RunnerGame.Segments
{
    /**
     * This class generates path for the player from different prefab variants.
     */
    public class SegmentGenerator : MonoBehaviour
    {
        [SerializeField] private float SegmentSize = 40f;
        [SerializeField] private int InitialSegmentCount = 5;
        [SerializeField] private float DistanceBetweenPlayerAndSegmentCenter = .1f;
        [SerializeField] private Transform hero;
        [SerializeField] private List<Segment> segmentVariants;
        [SerializeField] private List<Segment> segmentsOnStage = new();
        [SerializeField] private Coin coinPrefab;
        private IAbstractFactory<Segment> _segmentFactory;
        private IAbstractFactory<Coin> _coinFactory;
        private void Start()
        {
            _segmentFactory = new ItemFactory<Segment>(segmentVariants);
            _coinFactory = new ItemFactory<Coin>(new List<Coin>() { coinPrefab }, 200);
            GenerateFistSegments();
        }
        private void GenerateFistSegments()
        {
            for (int i = 0; i < InitialSegmentCount; i++)
                GenerateNewSegment(false);
        }
        private void Update()
        {
            if (segmentsOnStage.Count < InitialSegmentCount) return;
            if (DistanceFromCenterOfSegment() < DistanceBetweenPlayerAndSegmentCenter)
                GenerateNewSegment();
        }
        private float DistanceFromCenterOfSegment() =>
            segmentsOnStage[^(InitialSegmentCount-2)].transform.position.z - hero.position.z;
        private void GenerateNewSegment(bool deleteOld = true)
        {
            var newSegment = _segmentFactory.Create();
            newSegment.ClearOldCointAndGenerateNew(_coinFactory);
            newSegment.SetPosition(GetLastSegmentPosition() + SegmentSize);
            segmentsOnStage.Add(newSegment);
            if (!deleteOld) return;
            RemoveFirstSegment();
        }
        private void RemoveFirstSegment()
        {
            var first = segmentsOnStage[0];
            segmentsOnStage.Remove(first);
            _segmentFactory.Release(first);
        }
        private float GetLastSegmentPosition()
        {
            if (segmentsOnStage.Count == 0) return SegmentSize;
            var lastSegment = segmentsOnStage[^1];
            return lastSegment.transform.position.z ;
        }
    }
}