using UnityEngine;

public class CoinSound : MonoBehaviour
{
    private AudioSource coinSound;

    void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound.clip, transform.position);
        }
    }

}
