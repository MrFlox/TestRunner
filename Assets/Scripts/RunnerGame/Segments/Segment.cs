using System;
using UnityEngine;

namespace RunnerGame.Segments
{
    public class Segment: MonoBehaviour
    {
        public void SetPosition(float newPosition)
        {
            var position = transform.position;
            position.z = newPosition;
            transform.position = position;
        }
    }
}