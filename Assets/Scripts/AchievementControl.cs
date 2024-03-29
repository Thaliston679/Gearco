using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementControl : MonoBehaviour
{
    public GameObject player;
    private Move2D move2D;
    public Animator animator;

    private string achievementTitle;
    private string achievementText;

    public GameObject achievementTitleBox;
    public GameObject achievementTextBox;

    TextMeshProUGUI textMeshProUiGUITitle;
    TextMeshProUGUI textMeshProUiGUIText;

    private string disketsCounter;
    private string achievsCounter;
    private string achievsCounterCredits;
    private string meteorsCounter;
    public GameObject disketsCounterBox;
    public GameObject achievsCounterBox;
    public GameObject achievsCounterBoxCredits;
    public GameObject meteorsCounterBox;
    TextMeshProUGUI disketsCounterTextMeshProUiGUI;
    TextMeshProUGUI achievsCounterTextMeshProUiGUI;
    TextMeshProUGUI achievsCounterTextMeshProUiGUICredits;
    TextMeshProUGUI meteorsCounterTextMeshProUiGUI;

    public int achievementID = 0;
    public int[] achievementLockList;


    void Start()
    {
        achievementLockList = new int[] {0, 0, 0, 0, 0, 0};
        move2D = player.GetComponent<Move2D>();
        textMeshProUiGUITitle = achievementTitleBox.GetComponent<TextMeshProUGUI>();
        textMeshProUiGUIText = achievementTextBox.GetComponent<TextMeshProUGUI>();

        disketsCounterTextMeshProUiGUI = disketsCounterBox.GetComponent<TextMeshProUGUI>();
        achievsCounterTextMeshProUiGUI = achievsCounterBox.GetComponent<TextMeshProUGUI>();
        achievsCounterTextMeshProUiGUICredits = achievsCounterBoxCredits.GetComponent<TextMeshProUGUI>();
        meteorsCounterTextMeshProUiGUI = meteorsCounterBox.GetComponent<TextMeshProUGUI>();

        OnAchievement();
    }

    // Update is called once per frame
    void Update()
    {
        if (move2D.onAchievement)
        {
            animator.SetTrigger("AchivementUnlock");
        }

        disketsCounter = move2D.GetDisketsCollected().ToString() + " / 6";
        achievsCounter = move2D.GetAchievementsUnlocked().ToString() + " / 6";
        achievsCounterCredits = move2D.GetAchievementsUnlocked().ToString() + " / 6";
        meteorsCounter = move2D.GetMeteorsCollected().ToString() + " / 6";

        disketsCounterTextMeshProUiGUI.text = disketsCounter;
        achievsCounterTextMeshProUiGUI.text = achievsCounter;
        achievsCounterTextMeshProUiGUICredits.text = achievsCounterCredits;
        meteorsCounterTextMeshProUiGUI.text = meteorsCounter;
    }

    public void OnAchievement()
    {
        switch (achievementID)
        {
            case 1:
                achievementTitle = "Historiador";
                achievementText = "Colete todos os diskets da hist�ria de Pethasvya";
                break;
            case 2:
                achievementTitle = "Prot�tipo Perfeito";
                achievementText = "Finalize o jogo sem morrer";
                break;
            case 3:
                achievementTitle = "Her�i de ferro";
                achievementText = "Derrote o escorpi�o";
                break;
            case 4:
                achievementTitle = "Pernas de a�o";
                achievementText = "Nade por 30 segundos na areia movedi�a";
                break;
            case 5:
                achievementTitle = "Colecionador";
                achievementText = "Colete todos os meteoritos espalhados por Pethasvya";
                break;
            case 6:
                achievementTitle = "Limpando a �rea";
                achievementText = "Elimine todas as amea�as menores";
                break;
                /*
                case 7:
                    achievementTitle = "Sniper perfeito";
                    achievementText = "Acerte 100% dos tiros";
                    break;
                case 8:
                    achievementTitle = "Intang�vel";
                    achievementText = "N�o sofra nenhum arranh�o";
                    break;
                 */
        }

        textMeshProUiGUITitle.text = achievementTitle;
        textMeshProUiGUIText.text = achievementText;


    }

    public string GetAchievementTitle()
    {
        return achievementTitle;
    }

    public string GetAchievementText()
    {
        return achievementText;
    }

    public void SetAchievementID(int aID)
    {
        achievementID = aID;
    }
}
