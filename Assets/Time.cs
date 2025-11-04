using UnityEngine;
using TMPro;    

public class CountdownTimerTMP : MonoBehaviour
{
    public float startTime = 10f;          // seconds to count down from
    public TMP_Text timerText;             // TextMeshPro text object
    public GameObject uiToActivate;        // UI element to activate when done

    private float currentTime;

    void Start()
    {
        currentTime = startTime;
        if (uiToActivate != null)
            uiToActivate.SetActive(false); // hide target UI at start
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timerText.text = "time: "+Mathf.Ceil(currentTime).ToString(); // show time left
        }
        else
        {
            timerText.text = "time: 0";
            if (uiToActivate != null)
                uiToActivate.SetActive(true); // show the other UI
            enabled = false; // stop updating
        }
    }
}
