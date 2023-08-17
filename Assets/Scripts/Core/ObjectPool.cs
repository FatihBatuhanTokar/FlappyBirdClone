using System.Collections.Generic;
using UnityEngine;

namespace Script.Core
{
    public class ObjectPool : MonoBehaviour
    {
        public GameObject prefab;
        public int initialPoolSize = 4;

        private Queue<GameObject> objectPool = new Queue<GameObject>();

        PipeManager pipeManager;

        float spawnPosition;
      
        private void Start()
        {
            pipeManager = FindObjectOfType<PipeManager>();
            InitializePool();
            SceneLoad(); 
        }

        private void InitializePool()
        {
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject newObj = Instantiate(prefab);
                newObj.SetActive(false);
                objectPool.Enqueue(newObj);
            }
        }
        private void SceneLoad()
        {
            for (int i = 0; i < 3; i++)
            {
                GetObjectFromPool();
            }
            
        }
        public void GetObjectFromPool()
        {
            if (objectPool.Count > 0)
            {
                GameObject obj = objectPool.Dequeue();
                obj.SetActive(true);
                obj.transform.position = new Vector2(spawnPosition, obj.transform.position.y);
               
            }
            else
            {
                // If the pool is empty, create a new object
                GameObject newObj = Instantiate(prefab);
                newObj.transform.position = new Vector2(spawnPosition, newObj.transform.position.y);

            }
            spawnPosition += 2.89f;
        }

        public void ReturnObjectToPool(GameObject obj)
        {
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }
}
