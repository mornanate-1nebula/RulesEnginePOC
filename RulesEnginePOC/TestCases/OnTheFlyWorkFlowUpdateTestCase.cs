
using System.Linq.Dynamic.Core.Parser;
using RulesEngine.Models;
using RulesEnginePOC.Core.Interfaces;
using RulesEnginePOC.Core.Models;
using RulesEnginePOC.Helpers;

namespace RulesEnginePOC.TestCases;

public class OnTheFlyWorkFlowUpdateTestCase : ITestCaseRunner
{

    private readonly RulesEngine.RulesEngine _rulesEngine;
    
    public OnTheFlyWorkFlowUpdateTestCase(RulesEngine.RulesEngine rulesEngine)
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
        
        var flows1 = _rulesEngine.GetAllRegisteredWorkflowNames();
        
        //REMOVING THE WORKFLOW TO PROVE ITS POSSIBLE
        _rulesEngine.RemoveWorkflow("test_case_3_workflow");
        
        var flows2 = _rulesEngine.GetAllRegisteredWorkflowNames();
        
        //ADDING IT BACK
        //BUT YOU CAN ALSO USE THE AddOrUpdateWorkflow function to update it.
        _rulesEngine.AddWorkflow(new Workflow()
        {
            WorkflowName = "test_case_3_workflow",
            WorkflowsToInject = new List<string>(),
            RuleExpressionType = RuleExpressionType.LambdaExpression,
            GlobalParams = new List<ScopedParam>(),
            Rules = new []
            {
                new Rule()
                {
                    RuleName = "GiveDiscount10",
                    SuccessEvent = "10",
                    ErrorMessage = "You don't have any addresses assigned to your profile",
                    RuleExpressionType = 0,
                    Expression = "input1.Addresses.Any()"
                }
            }
        });

        var flows3 = _rulesEngine.GetAllRegisteredWorkflowNames();

        List<RuleResultTree> response = await _rulesEngine.ExecuteAllRulesAsync("test_case_3_workflow", userData.First());
        Console.WriteLine(response.Pretify());
    }
}