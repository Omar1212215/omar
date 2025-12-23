using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6f;

    [Tooltip("If true, movement is based on the camera direction (W = forward where camera looks).")]
    public bool moveRelativeToCamera = false;
    public Transform cameraTransform;

    [Header("Animation Settings")]
    public Animator animator;
    public string runBoolName = "Run"; // Animator BOOL parameter name

    [Header("Score Settings")]
    public int coinCount = 0;
    public TMP_Text coinText;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        UpdateCoinUI();

        if (moveRelativeToCamera && cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); // A/D
        float z = Input.GetAxisRaw("Vertical");   // W/S

        Vector3 moveDir;

        if (moveRelativeToCamera && cameraTransform != null)
        {
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            moveDir = (right * x + forward * z).normalized;
        }
        else
        {
            moveDir = new Vector3(x, 0f, z).normalized;
        }

        // Move with Rigidbody
        Vector3 targetVelocity = moveDir * moveSpeed;
        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);

        // Set Run BOOL
        bool isMoving = moveDir.sqrMagnitude > 0.001f;
        if (animator != null)
            animator.SetBool(runBoolName, isMoving);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinCount++;
            UpdateCoinUI();
        }
        else if (other.CompareTag("notcoin"))
        {
            Destroy(other.gameObject);
            coinCount--;
            if (coinCount < 0) coinCount = 0;
            UpdateCoinUI();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            coinCount--;
            if (coinCount < 0) coinCount = 0;
            UpdateCoinUI();
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }
}
