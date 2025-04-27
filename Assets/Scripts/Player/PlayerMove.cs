using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float speedSize;
    [SerializeField] private float gravityScale = 9.810f;
    [SerializeField] private int lineToMove;
    [SerializeField] private float lineDistance;

    private CharacterController _characterController;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        _characterController.Move(new Vector3(0, gravityScale, speed) * Time.deltaTime);

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        else if (lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }
        transform.position = targetPosition;
    }

    public void MovementSide(bool isRight)
    {
        if (isRight)
        {
            if (lineToMove < 2) lineToMove++; 
        }
        else
        {
            if(lineToMove > 0) lineToMove--;
        }
    }

}
