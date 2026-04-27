using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public delegate void playerHitAction();
    public static event playerHitAction OnPlayerHit; //evemts
    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }
       
    internal virtual void OnCollision(Collision collision) //to rewrite
    {
        if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Player collided " + name);
            OnPlayerHit.Invoke();
        }
    }
}
