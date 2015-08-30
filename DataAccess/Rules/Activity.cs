//using System.Workflow.Activities.Rules;
//using System.Workflow.ComponentModel;

//namespace DataAccess.Rules
//{
//    public class Activity1
//    {
//        public class RuleEngineActivity<T> : Activity
//        {
//            public RuleSet RuleSet { get; set; }

//            public T FactContainer { get; set; }

//            protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
//            {
//                new RuleEngine(this.RuleSet, this.FactContainer.GetType()).Execute((object)this.FactContainer, executionContext);
//                executionContext.CloseActivity();
//                return executionContext.Activity.ExecutionStatus;
//            }
//        }
//    }
//}