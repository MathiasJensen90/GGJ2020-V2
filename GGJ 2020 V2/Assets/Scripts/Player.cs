using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Item Item;

    private bool _isMoving = false;
    public float _movementSpeed = 0.1f;
    private float _middleYPos=0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move(new Vector3(5, -3, 0)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Move(Vector3 targetPos)
    {
        var below = transform.position.y < _middleYPos;
        while (transform.position.y != _middleYPos)
        {
            if (below) {
                transform.Translate(0, _movementSpeed * Time.deltaTime, 0);
                if (transform.position.y > _middleYPos) {
                    transform.position = new Vector2(transform.position.x, _middleYPos);
                }
            } else {
                transform.Translate(0, -_movementSpeed * Time.deltaTime, 0);
                if (transform.position.y < _middleYPos) {
                    transform.position = new Vector2(transform.position.x, _middleYPos);
                }
            }

            yield return null;
       }

        below = transform.position.x < targetPos.x;
        while (transform.position.x != targetPos.x) {
            if (below)
            {
                transform.Translate(_movementSpeed * Time.deltaTime, 0, 0);
                if (transform.position.x > targetPos.x) { transform.position = new Vector2(targetPos.x, transform.position.y); }
            } else {
                transform.Translate(-_movementSpeed * Time.deltaTime, 0, 0);
                if (transform.position.x < targetPos.x) { transform.position = new Vector2(targetPos.x, transform.position.y); }
            }

            yield return null;
        }

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

        transform.position = targetPos;
    }

    private void PreciseMove(Vector3 movement)
    {

    }
    
}
