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
                messageText = "Ol� ser vivo... human�ide... rob�... criatura, ou seja l� o que voc� for. Este � o grande deserto de Pethasvya e sou Joseph, um simples explorador. Aqui n�o � um desertinho comum, as areias daqui tem grandes efeitos curativos, ela � bem cobi�ada pelo povo de Heude, o grande imp�rio sobre as areias! Est� aqui pela areia? Pela geografia? Ou ser� que tem algo a mais?";
                break;
            case 3:
                messageTitle = "Explorador Joseph";
                messageText = "Ol� de novo! Fato divertido: Em Heude h� um deus da disc�rdia, ele � chamado de Aadimos. Eu sinceramente n�o sei por que o cultuam, ele � meio... n�o entendo, ele faz o qu�? Faz voc� brigar pelo �ltimo peda�o de bolo? Sempre que voc� maldisser de algu�m voc� diz 'GRA�AS A DEUS!!' ? Realmente n�o sei, mas � uma coisa a se pensar, at� a pr�xima!";
                break;
            case 4:
                messageTitle = "Explorador Joseph";
                messageText = "Ol� de novo... ainda continua vivo? Que sorte! Voc� deve ter observado que aqui n�o � s� beleza. Viu as criaturas voadoras? Elas s�o conhecidas como Tubresas, prefiro cham�-las de D3SGRA�@DA$, desculpe, eu realmente n�o gosto delas. Bom... por enquanto � isso, adeus.";
                break;
            case 5:
                messageTitle = "Explorador Joseph";
                messageText = "T� cansado(a) n�? Ogn � o nome daquele lagarto laranja, ele � bem r�pido e saboroso, sim, a carne dele � uma das mais procuradas aqui, com ela se faz os t�o cobi�ados Turbies (uma massa crocante com uma deliciosa carne de Ogn). Bom, vou comer o meu agora... � t�o bom!";
                break;
            case 6:
                messageTitle = "Explorador Joseph";
                messageText = "Triste... vazio... sem esperan�a... sozinho..., agora chega de falar de voc� e vamos falar sobre os vermes dessa caverna. Eles s�o conhecidos como Varzsm e s�o bem t�midos... a menos que voc� chegue perto demais, voc� gostaria que pisassem na sua cabe�a?";
                break;
            case 7:
                messageTitle = "Explorador Joseph";
                messageText = "Voc� chegou bem longe!... muito mais do que eu, desisti por aqui mesmo, este monstro � desafiador demais para mim, creio � claro que n�o para voc�. Mas aqui entre n�s... vou te dar uma dica: ele ataca outros bichos sem chegar perto, n�o sei como, mas ele pode atacar de longe.";
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
