using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveText : BaseSave
{
    string path;

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath, "SaveText.txt");
        Debug.Log(path);
    }

    public override SaveData OnLoad()
    {
        if (File.Exists(path))
        {
            string msg = File.ReadAllText(path);
            Debug.Log(msg);

            string[] col = msg.Split(',');

            SaveData dat = new SaveData();

            dat.Name = col[0];
            dat.Level = int.Parse(col[1]);
            dat.Currency = int.Parse(col[2]);

            return dat;

        }
        else
        {
            return new SaveData();
        }
    }

    public override void OnSave(SaveData data)
    {
        string tosave = string.Concat(data.Name, ",", data.Level, ",", data.Currency);
        Debug.Log(tosave);

        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(stream))
        {
            writer.Write(tosave);
        }
    }
}
