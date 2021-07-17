using UnityEngine;

public class NPCAnimator : MonoBehaviour
{
    SpriteRenderer rend;

    [Tooltip("element 0: up, element 1: down, element 2: left, element 3: right")]
    [SerializeField] Sprite[] idleSprites = new Sprite[4];

    private void Awake()
    {
        if(!rend)
        {
            rend = GetComponent<SpriteRenderer>();
        }
    }

    public void LookAt(int newDirection)
    {
        rend.sprite = idleSprites[newDirection];
    }
}