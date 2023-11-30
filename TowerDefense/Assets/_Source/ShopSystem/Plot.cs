using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color hoverColor;
    public GameObject towerObj;
    public Tower tower;
    private Color startColor;
    private void Start()
    {
        startColor = sprite.color;
    }
    private void OnMouseEnter()
    {
        sprite.color = hoverColor;
    }
    private void OnMouseExit()
    {
        sprite.color = startColor;
    }
    private void OnMouseDown()
    {
        if (UIManager.main.IsHoveringUI())
        {
            return;
        }
        if (towerObj != null)
        {
            tower.OpenUpgradeUI();
            return;
        }

        Shop towerToBuild = BuildManager.main.GetSelectedTower();

        if (LevelManager.main.SpendCurrency(towerToBuild.cost))
        {
            towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
            tower = towerObj.GetComponent<Tower>();
        }

    }
}
