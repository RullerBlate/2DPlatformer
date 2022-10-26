using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isGoingRight = true;

    void Update()
    {
        if (isGoingRight)
        transform.Translate(1 * Time.deltaTime, 0, 0);
        else
        transform.Translate(-1 * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("RightWall"))
            isGoingRight = false;

        if (collision.gameObject.layer == LayerMask.NameToLayer("LeftWall"))
            isGoingRight = true;
    }
}
