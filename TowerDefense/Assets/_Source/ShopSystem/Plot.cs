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
    public AOETower aoeTower;
    public SlowTower slowTower;
    private Color startColor;
    public float GoldCount { get; set; }
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
            if (towerObj.TryGetComponent<AOETower>(out AOETower aoeTower))
            {
                aoeTower.OpenUpgradeUI();
            }
            else if (towerObj.TryGetComponent<Tower>(out Tower tower))
            {
                tower.OpenUpgradeUI();
            }
            else if (towerObj.TryGetComponent<SlowTower>(out SlowTower slowTower))
            {
                slowTower.OpenUpgradeUI();
            }

            return;
        }

        Shop towerToBuild = BuildManager.main.GetSelectedTower();

        if (LevelManager.main.SpendCurrency(towerToBuild.cost))
        {
            towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
            towerObj.SetActive(true);
            tower = towerObj.GetComponent<Tower>();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
