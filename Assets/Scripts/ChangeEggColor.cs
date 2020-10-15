using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEggColor : MonoBehaviour
{
    [SerializeField]
    Sprite[] eggs;

    // Update is called once per frame
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = eggs[UnityEngine.Random.Range(0, eggs.Length - 1)];
    }
}
