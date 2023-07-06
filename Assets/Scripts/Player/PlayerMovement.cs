using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Assertions.Must;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    private float minimumDistance = .2f;
    [SerializeField, Range(0f,1f)]  
    private float directionThreshhold = 0.9f;
    public float jumpHeight;

    private int lineToMove = 1;
    public float lineDistance = 4;

    #region JumpCoroutine
    [SerializeField]
    private bool isJumping = false;
    public Rigidbody rb;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Constant moving forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        //Touch start position
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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
    }
    private void SwipeDirection(Vector2 direction)
    {
        //Direction calculation
        if (Vector2.Dot(Vector2.up, direction) > directionThreshhold && isJumping == false)
        {
            Debug.Log("Jump");
            isJumping = true;
            StartCoroutine(Jump());

        }
        if (Vector2.Dot(Vector2.down, direction) > directionThreshhold)
        {
            Debug.Log("Crouch");
        }
        if (Vector2.Dot(Vector2.left, direction) > directionThreshhold && lineToMove > 0 )
        {
            transform.position = new Vector3(transform.position.x - lineDistance, transform.position.y, transform.position.z);
            lineToMove--;
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshhold && lineToMove < 2)
        {
            transform.position = new Vector3(transform.position.x + lineDistance, transform.position.y, transform.position.z);
            lineToMove++;
        }
    }

   private IEnumerator Jump()
   {
        rb.isKinematic = false;
        transform.Translate(new Vector3(transform.position.x + jumpHeight, transform.position.y, transform.position.z), Space.World);
        yield return new WaitForSeconds(1f);
        rb.isKinematic = true;
        isJumping = false;
   }
}
