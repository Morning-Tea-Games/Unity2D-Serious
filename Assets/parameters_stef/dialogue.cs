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
      { "Привет! Меня зовут Сергей Павлович Королев!",
      "Я советский ученый, конструктор ракетно-космических систем.",
      "Мое самое главное достжение это успешный запуск космического корабля 'Восток-1' с космонавтом Юрием Гагариным на борту!",
       "Сегодня мне нужна твоя помощь! Нужно построить ракету, чтобы она отправилась на плаету, которую ты выберешь" };

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
}
