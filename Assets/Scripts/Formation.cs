using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Formation : MonoBehaviour
{
    [SerializeField]
    int maxValue = 3;
    [SerializeField]
    float brake = 1f;

    public List<Enemy> enemies = new List<Enemy>();

    void Start()
    {
        foreach (Enemy enemy in enemies)
            enemy.CanShoot = false;

        StartCoroutine(WhoCanShoot());


    }


    void Update()
    {
    

        if (!enemies.Any())  //jeżeli formacja jest pusta zniszcz ją
        {
            Destroy(gameObject);
        }
       
    }

    IEnumerator WhoCanShoot()
    {
        System.Random random = new System.Random();

        while (true)
        {
            int itCan = random.Next(0, enemies.Count());
            enemies[itCan].CanShoot = true;
            yield return new WaitForSeconds(brake);
            enemies[itCan].CanShoot = false;

        }
    }


  
}
