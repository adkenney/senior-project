using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class SaveSystem
{
  
public static void saveData()
{
    Debug.Log("Made it to save data in Save System");
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/board.stuff";
    FileStream stream = new FileStream(path, FileMode.Create);
    BoardPlayerDataMovement data = new BoardPlayerDataMovement();
    formatter.Serialize(stream,data);
    Debug.Log("Save Successful!");
    stream.Close();
}

public static BoardPlayerDataMovement loadData()
{
    string path = Application.persistentDataPath + "/board.stuff";
    if(File.Exists(path))
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        BoardPlayerDataMovement data = formatter.Deserialize(stream) as BoardPlayerDataMovement;
        stream.Close();
        Debug.Log("Load Successful!");
        return data;
        
    }else
    {
        Debug.LogError("Save file not found in "+path);
        return null;
    }
}

}
