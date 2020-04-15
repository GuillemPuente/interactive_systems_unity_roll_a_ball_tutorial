using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text WinText;

    private Rigidbody rb;
    private int count;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        if (transform.position.y < -100) transform.position = new Vector3(10, 10, 11);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            if (count >= 8)
            {
                WinText.text = "You Win!";
            }
        }
        
    }

    void SetCountText()
    {
        countText.text = "Objects collected: " + count.ToString();
    }
}
