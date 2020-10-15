using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    List<Formation> Formations;

    [SerializeField]
    int startValue = 10;

    [SerializeField]
    int maxX;

    [SerializeField]
    int maxY;

    [SerializeField]
    int minY;

    [SerializeField]
    int minX;

    
    Vector2 current_size;

    List<Vector2> temp_positions;
    List<Vector2> all_vectors;
    bool is_posible;

    int maxValue = 0;

    // Update is called once per frame
    void Start()
    {
        maxValue = startValue;
        GenerateFormations();
        StartCoroutine(ContinueGeneration());
    }

    void GenerateFormations()
    {
        int tryies = 200;
        all_vectors = CreateStartList();
       

        do
        {
            GenerateFormation();
            tryies--;

        } while (maxValue > 0 && all_vectors.Count > 4 && tryies > 0);

        
    }

    void GenerateFormation()
    {
            Vector2 current_position;

            int index = UnityEngine.Random.Range(0,Formations.Count-1);
            Formation temp = Formations[index];
            current_size = temp.Size;
            current_position = all_vectors[UnityEngine.Random.Range(0, all_vectors.Count - 1)];
            IncludeSize(current_position);
            if (is_posible)
            {
                    Instantiate(temp,
                        current_position,
                        new Quaternion(0, 0, 0, 0));

                    
                    all_vectors.Remove(current_position);
                    maxValue -= temp.CalculateValue();
                    //Debug.Log("Spawn na: " + current_position + "Dlugość" + all_vectors.Count + "Value" + maxValue);
        }
    }
  
    IEnumerator ContinueGeneration()
    {
        while (true)
        {
            if (FindObjectsOfType<Formation>().Length == 0)
            {
                maxValue = startValue;
                GenerateFormations();
                Debug.Log("Next level!:" + maxValue);
            }
            yield return new WaitForSeconds(2f);
        }

    }

    void  IncludeSize(Vector2 current_position)
    {
        temp_positions = new List<Vector2>();
        is_posible = true;

        // dodaje do zajętych wszystkie pozycję na prawo, nad, i prawy górny róg wg. rozmiaru
        for (int i = 1; i <= current_size.x / 2; i++)
        {
           CheckPositions(i, 0, current_position);

            for (int j = 1; j <= current_size.y / 2; j++)
            {
                CheckPositions(0, i, current_position);
                CheckPositions(i, j, current_position);
            }
        }

        // dodaje do zajętych wszystkie pozycję na lewo, pod, i dolny lewy róg wg. rozmiaru
        for (int i = 1; i <= current_size.x / 2; i++)
        {
            CheckPositions(-i, 0, current_position);
            for (int j = 1; j <= current_size.y / 2; j++)
            {
                CheckPositions(0, -j, current_position);
                CheckPositions(-i, -j, current_position);
            }
        }

        // dodaje do zajętych wszystkie pozycję prawy dolny róg wg. rozmiaru
        for (int i = 1; i <= current_size.x / 2; i++)
        {
            for (int j = 1; j <= current_size.y / 2; j++)
            {
                CheckPositions(i, -j, current_position);
            }
        }

        // dodaje do zajętych wszystkie pozycję lewy górny róg wg. rozmiaru
        for (int i = 1; i <= current_size.x / 2; i++)
        {
            for (int j = 1; j <= current_size.y / 2; j++)
            {
               CheckPositions(-i, j, current_position);
            }
        }

        if (is_posible)
        {
            for (int i = 0; i < temp_positions.Count; i++)
                all_vectors.Remove(temp_positions[i]);
        }

        
     
    }

    void CheckPositions(int x, int y, Vector2 current_position)
    {
        if (is_posible)
        {
            Vector2 temp = new Vector2(current_position.x + x, current_position.y + y);

            // nowa pozycja jest wolna i należy do planszy 
            if (all_vectors.Contains(temp) && CheckBounders(temp))
            {
                temp_positions.Add(temp);

            }

            // nowa pozycja nie jest wolna i należy do planszy
            if (!all_vectors.Contains(temp) && CheckBounders(temp))
            {
               // Debug.Log("Tu nie wolno!" + current_position + "Dlugosc" + all_vectors.Count);
                all_vectors.Remove(temp);
                is_posible = false;
            }
        }

      
    }

    List<Vector2> CreateStartList()
    {
        List<Vector2> _all_vectors = new List<Vector2>();
        for (int i = minX; i <= maxX; i++)
        {
            for (int j = minY; j <= maxY; j++)
            {
                _all_vectors.Add(new Vector2(i, j));
            }
        }
        return _all_vectors;
    }

    bool CheckBounders(Vector2 position)
    {
        if (position.x <= maxX && position.x >= minX && position.y <= maxY && position.y >= minY)
            return true;
        else
            return false;
    }

    

    
   
   
    
}
