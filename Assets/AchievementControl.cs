using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementControl : MonoBehaviour
{
    private string achievementTitle;
    private string achievementText;
    private int achievementID;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnAchievement()
    {
        switch (achievementID)
        {
            case 0:
                achievementTitle = "Historiador";
                achievementText = "Colete todos os diskets da história de Pethasvya";
                break;
            case 1:
                achievementTitle = "Protótipo Perfeito";
                achievementText = "Finalize o jogo sem morrer";
                break;
            case 2:
                achievementTitle = "Herói de ferro";
                achievementText = "Derrote o escorpião";
                break;
            case 3:
                achievementTitle = "Pernas de aço";
                achievementText = "Nade por 30 segundos na areia movediça";
                break;
            case 4:
                achievementTitle = "Colecionador de Meteorito";
                achievementText = "Colete todos os meteoritos espalhados por Pethasvya";
                break;

        }
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
