using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isJump;
    private float horizontalInput;
    private Rigidbody rigidBodyComp;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
     rigidBodyComp =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            isJump= true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    //called everytime physics updates
    void FixedUpdate(){
        rigidBodyComp.velocity = new Vector3(horizontalInput,rigidBodyComp.velocity.y,0); 
        //handling double jump
        if (!isGrounded){
            return;
        }
        if(isJump){
            rigidBodyComp.AddForce(Vector3.up*7 ,ForceMode.VelocityChange);
            isJump= false;
        }
        
    }
    //triggers when collision occurs
    void OnCollisionEnter(){
        isGrounded = true;
    }
    //triggers when collision is not happening
    void OnCollisionExit(){
        isGrounded = false;
    }
}
