using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : Gun
{
    [SerializeField]
    int Limit = 30;  // limit przegrzania

    [SerializeField]
    float StandardDuration=0.1f; // standardowe opóźnienie odnawiania

    [SerializeField]
    float OverheatedDuration=1f; // odnawianie po przegrzaniu

    private int heat;
    public int Heat
    {
        get
        {
            return heat;
        }
        private set
        {
            heat = value;
            if (OnHeatChanged != null)
                OnHeatChanged.Invoke(Heat);
        }
    }

    public event System.Action<int> OnHeatChanged;

    void Start()
    {
       
        Heat = Limit;
        StartCoroutine(HeatCooldown());
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (Heat != 0)
            {
                ShootBullet();
                Heat--;
            }
    }

 
    IEnumerator HeatCooldown()
    {   while (true)
        {
            if (Heat < Limit && Heat > 0) // jeśli gracz nie strzelił czekaj
            {
                Heat++;
                yield return new WaitForSeconds(StandardDuration);
            }
            else if (Heat == 0) // jeśli przegrzał broń odczekaj chwile i zregeneruj broń
            {
                yield return new WaitForSeconds(OverheatedDuration);
                Heat += 5;
            }
            else if(Heat == Limit) // standardowe odnawianie
            {
                yield return new WaitForSeconds(StandardDuration);
            }
        }
    }



}
