using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    PlayerMove playerMove;
   
    Animator animator;

    public enum PlayerState { Idle, Run, Death, Attack01 }

    PlayerState playerstate;
    public BoxCollider HitBox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("NPC"))
        {
            Debug.Log("NPC와 충돌했습니다!");
            var trigger = other.GetComponent<Texttriger>();
            trigger.TriggerText();

        }
        else
        {
            Debug.Log("태그가 NPC가 아닙니다.");
        }
    }

    private void Awake()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.Instance.IsPlayerDeath == true) return;

        
        
        SetPlayerState();
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(AttckCoroutin());
        }
        playerMove.Move(transform);
        SetPlayerAnimation();
    }


   // private void SetAttack()
   // {
    //    playerstate = PlayerState.Attack01;
    //    HitBox.enabled = true;
    //    Invoke("SetAttackOff",0.5f);

    //}

    //private void SetAttackOff()
    //{
    //    HitBox.enabled = false;
    //}

    IEnumerator AttckCoroutin()
    {
        playerstate = PlayerState.Attack01;
        HitBox.enabled = true;

        yield return new WaitForSeconds(0.5f);
        HitBox.enabled = false;
    }

    private void SetPlayerState()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (v != 0 || h != 0)
        {
            playerstate = PlayerState.Run;
        }
        else
        {
            playerstate = PlayerState.Idle;
        }
    }
    
    
    // 한번만 실행하면 되는 기능을 구현함
    void Initialize()
    {
        // Animator 클래스에 접근을 할 수 있게 됨.
        playerstate = PlayerState.Idle;
        playerMove = new PlayerMove();
        animator = GetComponentInChildren<Animator>();
    }

    public void PlayerDeath()
    {
        //if (animator == null) return;

        Gamemanager.Instance.GameOver();

        if (Gamemanager.Instance.IsPlayerDeath == true) return;

        animator?.SetTrigger("Death");
        Gamemanager.Instance.IsPlayerDeath = true;
    }

    public void PlayerMove()
    {
        animator.SetBool("IsRun", true);
    }

    public void PlayerIdle()
    {
        animator.SetBool("IsRun", false);
    }

    private void SetPlayerAnimation()
    {
        if (playerstate == PlayerState.Idle)
        {
            PlayerIdle();
        }
        else if (playerstate == PlayerState.Run)
        {
            PlayerMove();
        }
        else if(playerstate == PlayerState.Attack01)
        {
            animator.SetTrigger("doAttack");
        }
    }
    //현재 나의 상태를 판별해주는 함수  
}
