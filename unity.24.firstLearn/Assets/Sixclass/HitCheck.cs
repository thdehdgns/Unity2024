using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("���Ϳ� �浹��");

        }
    }
}
