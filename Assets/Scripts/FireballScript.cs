using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage = 5;
    public LayerMask whatIsSolid;

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Damageable"))
            {
                var damageable = hitInfo.collider.gameObject.GetComponent<IDamageable>();
                damageable.Damage(damage);
            }
            Destroy(gameObject);
        }
        transform.position += transform.rotation * Vector3.right * Time.deltaTime * speed;
    }
}
