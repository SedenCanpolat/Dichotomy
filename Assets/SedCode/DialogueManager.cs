using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text actorNameText;
    public TMP_Text messageText;
    public RectTransform dialogueBox;

    [Header("Settings")]
    [SerializeField] private float textSpeed = 0.02f;

    [Header("Dialogue Data")]
    public Message[] currentMessages;
    public Actor[] currentActors;

    private int messageIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;
    private Coroutine startDialogueCoroutine;

    private void Awake()
    {
        InitializeDialogueSystem();
    }

    private void Start()
    {
        StartDialogueWithDelay(500);
    }

    private void InitializeDialogueSystem()
    {
        messageIndex = 0;
        isTyping = false;
        
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        
        if (startDialogueCoroutine != null)
        {
            StopCoroutine(startDialogueCoroutine);
            startDialogueCoroutine = null;
        }
        
        if (dialogueBox != null)
            dialogueBox.localScale = Vector3.zero;
            
        if (messageText != null)
        {
            messageText.text = string.Empty;
            messageText.enabled = true;
        }
            
        if (actorNameText != null)
        {
            actorNameText.text = string.Empty;
            actorNameText.enabled = true;
        }
    }

    private void OnEnable()
    {
        InitializeDialogueSystem();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                    typingCoroutine = null;
                }
                
                if (messageIndex < currentMessages.Length)
                {
                    messageText.text = currentMessages[messageIndex].message;
                }
                
                isTyping = false;
            }
            else
            {
                NextMessage();
            }
        }
    }

    public void StartDialogueWithDelay(int waitms = 0)
    {
        if (startDialogueCoroutine != null)
        {
            StopCoroutine(startDialogueCoroutine);
        }
        
        startDialogueCoroutine = StartCoroutine(StartDialogue(currentMessages, currentActors, waitms));
    }

    public IEnumerator StartDialogue(Message[] messages, Actor[] actors, int waitms = 0)
    {
        yield return new WaitForSeconds(waitms / 1000f);
        
        if (messages == null || messages.Length == 0 || actors == null)
        {
            Debug.LogError("Dialogue data is missing or invalid!");
            yield break;
        }
        
        if (dialogueBox == null || messageText == null || actorNameText == null)
        {
            Debug.LogError("UI references are missing!");
            yield break;
        }
        
        currentMessages = messages;
        currentActors = actors;
        messageIndex = 0;

        yield return StartCoroutine(AnimateDialogueBoxOpen());

        messageText.text = string.Empty;
        actorNameText.text = string.Empty;

        DisplayMessage();
    }

    private IEnumerator AnimateDialogueBoxOpen()
    {
        float duration = 0.25f;
        float elapsed = 0f;

        dialogueBox.localScale = Vector3.zero;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            dialogueBox.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
        dialogueBox.localScale = Vector3.one;
    }

    private IEnumerator AnimateDialogueBoxClose()
    {
        float duration = 0.25f;
        float elapsed = 0f;

        Vector3 startScale = dialogueBox.localScale;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            dialogueBox.localScale = Vector3.Lerp(startScale, Vector3.zero, t);
            yield return null;
        }
        dialogueBox.localScale = Vector3.zero;
    }

    private void DisplayMessage()
    {
        if (messageIndex >= currentMessages.Length || 
            currentMessages[messageIndex].actorId >= currentActors.Length)
        {
            Debug.LogError("Message index or actor ID out of range!");
            EndDialogue();
            return;
        }
        
        Message messageToDisplay = currentMessages[messageIndex];
        Actor actorToDisplay = currentActors[messageToDisplay.actorId];

        actorNameText.text = actorToDisplay.name;
        messageText.text = string.Empty;

        typingCoroutine = StartCoroutine(TypeLine(messageToDisplay.message));
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;

        foreach (char c in line.ToCharArray())
        {
            messageText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
    }

    private void NextMessage()
    {
        messageIndex++;

        if (messageIndex < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        StartCoroutine(AnimateDialogueBoxClose());
        
        messageText.text = string.Empty;
        actorNameText.text = string.Empty;
    }

    public void RestartDialogue(Message[] messages = null, Actor[] actors = null, int waitms = 0)
    {
        if (messages != null) currentMessages = messages;
        if (actors != null) currentActors = actors;
        
        InitializeDialogueSystem();
        StartDialogueWithDelay(waitms);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    [TextArea(2, 5)] public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
}