using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.AI;

public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private Transform towerRotationPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject UpgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private AudioSource attackSound;

    [Header("Attribute")]
    [SerializeField] private float attackRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float damage = 15f;
    [SerializeField] private bool isMagic = false;
    [SerializeField] private float upgradeCost1 = 150;
    [SerializeField] private float upgradeCost2 = 200;
    [Header("Upgraded Stats")]
    [SerializeField] private float fireRate2 = 1.5f;
    [SerializeField] private float damage2 = 20f;
    [SerializeField] private float fireRate3 = 2f;
    [SerializeField] private float damage3 = 25f;

    private Transform target;
    private float timeUntilFire;

    private int level = 1;


    private void Update()
    {
        if (!target)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }

        else
        {
            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / fireRate)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        attackSound.Play();
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        bulletScript.isMagic = isMagic;
        bulletScript.dmg = damage;
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; ++i)
            {
                if (hits[i].transform.gameObject.activeSelf == true)
                {
                    target = hits[i].transform;
                }
            }

        }
    }
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= attackRange;
    }
    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        towerRotationPoint.rotation = Quaternion.RotateTowards(towerRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void OpenUpgradeUI()
    {
        UpgradeUI.SetActive(true);
    }
    public void CloseUpgrade()
    {
        UpgradeUI.SetActive(false);
    }
    public void UpgradeTurret()
    {
        if (LevelManager.main.SpendCurrency(upgradeCost1) && level == 1)
        {
            level++;
            damage = damage2;
            fireRate = fireRate2;
        }
        else if (LevelManager.main.SpendCurrency(upgradeCost2) && level == 2)
        {
            level++;
            damage = damage3;
            fireRate = fireRate3;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
}
