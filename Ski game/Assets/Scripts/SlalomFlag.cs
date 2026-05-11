using Unity.VisualScripting;
using UnityEngine;

public class SlalomFlag : MonoBehaviour
{
    private bool flagpassed = false;
    private enum Direction {Left, Right};
    [SerializeField] private Direction direction;
    [SerializeField] private Material goodMat, badMat;
    public static GameManager.TimerEvent RacePenalty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControll.player != null &&
            PlayerControll.player.position.z < transform.position.z &&
            flagpassed == false)
        {
            Direction passingDirection = Direction.Right;
            if(PlayerControll.player.position.x < transform.position.x)
                passingDirection = Direction.Left;

            flagpassed = true;
            Debug.LogError("Player passed on: " + passingDirection);

            MeshRenderer renderer = GetComponent<MeshRenderer>();
            if (passingDirection == direction)
            {
                Debug.LogError("passed on correct side");
                renderer.material = goodMat;
            }
            else
            {
                Debug.LogError("passed on wrong side");
                renderer.material = badMat;

                RacePenalty.Invoke();
            }
        }
    }
}
