using UnityEngine;

public class SpikeSound : MonoBehaviour
{
    private AudioSource spikeSound;

    void Start()
    {
        spikeSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(spikeSound.clip, transform.position);
        }
    }

}
