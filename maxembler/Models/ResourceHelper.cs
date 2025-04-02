using System;
using System.IO;
using System.Reflection;

namespace maxembler.Models;
public class ResourceHelper
{
    public static string LoadHtmlFromResources(string resourceName)
    {
        // Получаем текущую сборку
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Путь к ресурсу должен быть в формате "ИмяПроекта.РесурснаяПапка.ИмяФайла"
        string resourcePath = $"maxembler.Resources.helpgen.{resourceName}";

        // Проверяем, существует ли ресурс
        if (!assembly.GetManifestResourceNames().Contains(resourcePath))
        {
            throw new FileNotFoundException($"Ресурс {resourcePath} не найден.");
        }

        // Загружаем ресурс как текстовый файл
        using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}