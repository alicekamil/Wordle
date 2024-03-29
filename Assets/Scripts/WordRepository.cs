using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordRepository : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text asset with the words")]
    TextAsset m_wordList = null;

    List<string> m_words = null;
    void Awake()
    {
        m_words = new List<string>(m_wordList.text.Split(new char[] { ',', ' ', '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries));
    }
    
    public string GetRandomWord()
    {
        return m_words[Random.Range(0, m_words.Count)]; 
    }

    public bool CheckWordExists(string word)
    {
        return m_words.Contains(word);
    }
}
