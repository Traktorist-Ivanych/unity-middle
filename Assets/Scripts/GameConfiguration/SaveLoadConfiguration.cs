using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class SaveLoadConfiguration : MonoBehaviour
{
    [SerializeField] private Configuration configuration;
    private string path;

    private void Start()
    {
        path = Application.persistentDataPath + "/GameConfig.json";
    }

    public async void SaveConfiguration()
    {
        ConfigurationDataToSave configurationData = new ConfigurationDataToSave(
            configuration.MaxPlayerHP, configuration.PlayerMoveSpeed);
        string saveConfig = JsonUtility.ToJson(configurationData);

        await Task.Run(() => File.WriteAllText(path, saveConfig));
    }

    public async void LoadConfiguration()
    {
        string loadConfigJson = await Task.Run(() => File.ReadAllText(path));

        ConfigurationDataToSave loadConfig = JsonUtility.FromJson<ConfigurationDataToSave>(loadConfigJson);
        configuration.MaxPlayerHP = loadConfig.MaxPlayerHP;
        configuration.PlayerMoveSpeed = loadConfig.PlayerMoveSpeed;
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
