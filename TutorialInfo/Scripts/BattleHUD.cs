using TMPro;
using TutorialInfo.Scripts.Monsters;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text levelText;
    public Slider hpSlider;
    public GameObject hpHUD;
    private Monster monster;
    public Button selectButton;
    
    public void setHUD(Monster monster)
    {
        nameText.text = monster.getName();
        levelText.text = "Lvl." + monster.getLevel();
        hpSlider.maxValue = monster.getMaxHP();
        hpSlider.value = monster.getCurrentHP();
        this.monster = monster;
    }

    public Monster getHUDTarget()
    {
        return monster;
    }

    public void updateHP()
    {
        hpSlider.value = monster.getCurrentHP();
    }

    public void setActive(bool active)
    {
        hpHUD.SetActive(active);
    }
}
