using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Fireball : MonoBehaviour, IWeapon
{
    private GameObject player;
    private Item item;
    private Animator _anim;

    private float delayTimer;
    public float delayTime = 0.3f;

    public void Start()
    {
        _anim = GetComponentInParent<Animator>();
    }

    public void OnAttackEnded()
    {
    }

    public void Attack()
    {
        if (delayTimer <= 0)
        {
            _anim.SetBool("AttackMelee", true);

            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
            float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            var rot = Quaternion.Euler(0f, 0f, rotZ);

            var prefab = (GameObject)Resources.Load("Fireball", typeof(GameObject));
            Instantiate(prefab, player.transform.position, rot);

            delayTimer = delayTime;
        }
    }

    public void SetItem(Item item)
    {
        this.item = item;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    private void Update()
    {
        if (delayTimer > 0)
        {
            delayTimer -= Time.deltaTime;
        }
    }
}
