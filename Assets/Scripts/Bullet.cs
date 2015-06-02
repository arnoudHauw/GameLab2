using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private float _speed = 10;
    private Vector3 Movement;
    private GameObject _player;

	void Start () 
    {
        _player = GameObject.Find("MisterCube");
        Movement = _player.GetComponent<Controller1>().movementVector;
	}
	
	void Update () 
    {
        if(Movement.x  >= 0)
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if(Movement.x < 0)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
           
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
