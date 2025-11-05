using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;

    [Header("Score Settings")]
    public int coinCount = 0;
    public TMP_Text coinText; // UI text to display points

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
        // Gain points for coins
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount++;
            UpdateCoinUI();
        }
        // Lose points for "notcoin"
        else if (other.CompareTag("notcoin"))
        {
            Destroy(other.gameObject);
            coinCount--;
            if (coinCount < 0) coinCount = 0;
            UpdateCoinUI();
        }
    }

    // Detect collisions with enemies (non-trigger collisions)
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            coinCount--; // Lose one point per hit

            // Optional: Prevent negative score
            if (coinCount < 0)
                coinCount = 0;

            UpdateCoinUI();

            Debug.Log("Hit an enemy! Points reduced.");
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }
}
