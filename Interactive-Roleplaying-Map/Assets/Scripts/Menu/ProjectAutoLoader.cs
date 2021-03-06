﻿using System.IO;
//using System.Windows.Forms;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityFileExplorer;

public class ProjectAutoLoader : MonoBehaviour
{
    private static bool isLaunched = false;

    public string InvalidFileLoadedMessage;
    public string InvalidFileLoadedCaption;
    public Scenes EditorScene;

    // Start is called before the first frame update
    private void Start()
    {
        if(isLaunched)
        {
            Destroy(gameObject);
            return;
        }

        isLaunched = true;

        string file = GetIrmFile();
        if (file != null)
        {
            if (File.Exists(file))
            {
                BasicSettings settings = BasicSettings.Instance;
                settings.MapFilePath = file;
                SceneManager.LoadScene((int)EditorScene);
            }
            else
            {
                MessageBox.ShowMessage(MessageType.OK, null, InvalidFileLoadedMessage, InvalidFileLoadedCaption);
            }
        }
    }

    private string GetIrmFile()
    {
        foreach (string arg in System.Environment.GetCommandLineArgs())
        {
            if (Path.GetExtension(arg).ToLower() == ".irm")
            {
                return arg;
            }
        }
        return null;
    }
}
