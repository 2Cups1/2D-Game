using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClearer : MonoBehaviour
{
    [SerializeField] float clearerSpeed;

    public ParticleSystem deathParticles;

    //private SoundHandler sh;
    private AudioSource explosion;

    private void Start()
    {
        //sh = GetComponent<SoundHandler>();
        explosion = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.player.transform.position, clearerSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hole")
        {
            for (int i = 0; i < Player.player.enemies.Count; i++)
            {
                Destroy(Player.player.enemies[i]);
            }
            Destroy(gameObject);
            Instantiate(deathParticles, this.transform.position, Quaternion.identity);
            //sh.PlayExplosion();
            explosion.Play();
        }
        else if (other.tag == "Player" || other.tag == "Enemy")
        {
            Destroy(gameObject);
            //sh.PlayExplosion();
        }

    }
}
