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
}
