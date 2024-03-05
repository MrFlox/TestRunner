using System.Collections.Generic;
using RunnerGame.Segments;
using UnityEngine;

namespace RunnerGame
{
    public class SegmentGenerator : MonoBehaviour
    {
        [SerializeField] private float SegmentSize = 40f;
        [SerializeField] private int InitialSegmentCount = 5;
        [SerializeField] private float DistanceBetweenPlayerAndSegmentCenter = .1f;
        [SerializeField] private Transform hero;
        [SerializeField] private List<Segment> segmentVariants;
        [SerializeField] private List<Segment> segmentsOnStage = new();
        private SegmentFactory _factory;
        private void Start()
        {
            _factory = new SegmentFactory(segmentVariants);
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
            var newSegment = _factory.Create();
            newSegment.SetPosition(GetLastSegmentPosition() + SegmentSize);
            segmentsOnStage.Add(newSegment);
            if (!deleteOld) return;
            RemoveFirstSegment();
        }
        private void RemoveFirstSegment()
        {
            var first = segmentsOnStage[0];
            segmentsOnStage.Remove(first);
            _factory.Release(first);
        }
        private float GetLastSegmentPosition()
        {
            if (segmentsOnStage.Count == 0) return SegmentSize;
            var lastSegment = segmentsOnStage[^1];
            return lastSegment.transform.position.z ;
        }
    }
}