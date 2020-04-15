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
        FindObjectOfType<Gun>().OnHeatChanged += heat =>
        {
            HeatCounter.text = heat.ToString();
        };

    }

   
}
