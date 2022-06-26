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
                messageText = "Projeto GC-001 enviado em missão: Use Z ou J ou Espaço ou botão esquerdo do mouse para atacar | Use setas laterais ou A D para andar | Use seta para cima ou W pular. Para mais informações... -SOBREVIVA!!!";
                break;
            case 2:
                messageTitle = "Explorador Joseph";
                messageText = "Olá ser vivo… humanóide… robô… criatura, ou seja lá o que você for. Este é o grande deserto de Pethasvya e sou Joseph, um simples explorador. Aqui não é um desertinho comum, as areias daqui tem grandes efeitos curativos, ela é bem cobiçada pelo povo de Heude, o grande império sobre as areias! Está aqui pela areia? Pela geografia? Ou será que tem algo a mais?";
                break;
            case 3:
                messageTitle = "Explorador Joseph";
                messageText = "Fato divertido: Em Heude há um deus da discórdia, ele é chamado de Aadimos. Eu sinceramente não sei por que o cultuam, ele é meio… não entendo, ele faz o quê? Faz você brigar pelo último pedaço de bolo? Sempre que você maldisser de alguém você diz 'GRAÇAS A DEUS!!' ? Realmente não sei, mas é uma coisa a se pensar, até a próxima!";
                break;
            case 4:
                messageTitle = "Explorador Joseph";
                messageText = "Olá de novo… ainda continua vivo? Que sorte! Você deve ter observado que aqui não é só beleza. Viu as criaturas voadoras? Elas são conhecidas como Tubresas, prefiro chamá-las de D3SGRAÇ@DA$, desculpe, eu realmente não gosto delas. Bom... por enquanto é isso, adeus.";
                break;
            case 5:
                messageTitle = "Explorador Joseph";
                messageText = "Colete todos os meteoritos espalhados por Pethasvya";
                break;
            case 6:
                messageTitle = "Explorador Joseph";
                messageText = "Elimine todas as ameaças menores";
                break;
            case 7:
                messageTitle = "Explorador Joseph";
                messageText = "Acerte 100% dos tiros";
                break;
            case 8:
                messageTitle = "Sistema";
                messageText = "Dados de meteoritos totalmente coletados. Tecnologia evoluída. Processando informações... Ajustando funcionalidades... Projeto GC-001 implementado com nova funcionalidade: Cadência de tiro elevada. -Esmague o que ver pela frente ainda mais rápido!!!";
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
