using UnityEngine;
using UnityEngine.UIElements;

public class RoomChangeTrigger : MonoBehaviour
{
    public enum CardinalPoints
    {
        North,
        South,
        East,
        West,
        None
    }
    public CardinalPoints direction = CardinalPoints.None;

    private Vector3 North = new Vector3(0, 10, 0);
    private Vector3 South = new Vector3(0, -10, 0);
    private Vector3 East = new Vector3(18, 0, 0);
    private Vector3 West = new Vector3(-18, 0, 0);

    private float playerOffset = 2.25f;

    private float cameraTravelSpeed = 0.1f;
    private Vector3 cameraCurrentPos;
    private Vector3 cameraTargetPos;


    private GameObject player;
    private GameObject mainCamera;

    private SpriteRenderer rend;

    private void Awake()
    {
        player = GameObject.Find("Player");
        mainCamera = GameObject.Find("MainCamera");
    }

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
    }

    void Update()
    {
        cameraCurrentPos = mainCamera.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            switch (direction)
            {
                case CardinalPoints.North:
                    mainCamera.transform.position += North;
                    player.transform.position += new Vector3(0, playerOffset, 0);

                    break;


                case CardinalPoints.South:
                    mainCamera.transform.position += South;
                    player.transform.position -= new Vector3(0, playerOffset, 0);

                    break;


                case CardinalPoints.East:
                    mainCamera.transform.position += East;
                    player.transform.position += new Vector3(playerOffset, 0, 0);

                    break;


                case CardinalPoints.West:
                    mainCamera.transform.position += West;
                    player.transform.position -= new Vector3(playerOffset, 0, 0);

                    break;



                default:
                    break;
            }
        }
    }
}
