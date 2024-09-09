using RulesEngine.Models;
using RulesEnginePOC.Core.Interfaces;
using RulesEnginePOC.Core.Models;
using RulesEnginePOC.Helpers;

namespace RulesEnginePOC.TestCases;

public class UsingMultipleInputsTestCase : ITestCaseRunner
{
    
    private readonly RulesEngine.RulesEngine _rulesEngine;
    
    public UsingMultipleInputsTestCase(RulesEngine.RulesEngine rulesEngine)
    {
        _rulesEngine = rulesEngine;
    }
    
    public async Task RunAsync()
    {
        _rulesEngine.AddWorkflow(new Workflow()
        {
            WorkflowName = "test_case_4_workflow",
            WorkflowsToInject = new List<string>(),
            RuleExpressionType = RuleExpressionType.LambdaExpression,
            GlobalParams = new List<ScopedParam>(),
            Rules = new []
            {
                new Rule()
                {
                    RuleName = "GiveDiscount10",
                    SuccessEvent = "10",
                    ErrorMessage = "Everything needs to be true",
                    RuleExpressionType = 0,
                    Expression = "input1 == true AND input2 == true AND input3 == true"
                }
            }
        });
        
        List<RuleResultTree> response = await _rulesEngine.ExecuteAllRulesAsync("test_case_4_workflow", true, false, true);
        Console.WriteLine(response.Pretify());
    }
}