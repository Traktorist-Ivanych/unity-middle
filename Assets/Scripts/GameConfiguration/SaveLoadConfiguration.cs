using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using UnityEngine;

public class SaveLoadConfiguration : MonoBehaviour
{
    [SerializeField] private Configuration configuration;
    private string path;

    private void Start()
    {
        path = Application.persistentDataPath + "/GameConfig.json";
    }

    public async Task SaveConfiguration()
    {
        ConfigurationDataToSave configurationData = new ConfigurationDataToSave(
            configuration.MaxPlayerHP, configuration.PlayerMoveSpeed);
        string saveConfig = JsonUtility.ToJson(configurationData);
        File.WriteAllText(path, saveConfig);
        await Task.Yield();
    }

    public async Task LoadConfiguration()
    {
        string loadConfigJson = File.ReadAllText(path);
        ConfigurationDataToSave loadConfig = JsonUtility.FromJson<ConfigurationDataToSave>(loadConfigJson);
        configuration.MaxPlayerHP = loadConfig.MaxPlayerHP;
        configuration.PlayerMoveSpeed = loadConfig.PlayerMoveSpeed;
        await Task.Yield();
    }

    private class ConfigurationDataToSave
    {
        public float MaxPlayerHP;
        public float PlayerMoveSpeed;

        public ConfigurationDataToSave(float maxHP, float moveSpeed)
        {
            MaxPlayerHP = maxHP;
            PlayerMoveSpeed = moveSpeed;
        }
    }
}
