using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerVisualHandler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    [Header("Movement")]
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    
    [Header("EngineFlame")]
    [SerializeField] private Animator engineAnimator;
    
    private PlayerInputHandler inputHandler;

    private void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if (inputHandler.MoveInput.x > 0)
        {
            spriteRenderer.sprite = rightSprite;
        }
        
        else if (inputHandler.MoveInput.x < 0)
        {
            spriteRenderer.sprite = leftSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
    }
    
    
}
