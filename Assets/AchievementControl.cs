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
                achievementText = "Colete todos os diskets da hist�ria de Pethasvya";
                break;
            case 1:
                achievementTitle = "Prot�tipo Perfeito";
                achievementText = "Finalize o jogo sem morrer";
                break;
            case 2:
                achievementTitle = "Her�i de ferro";
                achievementText = "Derrote o escorpi�o";
                break;
            case 3:
                achievementTitle = "Pernas de a�o";
                achievementText = "Nade por 30 segundos na areia movedi�a";
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
