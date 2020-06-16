using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.LookAt(target);
        transform.position = new Vector3(target.transform.position.x + 2, target.transform.position.y + 2f, transform.position.z );
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
