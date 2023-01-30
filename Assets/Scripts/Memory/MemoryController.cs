using UnityEngine;

public static class MemoryController
{
    public static void SaveData(string variableName, float variableData)
    {
        PlayerPrefs.SetFloat(variableName, variableData);
        PlayerPrefs.Save();
    }

    public static float LoadData(string variableName)
    {
        float variableData;
        if (PlayerPrefs.HasKey(variableName))
        {
            variableData = PlayerPrefs.GetFloat(variableName);
            return variableData;
        }
        else
        {
            SaveData(variableName, 0);
            return 0;
        }
    }
}