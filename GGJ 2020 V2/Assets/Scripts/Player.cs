using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isMoving = false;
    private float _movementSpeed = 0.1f;
    private float _middleYPos=0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move(Vector3 targetPos)
    {
        bool hasBeenToMiddle = false;
        bool _isMoving = true;

        while (transform.position != targetPos)
        {
            //first move to the middle of the screen
            if (transform.position.y != _middleYPos && !hasBeenToMiddle)
            {
                if (transform.position.y < _middleYPos)
                {
                    transform.Translate(0, _movementSpeed, 0);
                    if (transform.position.y > _middleYPos)
                    {
                        transform.position = new Vector3(transform.position.x, _middleYPos, 0);
                        hasBeenToMiddle = true;
                    }
                }
                if (transform.position.y > _middleYPos)
                {
                    transform.Translate(0, -_movementSpeed, 0);
                    if (transform.position.y < _middleYPos)
                    {
                        transform.position = new Vector3(transform.position.x, _middleYPos, 0);
                        hasBeenToMiddle = true;
                    }
                }
            }
            //move horizontally
            else if (transform.position.x != targetPos.x)
            {
                if (transform.position.x < targetPos.x)
                {
                    transform.Translate(_movementSpeed, 0, 0);
                    if (transform.position.x > targetPos.x) { transform.position = new Vector3(targetPos.x, transform.position.y, 0); }
                }
                if (transform.position.x > targetPos.x)
                {
                    transform.Translate(0, -_movementSpeed, 0);
                    if (transform.position.x < targetPos.x) { transform.position = new Vector3(targetPos.x, transform.position.y, 0); }
                }
            }
            //move vertically
            else if (transform.position.y != targetPos.y)
            {
                if (transform.position.y < targetPos.y)
                {
                    transform.Translate(0, _movementSpeed, 0);
                    if (transform.position.y > targetPos.y) { transform.position = new Vector3(transform.position.x, targetPos.y, 0); }
                }
                if (transform.position.y > targetPos.y)
                {
                    transform.Translate(0, -_movementSpeed, 0);
                    if (transform.position.y < targetPos.y) { transform.position = new Vector3(transform.position.x, targetPos.y, 0); }
                }
            }

            yield return null;
        }

        
        
    }

    private void PreciseMove(Vector3 movement)
    {

    }
    
}
