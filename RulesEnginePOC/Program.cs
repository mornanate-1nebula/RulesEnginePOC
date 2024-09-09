using RulesEngine.Actions;
using RulesEngine.HelperFunctions;
using RulesEngine.Models;
using RulesEnginePOC.Helpers;
using RulesEnginePOC.TestCases;

// BogusHelper.GenerateNewUsersData(new string[]
// {
//     "C:\\Users\\Mornante\\source\\repos-personal\\RulesEnginePOC\\RulesEnginePOC",
//     "Data", "users_data.json"
// },10_000);

var workflows = FileHelper.ReadFilesIntoType<Workflow>(new []
{
    "C:\\Users\\Mornante\\source\\repos-personal\\RulesEnginePOC\\RulesEnginePOC",
    "WorkFlows"
});

var settings = new ReSettings()
{
    EnableExceptionAsErrorMessage = true,
    IgnoreException = true,
    EnableFormattedErrorMessage = true,
    EnableScopedParams = true,
    IsExpressionCaseSensitive = false,
    AutoRegisterInputType = true,
    UseFastExpressionCompiler = true,
    
    // CustomActions = new Dictionary<string, Func<ActionBase>>()
    // {
    //     {
    //         "test", () =>
    //         {
    //     
    //             return ActionBase;
    //         }
    //     }
    // },
    NestedRuleExecutionMode = NestedRuleExecutionMode.All,
    CacheConfig = new MemCacheConfig()
    {
        
    },
    // CustomTypes = new []
    // {
    //     
    // },
};

var rulesEngine = new RulesEngine.RulesEngine(workflows, settings);

//TEST CASE 1 : SINGLE ENTITY
await new SingleEntityTestCase(rulesEngine).RunAsync();

//TEST CASE 2 : MULTIPLE ENTITY
await new EntityListTestCase(rulesEngine).RunAsync();

//TEST CASE 3 : MANIPULATE WORKFLOWS ON THE FLY
await new OnTheFlyWorkFlowUpdateTestCase(rulesEngine).RunAsync();

//TEST CASE 4 : USING MULTIPLE INPUTS IN EXPRESSIONS
await new UsingMultipleInputsTestCase(rulesEngine).RunAsync();

Console.ReadLine();