using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleyedDestroy : MonoBehaviour
{
        public float deley = 5f;
        void Start()
        {
            Destroy(gameObject, deley);

        }
    
}
