using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public int jumpLimit = 2;
    private int jumpCount = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private bool j = false;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
        
    }

    void OnMove(InputValue movementValue)
    {
        // function body
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnJump()
    {
        if (jumpCount < jumpLimit){
            j = true;
            jumpCount = jumpCount + 1; // count to make sure we don't jump more than jumpLimit
        }
        
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 8){
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if(j == true){
            Vector3 movement = new Vector3(movementX/2, 1.0f, movementY/2);
            rb.AddForce(movement*speed, ForceMode.Impulse);
        }
        
        Vector3 movement2 = new Vector3(movementX/2, -0.1f, movementY/2);
        rb.AddForce(movement2*speed);
        j = false;

    }


    // https://answers.unity.com/questions/1417767/c-how-to-check-if-player-is-grounded.html 
    // this gave me the idea for double jump implementation
    void OnCollisionEnter(Collision player)
    {
        if (player.gameObject.name == "Ground"){ // if the player is touching the ground
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
    }

    
}

