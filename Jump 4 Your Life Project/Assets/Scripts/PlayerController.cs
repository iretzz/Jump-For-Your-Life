using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 100.0f;
    public float speed = 1000.0f;
    public float keyVolume = 2f;
    public float jumpVolume = 2f;
    public bool isOnGround = true;
    public bool changeBool = true;
    public GameObject key;
    public AudioClip jumpSound;
    public AudioClip pickKey;
    static AudioSource audioSrc;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    public void DestroyObjects()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
            playerRb.AddForce(Vector3.up * speed);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.gameObject.tag == "Lava")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Key")
        {
            audioSrc.PlayOneShot(pickKey, keyVolume);
            GameObject[] gameobjectss = GameObject.FindGameObjectsWithTag("DeleteLava");
            foreach (GameObject obstacle in gameobjectss)
            {
                GameObject.Destroy(obstacle);
            }
            Destroy(other.gameObject);

            changeBool = false;
        }
    }

    void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            audioSrc.PlayOneShot(jumpSound, jumpVolume);
            
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        // playerRb.AddForce(Vector3.right * horizontalInput * speed);
        playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime, ForceMode.Impulse);
    }
}
