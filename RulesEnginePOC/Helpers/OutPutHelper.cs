using System.Text;
using System.Text.Json;
using RulesEngine.Models;

namespace RulesEnginePOC.Helpers;

public static class OutPutHelper
{
    public static string Pretify(this List<RuleResultTree> results)
    {
        var strBuilder = new StringBuilder();

        var serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        
        foreach (var result in results)
        {
            strBuilder.AppendLine("========================");
            strBuilder.AppendLine($"EXCEPTION: {result.ExceptionMessage}");
            strBuilder.AppendLine($"SUCCESS: {result.IsSuccess}");
            strBuilder.AppendLine(JsonSerializer.Serialize(result.Rule, serializerOptions));
        }

        return strBuilder.ToString();
    }
}