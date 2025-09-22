// 代码生成时间: 2025-09-23 05:07:02
using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;

// 配置文件管理器类
public class ConfigFileManager
{
    // 配置文件路径
    private string configFilePath;

    // 构造函数，初始化配置文件路径
    public ConfigFileManager(string filePath)
    {
        configFilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
    }

    // 加载配置文件
    public Dictionary<string, string> LoadConfig()
    {
        try
        {
            // 检查文件是否存在
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException("配置文件未找到", configFilePath);
            }

            // 使用ConfigurationManager读取配置文件
            var config = ConfigurationManager.OpenExeConfiguration(configFilePath);
            var settings = config.AppSettings.Settings;

            // 将配置项转换为字典
            var configDict = new Dictionary<string, string>();
            foreach (string key in settings.AllKeys)
            {
                configDict.Add(key, settings[key].Value);
            }

            return configDict;
        }
        catch (Exception ex)
        {
            // 处理加载配置文件时的异常
            Console.WriteLine($"加载配置文件失败：{ex.Message}");
            throw;
        }
    }

    // 保存配置文件
    public void SaveConfig(Dictionary<string, string> configDict)
    {
        try
        {
            // 检查字典是否为空
            if (configDict == null || configDict.Count == 0)
            {
                throw new ArgumentException("配置项不能为空");
            }

            // 使用ConfigurationManager保存配置文件
            var config = ConfigurationManager.OpenExeConfiguration(configFilePath);
            foreach (var item in configDict)
            {
                config.AppSettings.Settings[item.Key] = item.Value;
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        catch (Exception ex)
        {
            // 处理保存配置文件时的异常
            Console.WriteLine($"保存配置文件失败：{ex.Message}");
            throw;
        }
    }
}
