using UnityEngine;

public class ObstacleDestroy : Obstacle
{
    internal override void OnCollision(Collision collision) //rewrite function 
    {
        base.OnCollision(collision);
        Destroy(gameObject);
    }
}
