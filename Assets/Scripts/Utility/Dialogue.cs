using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (textComponent.text == lines[index])
            {
                Nextline();
            }
            
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }
    
    //type each chara 1 by 1
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) 
        { 
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void Nextline()
    {
        if (index < lines.Length -1)
        { 
            index++; 
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
    
}
