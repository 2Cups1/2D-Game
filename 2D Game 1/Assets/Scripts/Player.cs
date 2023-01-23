using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float turnSpeed;

    public int health;
    public int score;

    public TMP_Text healthDisplay;
    public TMP_Text scoreDisplay;

    public static Player player;

    public List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        player = this;
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxisRaw("Horizontal") * Time.deltaTime);
    }

    public void TakeDamage()
    {
        health-= 10;
        healthDisplay.text = "Health: " + health;
    }

    public void UpdateScore()
    {
        score++;
        scoreDisplay.text = "Score: " + score;
    }
}
