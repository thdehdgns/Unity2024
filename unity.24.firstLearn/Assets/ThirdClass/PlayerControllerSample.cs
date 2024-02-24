
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class PlayerControllerSample : MonoBehaviour
    {
        PlayerMoveSample playerMove;
        PlayerRotationSample playerRotation;

        Animator animator;

        public enum PlayerState { Idle, Run, Death }

        PlayerState playerstate;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            playerstate = PlayerState.Idle;
            playerMove = new PlayerMoveSample();
            animator = GetComponentInChildren<Animator>();
        }

        private void Update()
        {
            SetPlayerState();
            playerMove.MovePlayer(this.transform);
            SetPlayerAnimation();
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
        }

        public void PlayerDeath()
        {
            animator?.SetTrigger("Death");
        }

        public void PlayerMove()
        {
            animator.SetBool("IsRun", true);
        }

        public void PlayerIdle()
        {
            animator.SetBool("IsRun", false);
        }

    } 
}
