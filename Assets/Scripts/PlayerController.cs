using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float vitesse = 5;

    Rigidbody rb;
    private bool isMoving = false;
    
    void Start()
    {
        //Cache
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        DeplaceDansDirectionDuCamera();
    }

    private void DeplaceDansDirectionDuCamera()
    {
        // Trouver l'input du InputManager, je sépare les inputs pour que ce soit plus facile à comprendre
        float horizontalInput = InputManager.mouvementInput.x;
        float verticalInput = InputManager.mouvementInput.y;

        // Calculer la direction FORWARD relative à la caméra
        Vector3 forwardDirection = Camera.main.transform.forward;
        forwardDirection.y = 0; // Remove vertical movement

        // Calculer la direction RIGHT relative à la caméra
        Vector3 rightDirection = Camera.main.transform.right;

        // Combine les directions forward et right dans un seul vecteur
        Vector3 movementDirection = forwardDirection * verticalInput + rightDirection * horizontalInput;
        movementDirection.Normalize(); // Ensure the direction vector has a length of 1

        // Appliquer le mouvement au Rigidbody
        Vector3 movement = movementDirection * (vitesse * Time.deltaTime);
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        if (movementDirection != Vector3.zero)
        {
            TurnTowardsMovementDirection(movementDirection);
        }
    }
    
    
    //Eventuellement, on utilisera cette méthode pour un meilleur feeling.
    //Le joueur ne se déplacera que vers l'avant relativement à la caméra, pas à gauche, à droite ou en arrière
    private void DeplaceSeulementForwardRelativeDuCamera()
    {
        Vector3 moveInput = new Vector3(InputManager.tournerInput.x, 0, InputManager.tournerInput.y);
        Vector3 moveDirection = (transform.forward * moveInput.z + transform.right * moveInput.x).normalized;
        moveDirection.y = 0;        

        if (moveInput.z > 0)
        {
            if (!isMoving)
            {
                moveDirection = Camera.main.transform.forward;
                moveDirection.y = 0;

                TurnTowardsMovementDirection(moveDirection);
                isMoving = true;
            }
        }
        else
        {
            isMoving = false;
        }
        
        Vector3 movement = moveDirection.normalized * (vitesse * Time.fixedDeltaTime);
        
        rb.MovePosition(rb.position + movement);
    }

    //Cette méthode permet de tourner le joueur dans la direction du mouvement
    private void TurnTowardsMovementDirection(Vector3 moveDirection)
    {
        //Calculer la rotation à appliquer au Rigidbody
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection); 
        rb.rotation = targetRotation;
    }
}
