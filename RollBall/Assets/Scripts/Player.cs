using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{

    public float speed;
    public float dashSpeed = 50;
    public Text countText;
    public Text winText;
    public float dashCool = 30;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //bool moveDash = Input.GetAxis("Fire3");
        float moveJump = Input.GetAxis("Jump");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(movement * speed * dashSpeed);
            //dashCool = 30;
        }

        if (dashCool > 0)
        {
            dashCool -= 1;
        }

        if (dashCool < 0)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(movement * speed * dashSpeed);
                dashCool = 30;
            }
        }


        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
