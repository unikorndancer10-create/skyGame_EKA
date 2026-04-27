using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip collisionSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        Obstacle.OnPlayerHit += PlayerCollisionSound;
    }
    private void PlayerCollisionSound()
    {
        audioSource.PlayOneShot(collisionSound);
    }
}
