using UnityEngine;
using System.Collections;

public class Controller1 : MonoBehaviour {

	public Vector2 movementVector;
    private CharacterController _characterController;
    private float _movementSpeed = 0.05f;  
    private float _jumpPower = 1;
    private float _gravity = 40;
    private bool _grounded = false;
    private float _climbspeed = 0.75f;
    private bool _climbladder;
	void Start () 
    {
        //characterController = GetComponent<CharacterController>();
	}
	
	void Update () 
    {
        movementVector.x = Input.GetAxis("LeftJoystickX") * _movementSpeed;
        transform.Translate(movementVector.x, 0, 0, Space.Self);

        if (_grounded == true)
        {     
            if(Input.GetButtonDown("A"))
            {
                //transform.Translate((Vector2.up * _jumpPower) * Time.deltaTime);
                GetComponent<Rigidbody2D>().AddForce((Vector2.up * _jumpPower) * Time.deltaTime);
            }
        }
        movementVector.y -= _gravity * Time.deltaTime;

        if(_climbladder == true)
        {
            if (Input.GetButtonDown("A"))
            {
                //transform.Translate((Vector2.up * _jumpPower) * Time.deltaTime);
                GetComponent<Rigidbody2D>().AddForce((Vector2.up * _climbspeed) * Time.deltaTime);
            }
            GetComponent<Rigidbody2D>().gravityScale = 0.9f;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            _grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            _grounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "ladder")
        {
            _climbladder = true;
        }
    }
    void OnTriggerExit2D(Collider2D otherexit)
    {
        if (otherexit.tag == "ladder")
        {
            _climbladder = false;
        }
    }
}
