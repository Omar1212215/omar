using UnityEngine;
using UnityEngine.UI; // Only needed if you want to show the coin count on UI
using TMPro;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    public int coinCount = 0;
    public TMP_Text coinText; // Optional – assign a UI Text to display the count

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateCoinUI();
    }

    void Update()
    {
        // Simple WASD or Arrow key movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(move * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object has the tag "Coin"
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject); // Remove the coin
            coinCount++;               // Increase counter
            UpdateCoinUI();            // Update UI (if exists)
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }
}
