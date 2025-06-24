using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class dialogue : MonoBehaviour
{

    public Image characterImage; 
    public Image Image;
    public TMP_Text dialogueText;

    private int currentLine = 0;

    public string[] dialogueLines =
      { "������, ����! � - ������ ������. ���� �� ����� ������ ����� � ������� �������� �������. � ������� � 1907 ���� � � ������� ��������� �������� � ������ � ������. � ���� ������� ������������� ����� � ��������� ��������� ������ ��������� �������������� ������. ��� ���� ������������ � 1957 ���� ��� ������� ������ ������������� ������� �����, � � 1961 ���� � ������ �������, ���� �������, ���������� � ������.\r\n",
      "�������� �� ��, ��� � 1930-� ����� ���� ������������� ���������� � ��������� � ������, � �� �������� ������ � ���� ���� � ����� ������������ �������� � ������. ����� ���������� � �������� ������ ����������� �������� ����� ������� � �������.��������� ���� ��������� ��������� ���� ���� ������ �������, �������� �������� �������� �������. ��� ����������! ",
      "�� ��� � ��� ���� ����, ����� �� �� ������� ��� ��������� �������������� ? \r\n ������ � �������! \r\n",
    };

    public string[] WhileGame =
    {
        "����� �� ������ ������� ���� ������! � ������ ������ ���� ���� ��������������. ����������� ����� ���� ��� ��������� ��� ������. ������ �� ������ ��� ���������. \r\n ����� ������ ������ � ����� ������, ������� ������ - ������! \r\n"
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
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonDown(0))
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
        Image.gameObject.SetActive(false);
        firstDialogueFinsihed = true;
    }

    public void StartWhileGameDialogue()
    {
        currentLine = 0;
        dialogueLines = WhileGame;
        dialogueText.text = "";
        characterImage.gameObject.SetActive(true);
        dialogueText.gameObject.SetActive(true);
        Image.gameObject.SetActive(false);
        ShowLine();
    }

}
