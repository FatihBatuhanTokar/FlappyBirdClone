using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Script.Core
{
    public class BirdCollisionDetection : MonoBehaviour
    {
        public event Action OnPipePassed;
       
        bool isPass = true;
       
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.CompareTag("Point") && isPass)
            {
                isPass = false;
                OnPipePassed?.Invoke();
                Debug.Log("Puan alindi");
                Invoke("TriggerSet", .5f);
            }
        }

        void TriggerSet()
        {
            isPass = true;
        }
    }
}
