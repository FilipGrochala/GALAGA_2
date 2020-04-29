using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Formation : MonoBehaviour
{
    [SerializeField]
    int maxValue = 3;

    public List<Enemy> enemies = new List<Enemy>();

    void Update()
    {
        if(!enemies.Any())  //jeżeli formacja jest pusta zniszcz ją
        {
            Destroy(gameObject);
        }
    }


  
}
