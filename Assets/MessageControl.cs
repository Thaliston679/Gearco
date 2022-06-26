using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageControl : MonoBehaviour
{
    public GameObject player;
    private Move2D move2D;
    public Animator animator;

    private string messageTitle;
    private string messageText;

    public GameObject messageTitleBox;
    public GameObject messageTextBox;

    TextMeshProUGUI textMeshProUiGUITitle;
    TextMeshProUGUI textMeshProUiGUIText;

    public int messageID = 0;
    public int[] messageLockList;


    void Start()
    {
        messageLockList = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
        move2D = player.GetComponent<Move2D>();
        textMeshProUiGUITitle = messageTitleBox.GetComponent<TextMeshProUGUI>();
        textMeshProUiGUIText = messageTextBox.GetComponent<TextMeshProUGUI>();

        OnMessage();
    }

    // Update is called once per frame
    void Update()
    {
        if (move2D.onAchievement)
        {
            animator.SetTrigger("AchivementUnlock");
        }
    }

    public void OnMessage()
    {
        switch (messageID)
        {
            case 1:
                messageTitle = "Sistema";
                messageText = "Projeto GC-001 enviado em miss�o: Use Z ou J ou Espa�o ou bot�o esquerdo do mouse para atacar | Use setas laterais ou A D para andar | Use seta para cima ou W pular. Para mais informa��es... -SOBREVIVA!!!";
                break;
            case 2:
                messageTitle = "Explorador Joseph";
                messageText = "Ol� ser vivo� human�ide� rob� criatura, ou seja l� o que voc� for. Este � o grande deserto de Pethasvya e sou Joseph, um simples explorador. Aqui n�o � um desertinho comum, as areias daqui tem grandes efeitos curativos, ela � bem cobi�ada pelo povo de Heude, o grande imp�rio sobre as areias! Est� aqui pela areia? Pela geografia? Ou ser� que tem algo a mais?";
                break;
            case 3:
                messageTitle = "Explorador Joseph";
                messageText = "Fato divertido: Em Heude h� um deus da disc�rdia, ele � chamado de Aadimos. Eu sinceramente n�o sei por que o cultuam, ele � meio� n�o entendo, ele faz o qu�? Faz voc� brigar pelo �ltimo peda�o de bolo? Sempre que voc� maldisser de algu�m voc� diz 'GRA�AS A DEUS!!' ? Realmente n�o sei, mas � uma coisa a se pensar, at� a pr�xima!";
                break;
            case 4:
                messageTitle = "Explorador Joseph";
                messageText = "Ol� de novo� ainda continua vivo? Que sorte! Voc� deve ter observado que aqui n�o � s� beleza. Viu as criaturas voadoras? Elas s�o conhecidas como Tubresas, prefiro cham�-las de D3SGRA�@DA$, desculpe, eu realmente n�o gosto delas. Bom... por enquanto � isso, adeus.";
                break;
            case 5:
                messageTitle = "Explorador Joseph";
                messageText = "Colete todos os meteoritos espalhados por Pethasvya";
                break;
            case 6:
                messageTitle = "Explorador Joseph";
                messageText = "Elimine todas as amea�as menores";
                break;
            case 7:
                messageTitle = "Explorador Joseph";
                messageText = "Acerte 100% dos tiros";
                break;
            case 8:
                messageTitle = "Sistema";
                messageText = "Dados de meteoritos totalmente coletados. Tecnologia evolu�da. Processando informa��es... Ajustando funcionalidades... Projeto GC-001 implementado com nova funcionalidade: Cad�ncia de tiro elevada. -Esmague o que ver pela frente ainda mais r�pido!!!";
                break;
        }

        textMeshProUiGUITitle.text = messageTitle;
        textMeshProUiGUIText.text = messageText;


    }

    public string GetMessageTitle()
    {
        return messageTitle;
    }

    public string GetMessageText()
    {
        return messageText;
    }

    public void SetMessageID(int aID)
    {
        messageID = aID;
    }
}
