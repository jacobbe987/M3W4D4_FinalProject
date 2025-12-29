using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //private PlayerController _playerController;
    private PlayerController _playerController;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void IsWalking()
    {
        if (_playerController.Direction !=Vector2.zero)
        {
            _animator.SetBool("IsWalking", true);
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }

        FlipSprite();
        
    }
    private void FlipSprite()
    {

        if (_playerController.Direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_playerController.Direction.x == 0 && _playerController.Direction.y < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_playerController.Direction.x > 0 || _playerController.Direction.y > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
