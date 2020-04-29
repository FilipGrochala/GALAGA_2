using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{

    [SerializeField]
    Text HeatCounter;

    void Awake()
    {
        FindObjectOfType<PlayerGun>().OnHeatChanged += heat =>
        {
            HeatCounter.text = heat.ToString();
        };

    }

   
}
