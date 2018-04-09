using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {
    public GameObject prefabBullet;
    
    public void Shoot(Vector3 playerLoc)
    {
        GameObject bullet = Instantiate(prefabBullet, transform);
        bullet.transform.parent = null;
        Vector3 dir = (playerLoc - transform.position).normalized;
        dir.y = 0;
        bullet.GetComponent<BulletShoot>().direction = dir;
        GetComponentInParent<EnemyAttack>().playAttackSound();
        //bullet.GetComponent<Rigidbody>().AddForce(dir * 1000f * Time.deltaTime, ForceMode.Impulse);
    }
}
