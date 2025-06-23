using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class dialogue : MonoBehaviour
{

    public Image characterImage;
    public TMP_Text dialogueText;

    private int currentLine = 0;

    public string[] dialogueLines =
      { "Привет, друг! Я - Сергей Королёв. Один из самых важных людей в истории освоения космоса. Я родился в 1907 году и с детства увлекался техникой и мечтал о полётах. Я стал главным конструктором ракет и руководил созданием первой советской баллистической ракеты. Под моим руководством в 1957 году был запущен первый искусственный спутник Земли, а в 1961 году — первый человек, Юрий Гагарин, отправился в космос.\r\n",
      "Несмотря на то, что в 1930-х годах меня несправедливо арестовали и отправили в лагерь, я не перестал верить в свое дело и после освобождения вернулся к работе. Также участвовал в создании первых космических кораблей серии «Восток» и «Восход».Благодаря моим заслугами Советский Союз стал первой страной, начавшей активное освоение космоса. Рад знакомству! ",
      "Ну что ж мой юный друг, готов ли ты познать все сложности ракетостроения ? \r\n Вперед к звездам! \r\n",
    };

    public string[] WhileGame =
    {
        "Здесь ты можешь собрать свою ракету! У каждой детали есть свои характеристики. Внимательно следи чтоб они подходили для полета. Справа ты можешь это отследить. \r\n Когда будешь уверен в своей ракете, нажимай кнопку - дальше! \r\n"
    };
 
    public float typingSpeed = 0.05f;

    private bool isTyping = false;
    private bool canContinue = false;
    private Coroutine typingCorountine;

    public bool firstDialogueFinsihed;


    // Start is called before the first frame update
    void Start()
    {
        ShowLine(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (isTyping)
            {
                StopCoroutine(typingCorountine);
                dialogueText.text = dialogueLines[currentLine];
                isTyping = false;
                canContinue = true;
            }
            else if (canContinue)
            {
                currentLine++;
                if (currentLine < dialogueLines.Length)
                {
                    ShowLine();
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    void ShowLine()
    {
        dialogueText.text = "";
        typingCorountine = StartCoroutine(TypeLine(dialogueLines[currentLine]));
    }

    IEnumerator TypeLine(string line)
    {
        isTyping = true;
        canContinue = false;

        foreach (char c in line)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        dialogueText.gameObject.SetActive(false);
        characterImage.gameObject.SetActive(false);
        firstDialogueFinsihed = true;
    }

    public void StartWhileGameDialogue()
    {
        currentLine = 0;
        dialogueLines = WhileGame; 
        dialogueText.text = "";
        characterImage.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        ShowLine();
    }

}
