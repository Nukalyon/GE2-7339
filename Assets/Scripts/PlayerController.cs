using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vitesse = 5;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Cache
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        Vector2 move = InputManager.mouvementInput;
        rb.velocity = new Vector3(move.x * vitesse, rb.velocity.y, move.y * vitesse);


    }
}
