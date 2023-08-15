using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class PipeManager : MonoBehaviour
    {
        [SerializeField] float pipeDistance;
        [SerializeField] Vector3 firstPipeStartPoint;
        BirdCollisionDetection birdCollisionDetection;
        public List<Transform> pipes;
        public GameObject pipePrefab;
        bool isPass=true;
        void Start()
        {
            InitializePool();
            birdCollisionDetection = FindObjectOfType<BirdCollisionDetection>();
            birdCollisionDetection.OnPipePassed += OnPipePass;
        }
        public void OnPipePass()
        {
          
            Transform backPipe = pipes[0];
            foreach (var pipe in pipes)
            {
                if (pipe.position.x <= backPipe.position.x)
                {
                    Debug.Log("New Pipe");
                    backPipe = pipe;
                }
            }
            backPipe.position = backPipe.position + Vector3.right * pipeDistance * pipes.Count;
            backPipe.GetComponent<Pipe>().SetPipePositions();
            isPass = true;
        }
        void InitializePool()
        {

            for (int i = 0; i < 10; i++)
            {
                GameObject newPipe = Instantiate(pipePrefab);
                newPipe.transform.position = firstPipeStartPoint + Vector3.right * i * pipeDistance;
                pipes.Add(newPipe.transform);
                newPipe.GetComponent<Pipe>().SetPipePositions();
            }

        }
    }
}
