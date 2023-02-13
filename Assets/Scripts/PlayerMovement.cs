using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class deals with the player movement

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Animator anim;
    public GameObject playerModel;
    [SerializeField] float rotateSpeed = 3f;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * moveSpeed, rb.velocity.y, verticalInput * moveSpeed); //Main movement code


        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) //Makes the character model move in different directions
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0f, verticalInput));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
            
        }

        anim.SetBool("isGrounded", IsGrounded());
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));

    }    
    
    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        jumpSound.Play();
    }

    private void OnCollisionEnter(Collision collision) //Deals with the killing mechanic when you jump on an enemy
    {
        if (collision.gameObject.CompareTag("EnemyHead"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    
    bool IsGrounded() //Ground check
    {

        return Physics.CheckSphere(groundCheck.position, .1f, ground); 
    }
    
}
