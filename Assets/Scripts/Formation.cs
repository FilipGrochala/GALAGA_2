using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Formacja to grupa przeciwników połączonych ze sobą. Mogą poruszać się synchronicznie w tym samym kierunku. W danym momencie tylko jeden z nich może strzelić
public class Formation : MonoBehaviour
{
    
    [SerializeField]
    float brake = 1f;

    [SerializeField]
    Vector2 size;

    public List<Enemy> prefabs = new List<Enemy>();
    public List<Vector2> positions = new List<Vector2>();
    public List<Enemy> enemies = new List<Enemy>();

    public Vector2 Size { get => size; set => size = value; }

    void Start()
    {
       for(int i=0; i < prefabs.Count; i++)
       {
            var temp = Instantiate(prefabs[i],transform);
            temp.transform.position = transform.position + (Vector3)positions[i];
            enemies.Add(temp);
       }

        WhoCanShoot();
   
    }


    void Update()
    {
        if (!enemies.Any())  //jeżeli formacja jest pusta zniszcz ją
        {
            
            Destroy(gameObject);
        }
    }

    // Zmiana strzelca
    public void WhoCanShoot()
    {
        int itCan = UnityEngine.Random.Range(0, enemies.Count()-1);
        enemies[itCan].CanShoot = true;
        Debug.Log("Formacja " + gameObject.name + " ognia!");
    }

    public int CalculateValue()
    {
        int Value = 0;
        for (int i = 0; i < prefabs.Count; i++)
        {
          Value += prefabs[i].Price;
        }
        return Value;
    }
  
}
