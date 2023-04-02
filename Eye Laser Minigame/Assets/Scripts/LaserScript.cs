using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            ScoreManager.instance.addPoint();
            Destroy(collision.gameObject);
            return;
        }

        var c = collision.GetComponent<EnemyScript>();
        if (c != null)
        {
            ScoreManager.instance.addPoint();
            Destroy(collision.gameObject);
        }

    }
}
