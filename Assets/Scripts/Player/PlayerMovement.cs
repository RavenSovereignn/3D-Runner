using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private CharacterController characterController;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private Vector3 dir;

    private float minimumDistance = .2f;
    [SerializeField, Range(0f,1f)]  
    private float directionThreshhold = 0.9f;

    public float jumpHeight;
    private float gravity = -30;
    private int lineToMove = 1;
    public float lineDistance = 4;

    public Animator playerAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveSpeed > 0f)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        
        

        //Touch start position
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPos = Input.GetTouch(0).position;
        }
        //Touch end position
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
       {
            endTouchPos = Input.GetTouch(0).position;
            //counts distance between touches to calculate direction
            if(Vector3.Distance(startTouchPos, endTouchPos) > minimumDistance)
            {
                Vector3 direction = endTouchPos - startTouchPos;
                Vector2 direction2d = new Vector2(direction.x , direction.y).normalized;
                SwipeDirection(direction2d);
            }
        }
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left  * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right  *  lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            characterController.Move(moveDir);
        else
            characterController.Move(diff);
    }
    private void FixedUpdate()
    {
        dir.z = moveSpeed;
        //Gravity for character
        dir.y += gravity * Time.fixedDeltaTime;
        //Constant moving forward
        characterController.Move(dir * Time.fixedDeltaTime);
        
    }
    private void SwipeDirection(Vector2 direction)
    {
        //Direction calculation
        if (Vector2.Dot(Vector2.up, direction) > directionThreshhold && characterController.isGrounded == true)
        {
            Debug.Log("Jump");
            dir.y = jumpHeight;
            playerAnimator.SetTrigger("Jump");

        }
        if (Vector2.Dot(Vector2.down, direction) > directionThreshhold)
        {
            Debug.Log("Crouch");
            dir.y = 0;
            playerAnimator.SetTrigger("Roll");
        }
        if (Vector2.Dot(Vector2.left, direction) > directionThreshhold && lineToMove > 0 )
        {
            lineToMove--;
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshhold && lineToMove < 2)
        {  
            lineToMove++;
        }
    }
    
}
