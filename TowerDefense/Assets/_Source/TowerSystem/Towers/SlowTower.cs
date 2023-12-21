using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using UnityEngine.UI;
using EnemiesSystem.Data;

public class SlowTower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject attackAnim;
    [SerializeField] private GameObject UpgradeUI;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private AudioSource attackSound;
    [Header("Attribute")]
    [SerializeField] public float attackRange = 5f;
    [SerializeField] public float fireRate = 4f;
    [SerializeField] public float damage = 5f;
    [SerializeField] private float slow = 0.5f;
    [SerializeField] private float slowTime = 1f;
    [SerializeField] private bool isMagic = false;
     [SerializeField] private float upgradeCost1 = 150;
    [SerializeField] private float upgradeCost2 = 200;
    [Header("Upgraded Stats")]
    [SerializeField] private float fireRate2 = 1.5f;
    [SerializeField] private float damage2 = 20f;
    [SerializeField] private float slow2 = 0.5f;
    [SerializeField] private float slowTime2 = 1f;
    [SerializeField] private float fireRate3 = 2f;
    [SerializeField] private float damage3 = 25f;
     [SerializeField] private float slow3 = 0.5f;
    [SerializeField] private float slowTime3 = 1f;


    private float timeUntilFire;
    private int level = 1;
    private void Update()
    {

        timeUntilFire += Time.deltaTime;
        if (timeUntilFire >= 1f / fireRate)
        {
            Attack();
            timeUntilFire = 0f;
        }
    }
    private void Attack()
    {

        var enemies = Physics2D.OverlapCircleAll(transform.position, attackRange, 1 << LayerMask.NameToLayer("Enemy"));
        if (enemies.Length > 0)
        {
            attackSound.Play();
            attackAnim.SetActive(true);
            StartCoroutine(AttackHide());
            foreach (var item in enemies)
            {
                item.transform.GetComponent<Enemy>().DamgeRecieved(damage, isMagic);
                item.transform.GetComponent<Enemy>().Slowed(slow, slowTime);
            }
        }
    }
    private IEnumerator AttackHide()
    {
        yield return new WaitForSeconds(0.3f);
        attackAnim.SetActive(false);
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
            slow = slow2;
            slowTime = slowTime2;
        }
        else if (LevelManager.main.SpendCurrency(upgradeCost2) && level == 2)
        {
            level++;
            damage = damage3;
            fireRate = fireRate3;
            slow = slow3;
            slowTime = slowTime3;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.blue;
        Handles.DrawWireDisc(transform.position, transform.forward, attackRange);
    }
}

