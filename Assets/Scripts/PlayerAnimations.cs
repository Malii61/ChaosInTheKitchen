using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Player player;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", player.IsWalking());
    }
    private void Update()
    {
        animator.SetBool("isWalking", player.IsWalking());
    }
}
