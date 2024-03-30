using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitcontoller : MonoBehaviour
{
    Animator anim;

    public float currentHP;
    public float MaxHP = 3; 

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        currentHP = MaxHP;
    }

    public void TakeDamage()
    {
        currentHP -= 1;
        CheckHP();
        if (Gamemanager.Instance.IsPlayerDeath)
        {
            return;
        }
        anim.CrossFade("Damage", 0.2f); 
        
        
    }

    private void CheckHP()
    {
        if(currentHP <= 0)
        {
            Gamemanager.Instance.IsPlayerDeath = true;
            anim.CrossFade("Die1", 0.2f);
            Gamemanager.Instance.GameOver();
        }
    }
}
