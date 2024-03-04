using System;
using System.Collections.Generic;
using System.Numerics;
using RunnerGame.Segments;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Vector3 = UnityEngine.Vector3;

namespace RunnerGame
{
    public class SegmentGenerator : MonoBehaviour
    {
        [SerializeField] private Transform hero;
        private const float SegmentSize = 40f;
        [SerializeField] private List<Segment> segments;
        [SerializeField] private List<Segment> segmentsOnStage = new();

        private void Start() => GenerateFistSegments();
        private void GenerateFistSegments()
        {
            for (int i = 0; i < 5; i++)
                GenerateNewSegment(false);
        }
        private void Update()
        {
            if (segmentsOnStage.Count <= 5) return;
            if (DistanceFromCenterOfSegment() < .1f)
                GenerateNewSegment();
        }
        private float DistanceFromCenterOfSegment() =>
            segmentsOnStage[^3].transform.position.z - hero.position.z;

        private void GenerateNewSegment(bool deleteOld = true)
        {
            var newSegment = Instantiate(segments[0]);
            var newPostion = new Vector3();
            newPostion.z = GetLastSegmentPosition() + SegmentSize;
            newSegment.transform.position = newPostion;
            segmentsOnStage.Add(newSegment);
            if (deleteOld)
            {
                var first = segmentsOnStage[0];
                segmentsOnStage.Remove(first);
                Destroy(first.gameObject);
            }
        }
        private float GetLastSegmentPosition()
        {
            var lastSegment = segmentsOnStage[^1];
            if (lastSegment != null) return lastSegment.transform.position.z;
            return SegmentSize;
        }
    }
}