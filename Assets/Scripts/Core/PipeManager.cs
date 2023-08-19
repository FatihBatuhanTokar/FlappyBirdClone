using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class PipeManager : MonoBehaviour
    {
        [SerializeField] float pipeDistance;
        [SerializeField] Vector3 firstPipeStartPoint;
        BirdCollisionDetection birdCollisionDetection;
        public List<Pipe> pipes;
        public GameObject pipePrefab;
        int poolStartCounter;
        void Start()
        {
            InitializePool();
            birdCollisionDetection = FindObjectOfType<BirdCollisionDetection>();
            birdCollisionDetection.OnPipePassed += OnPipePass;
        }
        public void OnPipePass()
        {
            poolStartCounter += 1;
            if (poolStartCounter < 2) return;
            Pipe backPipe = pipes[0];
            foreach (var pipe in pipes)
            {
                if (pipe.transform.position.x <= backPipe.transform.position.x)
                {
                    backPipe = pipe;
                }
            }
            backPipe.transform.position = backPipe.transform.position + Vector3.right * pipeDistance * pipes.Count;
            backPipe.SetPipePositions();
        }
        void InitializePool()
        {

            for (int i = 0; i < 10; i++)
            {
                GameObject newPipeObj = Instantiate(pipePrefab);
                newPipeObj.transform.position = firstPipeStartPoint + Vector3.right * i * pipeDistance;
                Pipe newPipe = newPipeObj.GetComponent<Pipe>();
                pipes.Add(newPipe);
                newPipe.SetPipePositions();
            }

        }
    }
}
