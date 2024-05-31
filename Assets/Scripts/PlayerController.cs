using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public TextMeshProUGUI countText;
    private float movementX;
    private float movementY;
    public float speed = 0; 
    public GameObject winText;
    public CountDownTimer countdownTimer;

    // Start is called before the first frame update
    void Start(){
       rb = GetComponent<Rigidbody>(); 
       count = 0;
       SetCountText();
       winText.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    private void FixedUpdate(){
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")) 
       {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
       }
        
    }

    void SetCountText() 
    {
        countText.text =  "Count: " + count.ToString();
          if (count >= 18)
       {
           winText.SetActive(true);
           countdownTimer.StopTimer();
       }
    }
}
