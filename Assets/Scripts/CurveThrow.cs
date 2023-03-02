using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveThrow : MonoBehaviour
{
    private Rigidbody2D projectile;

    private void Start()
    {
        projectile = GetComponent<Rigidbody2D>();
    }
}
