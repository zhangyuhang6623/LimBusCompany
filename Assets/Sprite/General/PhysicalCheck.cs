using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalCheck : MonoBehaviour
{
    public bool isGrand;
    public bool isLeftWall;
    public bool isRightWall;
    public Vector2 bottomOffsett;
    public Vector2 leftOffsett;
    public Vector2 rightOffsett;
    public float checkRaduis;
    public LayerMask groundLayer;
    private void Update()
    {
        Check();
    }
    public void Check()
    {
        isGrand = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffsett, checkRaduis, groundLayer);
        isLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffsett, checkRaduis, groundLayer);
        isRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffsett, checkRaduis, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffsett, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffsett, checkRaduis);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffsett, checkRaduis);
    }
}
