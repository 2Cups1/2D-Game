using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    private int scoreCounter = 0;

    public ParticleSystem deathParticles;

    //private SoundHandler sh;
    private AudioSource explosion;

    bool inactive = false;

    private void Start()
    {
        //sh = GetComponent<SoundHandler>();
        explosion = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Move();
        SpeedUp();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.player.transform.position, speed * Time.deltaTime);
    }

    private void SpeedUp()
    {
        while (scoreCounter > 1)
        {
            speed = 7;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (inactive == false)
        {
            if (other.tag == "Player" || other.tag == "Enemy")
            {
                Player.player.TakeDamage();
                Player.player.enemies.Add(gameObject);
                speed = 0;
                transform.parent = Player.player.transform;
            }
            else if (other.tag == "Hole")
            {
                Player.player.UpdateScore();
                Destroy(gameObject);
                scoreCounter++;
                Instantiate(deathParticles, this.transform.position, Quaternion.identity);
                //sh.PlayExplosion();
                explosion.Play();
            }
            inactive = true;
        }
    }
}

