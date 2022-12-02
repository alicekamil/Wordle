using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using TMPro;

public class GameFlowManager : MonoBehaviour
{
    const int k_wordLength = 5;

    [SerializeField]
    [Tooltip("the word repository")]
    WordRepository m_wordRepository = null;

    [SerializeField]
    [Tooltip("Prefab for the letter")]
    Letter m_letterPrefab = null;

    [SerializeField]
    [Tooltip("Amount of rows")]
    int m_amountOfRows = 6;

    [SerializeField]
    [Tooltip("Grid parent")]
    GridLayoutGroup m_gridLayout = null; //gridlayoutgroup 39:17

    List<Letter> m_letters = null;

    int m_index = 0; //index of letter in row
    int m_currentRow = 0;
    char?[] m_guess = new char?[k_wordLength]; //keep guess
    char[] m_word = new char[k_wordLength]; //set random word

    void Awake()
    {
        SetupGrid();
    }

    void Start()
    {
        SetWord();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
            ParseInput(Input.inputString);
    }

    public void ParseInput(string value)
    {
        foreach (char c in value)
        {
            if (c == '\b') //backspace
            {
                DeleteLetter();
            }
            else if ((c == '\n') || (c == '\r')) //enter or return
            {
                GuessWord();
            }
            else
            {
                EnterLetter(c);
            }
        }
    }
    public void SetupGrid()
    {
        if (m_letters == null)
            m_letters = new List<Letter>();

        for (int i = 0; i < m_amountOfRows; i++)
        {
            for (int j = 0; j < k_wordLength; j++)
            {
                Letter letter = Instantiate<Letter>(m_letterPrefab);
                letter.transform.SetParent(m_gridLayout.transform); //every letter goes under this grid when instantiated.
                m_letters.Add(letter); //add letters to the list.
            }
        }
    }

    public void SetWord()
    {
        string word = m_wordRepository.GetRandomWord(); //get random word
        for (int i = 0; i < word.Length; i++)
            m_word[i] = word[i];
    }
    public void EnterLetter(char c) //keep index of letter im entering, which row its entered, and a list that contains the actual word guessed.
    {
        if (m_index < k_wordLength) //if index is < 5.
        {
            c = char.ToUpper(c); //uppercase.
            m_letters[(m_currentRow * k_wordLength) + m_index].EnterLetter(c); //enter letter to grid.
            m_guess[m_index] = c;
            m_index++;
        }
    }
    public void DeleteLetter()
    {
        if (m_index > 0)
        {
            m_index--;
            m_letters[(m_currentRow * k_wordLength) + m_index].DeleteLetter();
            m_guess[m_index] = null;
        }
    }

    void Shake()
    {
        for (int i = 0; i < k_wordLength; i++)
        {
            m_letters[(m_currentRow * k_wordLength) + i].Shake();
        }
    }
    public void GuessWord()
    {
        if (m_index != k_wordLength)
        {
            Shake();
        }
        else
        {
            StringBuilder word = new StringBuilder(); //efficient
            for (int i = 0; i < k_wordLength; i++)
                word.Append(m_guess[i].Value); //add guess to stringbuilder

            if (m_wordRepository.CheckWordExists(word.ToString()))
            {

            }
        }
    }
}
