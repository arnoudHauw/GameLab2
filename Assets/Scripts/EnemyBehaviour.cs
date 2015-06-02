using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject[] _player;
    public int _curPlayer;
    private int _speed = 1;
    private bool _chasing = true;
    private float _health = 100;
    private Vector2 _waypoint;

    void Start()
    {
        _player = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if (_chasing == true)
        {
            /*transform.LookAt(_player);
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);*/
        }
        
        if (_health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void FixedUpdate()
    {
        Vector2 dist = new Vector2(_player[_curPlayer].transform.position.x - transform.position.x, _player[_curPlayer].transform.position.y - transform.position.y);

        if (dist.x < 0)
        {
            _waypoint = new Vector2(-1, _waypoint.y);
        }
        else if (dist.x > 0)
        {
            _waypoint = new Vector2(1, _waypoint.y);
        }
        if(dist.y < 0)
        {
            _waypoint = new Vector2(_waypoint.x, -1);
        }
        else if (dist.y > 0)
        {
            _waypoint = new Vector2(_waypoint.x, 1);
        }

        transform.Translate(_waypoint * _speed * Time.deltaTime);
    }
	
	void OnTriggerEnter2D (Collider2D other) 
    {
        if(other.tag == "Player")
        {
            //_player = other.transform;
            _chasing = true;
        }
        else if(other.tag == "bullet")
        {
            _health = _health - 50;
        } 
        else if (other.tag == "ladder")
        {
            GetComponent<Rigidbody2D>().gravityScale = 0.5f;
        }
	}
}
