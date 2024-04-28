using UnityEngine;
using System.Collections;
using System.Linq;

public class EnemyController : MonoBehaviour {
    public Transform visionPoint;
    private CharacterController player;

    public GameObject[] Player;
    private float timebetweenChange = 7/3;
    private float nextTimeToChange = 0f;
    private GameObject currentTarget;

    public float visionAngle = 60f;
    public float visionDistance = 100f;
    public float moveSpeed = 20f;
    public float chaseDistance = 30f;
    public float lookAngle = 45f;
    public float lookTimeMin = 0.5f;
    public float lookTimeMax = 3f;

    public Quaternion targetAngle;
    public float lookTime;
    public float nextTimeToRotate = 0f;
    public int lookType = 1;
    public bool lookSide = true;

    public bool inRange;
    public bool detected;

    private Vector3 lastKnownPlayerPosition;
    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindObjectOfType<CharacterController> ();
        detected = false;
        inRange = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (detected)
        {
            Vector3 lookAt = lastKnownPlayerPosition;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        }
        Look();
        if (!inRange)
        {
            int[] left = { 1, 4 };
            bool containsLookType = left.Contains(lookType);
            if (lookSide && Time.time >= nextTimeToRotate)
            {
                targetAngle = Quaternion.AngleAxis(0, Vector3.up)*transform.rotation;
                lookTime = Random.Range(lookTimeMin, lookTimeMax);
                lookSide = false;
                nextTimeToRotate = Time.time + lookTime;
            } else if (containsLookType && Time.time >= nextTimeToRotate)
            {
                targetAngle = Quaternion.AngleAxis(lookAngle, Vector3.up)*transform.rotation;
                lookTime = Random.Range(lookTimeMin, lookTimeMax);
                lookSide = true;
                lookType += 1;
                if (lookType == 5)
                {
                    lookType = 1;
                }
                nextTimeToRotate = Time.time + lookTime;
            } else if (Time.time >= nextTimeToRotate)
            {
                targetAngle = Quaternion.AngleAxis(-lookAngle, Vector3.up)*transform.rotation;
                lookTime = Random.Range(lookTimeMin, lookTimeMax);
                lookSide = true;
                lookType += 1;
                nextTimeToRotate = Time.time + lookTime;
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, targetAngle,  Time.deltaTime/lookTime);
        }
    }

    private void Look ()
    {
        Vector3 deltaToPlayer = player.transform.position - visionPoint.position;
        Vector3 directionToPlayer = deltaToPlayer.normalized;

        float dot = Vector3.Dot (transform.forward, directionToPlayer);

        if (dot < 0) {
            return;
        }

        float distanceToPlayer = directionToPlayer.magnitude;

        if (distanceToPlayer > visionDistance)
        {
            return;
        }

        float angle = Vector3.Angle (transform.forward, directionToPlayer);

        if(angle > visionAngle)
        {
            return;
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position, directionToPlayer, out hit, visionDistance, 1 << 8))
        {
            if (hit.collider.gameObject == player.gameObject)
            {
                if (Time.time >= nextTimeToChange)
                {
                    currentTarget = Player[Random.Range(0, Player.Length)];
                    nextTimeToChange = Time.time + timebetweenChange;
                }
                lastKnownPlayerPosition = currentTarget.transform.position;
                detected = true;
                inRange = true;
            } else
            {
                inRange = false;
            }
        }
    }
    // private void LookAround()
    // {
    //     int[] left = { 1, 4 };
    //     bool containsLookType = left.Contains(lookType);
    //     if (lookSide)
    //     {
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0),  Time.deltaTime);
    //         lookSide = false;
    //     } else if (lookSide)
    //     {
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, lookAngle, 0),  Time.deltaTime);
    //         lookSide = true;
    //         lookType ++;
    //         if (lookType == 5)
    //         {
    //             lookType = 1;
    //         }
    //     } else
    //     {
    //         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -lookAngle, 0),  Time.deltaTime);
    //         lookSide = true;
    //         lookType ++;
    //     }
    // }
}
