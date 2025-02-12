﻿using RulesEngine.Models;
using RulesEnginePOC.Core.Interfaces;
using RulesEnginePOC.Core.Models;
using RulesEnginePOC.Helpers;

namespace RulesEnginePOC.TestCases;

public class EntityListTestCase : ITestCaseRunner
{
    
    private readonly RulesEngine.RulesEngine _rulesEngine;
    
    public EntityListTestCase(RulesEngine.RulesEngine rulesEngine)
    {
        _rulesEngine = rulesEngine;
    }
    
    public async Task RunAsync()
    {
        var userData = FileHelper.ReadFileIntoType<List<User>>(new[]
        {
            "C:\\Users\\Mornante\\source\\repos-personal\\RulesEnginePOC\\RulesEnginePOC",
            "Data", "users_data.json"
        });
        
        List<RuleResultTree> response = await _rulesEngine.ExecuteAllRulesAsync("test_case_2_workflow", userData);
        Console.WriteLine(response.Pretify());
    }
}