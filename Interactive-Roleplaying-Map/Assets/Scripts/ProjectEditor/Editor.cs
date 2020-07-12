﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class Editor : MonoBehaviour
{
	public MapEditor InteractiveMapEditor;
	public GameObject MiniMenu;
	public NodeEditor NodeEditor;
	public MapEditor MapEditor;
	public ProjectLoader ProjectLoader;

	public void CreateNewNode()
	{
		MiniMenu.SetActive(false);
		InteractiveMapEditor.CreateNewNode();
	}

	public void StartEditingNode()
	{
		MiniMenu.SetActive(false);
		NodeEditor.gameObject.SetActive(true);
	}

	public void StopEditingNode()
	{
		NodeEditor.gameObject.SetActive(false);
		MiniMenu.SetActive(true);
	}

	public void SaveProject()
	{
		NodeEditor.StopEditing();
		MapEditor.StopEditing();
		ProjectLoader.SaveProject();
	}

	public void GoToMainMenu()
	{
		SaveProject();
		SceneManager.LoadScene((int)Scenes.MenuScene);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
