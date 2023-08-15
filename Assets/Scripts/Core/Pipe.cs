using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class Pipe : MonoBehaviour
    {
        public Transform pipe;

        public void SetPipePositions()
        {
            float yPos = Mathf.Clamp(Random.Range(-.25f, 1.5f) , -.25f, 1.25f);
            pipe.position = new Vector3(pipe.position.x, yPos, 0);
        }
    }
}
