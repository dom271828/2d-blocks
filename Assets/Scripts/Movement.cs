using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.XR.Haptics;



public class Cruise : MonoBehaviour
{
    Rigidbody2D rb;
    public UIDocument uiDocument;
    private Button restartButton;
    private Label statusText;
    private Label boostText;
    private Label scoreText;
    public GameObject explosionEffect;
    public float score = 0f;
    private float boostTimer = 0f;
    void Start()
    {
        restartButton = uiDocument.rootVisualElement.Q<Button>("RestartButton");
        statusText = uiDocument.rootVisualElement.Q<Label>("StatusText");
        boostText = uiDocument.rootVisualElement.Q<Label>("BoostText");
        scoreText = uiDocument.rootVisualElement.Q<Label>("ScoreText");
        restartButton.clicked += ReloadScene;
        restartButton.style.display = DisplayStyle.None;
        statusText.style.display = DisplayStyle.None;
        boostText.style.display = DisplayStyle.None;
    }

    [SerializeField] float currentSpeed = 10f;
    [SerializeField] float steerSpeed = 200f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            boostText.style.display = DisplayStyle.None;
            scoreText.style.display = DisplayStyle.None;
            restartButton.style.display = DisplayStyle.Flex;
            statusText.text = "You got hit by a blade and lost :(";
            statusText.style.display = DisplayStyle.Flex;
        }

        if (collision.CompareTag("Collectible"))
        {
            Destroy(collision.gameObject);
            score += 1f;
            scoreText.text = $"Score: {score}";
            if (score >= 10)
            {
                Destroy(gameObject);
                boostText.style.display = DisplayStyle.None;
                scoreText.style.display = DisplayStyle.None;
                restartButton.style.display = DisplayStyle.Flex;
                statusText.text = "You collected all the artifacts!";
                statusText.style.display = DisplayStyle.Flex;
            }
        }

        if (collision.CompareTag("SlowZone"))
        {
            currentSpeed *= 0.5f;
        }

        if (collision.CompareTag("Boost"))
        {
            currentSpeed *= 2f;
            boostTimer += 1f;
            Destroy(collision.gameObject);
        }
    }

    void ReloadScene()
    {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("SlowZone"))
        {
            currentSpeed = 10f;
        }
    }

    void Update()
    {

        if (boostTimer >= 1f)
        {
            boostTimer += Time.deltaTime;
            boostText.text = $"{6f - boostTimer}";
            boostText.style.display = DisplayStyle.Flex; 
        }

        if (boostTimer > 6f)
        {
            currentSpeed *= 0.5f;
            boostTimer = 0;
            boostText.style.display = DisplayStyle.None; 
        }

        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            move = 1f;
        }

        else if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            steer = 1f;
        }

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    


    }
}