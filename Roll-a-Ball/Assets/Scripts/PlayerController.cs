using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI deathCounter;
    public TextMeshProUGUI timeText;
    private Rigidbody rb;
    private int cubes;
    private int deaths;
    private float time;
    private float movementX;
    private float movementY;
    private Vector3 respawnposition;
    [SerializeField] private AudioClip[] deathSounds;
    [SerializeField] private AudioClip[] cubeSounds;
    void Start() {
        rb = GetComponent<Rigidbody>();
        cubes = 0;
        deaths = 0;
        time = 0;

        respawnposition = transform.position;

        PlayerPrefs.SetInt("Deaths", 0);
        PlayerPrefs.SetInt("Cubes", 0);
        PlayerPrefs.SetInt("Time", 0);
        PlayerPrefs.Save();

        SetCountText();
        SetDeathCounterText();
        setTimeText();
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void SetCountText() {
        countText.text = "Cubes: " + cubes.ToString() + " / 12";
        if (cubes == 12) countText.color = Color.green;
    }

    void SetDeathCounterText() {
        deathCounter.text = "Deaths: " + deaths.ToString() + " / 5";
        if (deaths == 6) deathCounter.color = Color.red;
    }

    void setTimeText() {
        timeText.text = "Time: " + ((int) time).ToString() + " / 180";
        if ((int) time > 180) timeText.color = Color.red;
    }

    private void NullifyForce() {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void Update() {
        CheckPosition();
        time += Time.deltaTime;
        setTimeText();
    }

    void CheckPosition() {
        if (transform.position.y < -10) {
            transform.position = respawnposition;
            deaths += 1;
            SoundFXManager.instance.PlaySoundFXClip(deathSounds, transform, 1f);
            NullifyForce();
            SetDeathCounterText();
        }
        else if (transform.position.z > 70 && transform.position.y >= 3) {
            respawnposition = new Vector3(0, 3.5f, 70);
        }
    }

    private void FixedUpdate() {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false); 
            cubes++;
            SoundFXManager.instance.PlaySoundFXClip(cubeSounds, transform, 1f);
            SetCountText();
        }
        else if (other.gameObject.CompareTag("KillerWall")) {
            transform.position = respawnposition;
            deaths += 1;
            SoundFXManager.instance.PlaySoundFXClip(deathSounds, transform, 1f);
            NullifyForce();
            SetDeathCounterText();
        }
        else if (other.gameObject.CompareTag("Goal")) {
            PlayerPrefs.SetInt("Deaths", deaths);
            PlayerPrefs.SetInt("Cubes", cubes);
            PlayerPrefs.SetInt("Time", (int) time);
            PlayerPrefs.Save();

            SceneManager.LoadScene("EndGame");
        }
    }
}
