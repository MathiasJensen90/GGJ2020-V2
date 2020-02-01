using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Item Item;

    public float _movementSpeed = 0.1f;
    private float _middleXPos=0;


    public IEnumerator Move(Vector3 targetPos)
    {
        if(targetPos == transform.position)
        {
        }

        //move to middle first
        var below = transform.position.x < _middleXPos;
        while (transform.position.x != _middleXPos && targetPos != transform.position)
        {
            if (below) {
                transform.Translate(_movementSpeed * Time.deltaTime, 0, 0);
                if (transform.position.x > _middleXPos) {
                    transform.position = new Vector2(_middleXPos, transform.position.y );
                }
            } else {
                transform.Translate(-_movementSpeed * Time.deltaTime, 0, 0);
                if (transform.position.x < _middleXPos) {
                    transform.position = new Vector2(_middleXPos, transform.position.y);
                }
            }

            yield return null;
       }

        //move vertically
        below = transform.position.y < targetPos.y;
        while (transform.position.y != targetPos.y) {
            if (below)
            {
                transform.Translate(0, _movementSpeed * Time.deltaTime, 0);
                if (transform.position.y > targetPos.y) { transform.position = new Vector2(transform.position.x, targetPos.y); }
            } else {
                transform.Translate(0, -_movementSpeed * Time.deltaTime, 0);
                if (transform.position.y < targetPos.y) { transform.position = new Vector2(transform.position.x, targetPos.y); }
            }

            yield return null;
        }

        //move horizontally
        below = transform.position.x < targetPos.x;
        while (transform.position.x != targetPos.x)
        {
            if (below)
            {
                transform.Translate(_movementSpeed * Time.deltaTime, 0, 0);
                if (transform.position.x > targetPos.x) { transform.position = new Vector2(targetPos.x, transform.position.y); }
            }
            else
            {
                transform.Translate(-_movementSpeed * Time.deltaTime, 0, 0);
                if (transform.position.x < targetPos.x) { transform.position = new Vector2(targetPos.x, transform.position.y); }
            }

            yield return null;
        }

        transform.position = targetPos;
    }

    private void PreciseMove(Vector3 movement)
    {

    }
    
}
