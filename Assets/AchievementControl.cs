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

    public int achievementID = 0;
    public int[] achievementLockList;


    void Start()
    {
        achievementLockList = new int[5] {0, 0, 0, 0, 0};
        move2D = player.GetComponent<Move2D>();
        textMeshProUiGUITitle = achievementTitleBox.GetComponent<TextMeshProUGUI>();
        textMeshProUiGUIText = achievementTextBox.GetComponent<TextMeshProUGUI>();

        OnAchievement();
    }

    // Update is called once per frame
    void Update()
    {
        if (move2D.onAchievement)
        {
            animator.SetTrigger("AchivementUnlock");
        }
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
                achievementTitle = "Colecionador de Meteorito";
                achievementText = "Colete todos os meteoritos espalhados por Pethasvya";
                break;

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
