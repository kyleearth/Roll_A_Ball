using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //TEXT

public class PlayerController : MonoBehaviour
{
    public float speed;  //note public
    public Text countText;
    public Text winText;
    public Text counterText; //time
    public float seconds, minutes;


    private Rigidbody rb;
    private int count;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        counterText.text = "";
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
    }

    void Update()
    {
        if (count < 12)
        {
            minutes = (int)(Time.time / 60f);
            seconds = (int)(Time.time % 60f);
            counterText.text = "Time:  " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }

    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winText.text = "You Win!!! "+ "Complete " + counterText.text;
        }


    }
}

