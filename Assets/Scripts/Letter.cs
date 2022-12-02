using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Letter : MonoBehaviour
{
    readonly int k_animatorResetTrigger = Animator.StringToHash("Reset");
    readonly int k_animatorShakeTrigger = Animator.StringToHash("Shake");
    readonly int k_animatorStateParameter = Animator.StringToHash("State");

    Animator m_animator = null;
    TextMeshProUGUI m_text = null;
    

    public char? Entry { get; private set; } = null; 
    public LetterState LetterState { get; private set; } = LetterState.Unknown;

    void Awake()
    {
        m_animator = GetComponent<Animator>();
        m_text = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Start()
    {
        m_text.text = null;
    }
    public void EnterLetter(char c)
    {
        Entry = c;
        m_text.text = c.ToString().ToUpper();
    }
    public void DeleteLetter()
    {
        Entry = null;
        m_text.text = null;
        m_animator.SetTrigger(k_animatorResetTrigger);
    }
    public void Shake()
    {
        m_animator.SetTrigger(k_animatorShakeTrigger);
    }
    
    public void SetState(LetterState letterState)
    {
        LetterState = letterState;
        m_animator.SetInteger(k_animatorStateParameter, (int)letterState);
    }

    public void Clear()
    {
        LetterState = LetterState.Unknown;
        m_animator.SetInteger(k_animatorStateParameter, -1);
        m_animator.SetTrigger(k_animatorResetTrigger);
        Entry = null;
        m_text.text = null;
    }
}
