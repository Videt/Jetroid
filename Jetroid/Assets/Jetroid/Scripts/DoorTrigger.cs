using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
    public bool ignoreTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ignoreTrigger)
            return;

        if (collision.gameObject.CompareTag("Player"))
            door.Open();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (ignoreTrigger)
            return;

        if (collision.gameObject.CompareTag("Player"))
            door.Close();
    }

    public void Toggle(bool value)
    {
        if (value == true)
            door.Open();
        else
            door.Close();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = ignoreTrigger ? Color.gray : Color.green;

        BoxCollider2D bc2D = GetComponent<BoxCollider2D>();
        Vector3 pos = bc2D.transform.position;

        Vector2 newPos = new Vector2(pos.x + bc2D.offset.x, pos.y + bc2D.offset.y);
        Gizmos.DrawWireCube(newPos, new Vector2(bc2D.size.x, bc2D.size.y));
    }
}
