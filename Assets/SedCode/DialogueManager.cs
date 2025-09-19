using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class DialogueManager : MonoBehaviour
{
    public TMP_Text messageText;
    public string[] lines;
    [SerializeField] private float _textSpeed;
    private int _index;
    void Start()
    {
        messageText.text = string.Empty;
        _startDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (messageText.text == lines[_index])
            {
                _nextLine();
            }
            else
            {
                StopAllCoroutines();
                messageText.text = lines[_index];    
            }
        }
       
            
  }

    private void _startDialogue()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            messageText.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void _nextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            messageText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            messageText.enabled = false;    
        }
            
    }
    
}
