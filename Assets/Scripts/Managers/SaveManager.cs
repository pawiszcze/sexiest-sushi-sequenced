using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public string saveFilePath;
    public List<string> saveFileText = new List<string>();
    public int selectedSlot;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        saveFilePath = "C:/Users/pawel/Documents/SaveFile";
        selectedSlot = 4;
    }

    public void AddLast(string textToAppend)
    {
        saveFileText.Add(textToAppend);
    }

    public void AddAtIndex(int index, string textToAppend)
    {
        saveFileText.Insert(index, textToAppend);
    }

    public void RemoveFromIndex(int position)
    {
        saveFileText.RemoveAt(position);
    }

    public void RemoveLast()
    {
        saveFileText.RemoveAt(saveFileText.Count - 1);
    }

    public void GetLength()
    {
        
    }

    public string ReadIndex(int slot, int index)
    {
        try
        {
            string line;
            //string outputCharacter;
            StreamReader theReader = new StreamReader(saveFilePath + slot + ".txt", Encoding.Default);

            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        if (line.Length > 0)
                        {
                            return line[0].ToString();
                        }
                    }
                } while (line != null);
            }
        }
        catch
        {
            
        }
        return "Bad";
        //return saveFileText[index];
    }

    public void Save(int slot)
    {
        selectedSlot = slot;
        //Debug.Log(saveFilePath);
        string fullSavePath = saveFilePath + slot + ".txt";
        //Debug.Log(fullSavePath);

        if (File.Exists(fullSavePath))
        {
            //Debug.Log(saveFileText);
            File.WriteAllText(fullSavePath, string.Join("", saveFileText));
        }
        else
        {
            File.Create(fullSavePath);
            Save(slot);
        }
    }
}
