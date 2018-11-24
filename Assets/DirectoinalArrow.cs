using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectoinalArrow : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public void Update()
    {
        Vector3 targrtDirection = target.transform.position;

        targrtDirection.y = transform.position.y;

        transform.LookAt(target.transform.position);

        targetReached();
    }

    public void targetReached()
    {
        if (Vector3.Distance(target.transform.position, player.transform.position) < 2)
        {
            Debug.Log("Reached Target");

        }

    }
}
