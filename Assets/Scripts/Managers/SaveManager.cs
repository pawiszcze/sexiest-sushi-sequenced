using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public string saveFilePath;
    public List<string> saveFileText = new List<string>();
    public int selectedSlot;

    protected FileStream stream = null;

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
                        if (line.Length > index)
                        {
                            return line[index].ToString();
                        }
                    }
                } while (line != null);
            }

            theReader.Close();
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

        string fullSavePath = saveFilePath + slot + ".txt";

        if (File.Exists(fullSavePath))
        {
            stream = new FileStream(fullSavePath, FileMode.OpenOrCreate);

            try
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.ASCII))
                {

                    //Debug.Log(String.Join("", saveFileText) + "Slot:" + selectedSlot);
                    string textToSave = String.Join("",saveFileText);
                    //Debug.Log(textToSave + "Slot:" + selectedSlot);
                    writer.Write(textToSave);
                    writer.Close();
                }
            }
            catch(Exception exp)
            {
                Debug.Log("Saving error");
            }
        }
        else
        {
            File.Create(fullSavePath).Close();
            //Debug.Log("Created the file.");
            Save(slot);
        }
        stream.Close();
    }

    public void DeleteSave(int slot)
    {
        string fullSavePath = saveFilePath + slot + ".txt";
        if (File.Exists(fullSavePath))
        {
            System.IO.File.Delete(fullSavePath);
            Debug.Log("Deleted save slot " + slot);
        }
    }
}
