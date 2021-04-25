using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public PlayerControl playerControl;
    private bool facingRight = true;
    // Start is called before the first frame update

    void Update()
    {
        if (playerControl.hasControl == true)
        {
            Vector3 cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            if (cursor.x < transform.localPosition.x && facingRight)
            {
                SpriteRenderer.flipX = true;
                facingRight = false;
            }
            else if (cursor.x > transform.localPosition.x && !facingRight)
            {
                SpriteRenderer.flipX = false;
                facingRight = true;
            }
        }
    }
}
