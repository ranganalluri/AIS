//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Linq;
//using System.Workflow.Activities.Rules;
//using StructureMap;
//using Rule = System.Workflow.Activities.Rules.Rule;

//namespace DataAccess.Rules
//{
   
//    public abstract class BaseRuleSet<TFacts> where TFacts : class
//    {
//        private readonly RuleSet ruleSet = new RuleSet();
//        private const int HighestPriority = 10000;

//        public virtual void Execute(TFacts facts)
//        {
//            if ((object)facts == null)
//                throw new ArgumentException("The ruleset facts cannot be null.");
//            new RuleEngine(this.ruleSet, typeof(TFacts)).Execute((object)facts);
//        }

//        protected virtual void AddRule<TRule>() where TRule : BaseRule<TFacts>
//        {
//            TRule instance = ObjectFactory.GetInstance<TRule>();
//            instance.Priority = 10000 - this.ruleSet.Rules.Count + 1;
//            this.ruleSet.Rules.Add((Rule)instance);
//        }
//    }
//    public abstract class BaseRule<TFacts> : Rule where TFacts : class 
//    {
//        protected BaseRule(int priority = 99999)
//        {
//            this.Priority = priority;
//            this.Condition = (RuleCondition)new GenericRuleCondition<TFacts>(new Func<TFacts, bool>(this.If));
//            this.ThenActions.Add((RuleAction)new GenericRuleAction<TFacts>(new Action<TFacts>(this.Then)));
//            this.ElseActions.Add((RuleAction)new GenericRuleAction<TFacts>(new Action<TFacts>(this.Else)));
//            this.SetRuleName();
//            if (string.IsNullOrEmpty(this.Name))
//                throw new RuleException("The name of the Rule must not be null.  Please attribute rule with RuleAttribute: Rule " + this.GetType().Name);
//        }
//        protected abstract bool If(TFacts fact);

//        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Makes Rule Api More intuitive", MessageId = "Then")]
//        protected abstract void Then(TFacts fact);

//        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "Rule Api", MessageId = "Else")]
//        protected virtual void Else(TFacts fact)
//        {
//        }
//        private void SetRuleName()
//        {
//            if (!string.IsNullOrEmpty(this.Name))
//                return;
//            RuleAttribute ruleAttribute = (RuleAttribute)Enumerable.SingleOrDefault<object>((IEnumerable<object>)this.GetType().GetCustomAttributes(typeof(RuleAttribute), true), (Func<object, bool>)(x => x is RuleAttribute));
//            if (ruleAttribute == null)
//                return;
//            this.Name = ruleAttribute.RuleName;
//        }
//    }
//    public class GenericRuleAction<T> : RuleAction where T : class
//    {
//        private readonly Action<T> action;
//        private RuleExecution ruleExecution;

//        public GenericRuleAction(Action<T> action)
//        {
//            this.action = action;
//        }

//        public override bool Validate(RuleValidation validator)
//        {
//            return true;
//        }

//        public override ICollection<string> GetSideEffects(RuleValidation validation)
//        {
//            return (ICollection<string>)new List<string>();
//        }

//        public override RuleAction Clone()
//        {
//            throw new NotImplementedException();
//        }

//        public override void Execute(RuleExecution context)
//        {
//            this.ruleExecution = context;
//            this.action(context.ThisObject as T);
//        }

//        internal void Halt()
//        {
//            this.ruleExecution.Halted = true;
//        }
//    }
//    public class GenericRuleCondition<T> : RuleCondition where T : class
//    {
//        private readonly Func<T, bool> condition;

//        public override string Name { get; set; }

//        public GenericRuleCondition(Func<T, bool> condition)
//        {
//            this.condition = condition;
//        }

//        public override ICollection<string> GetDependencies(RuleValidation validation)
//        {
//            return (ICollection<string>) new List<string>();
//        }

//        public override bool Validate(RuleValidation validation)
//        {
//            return true;
//        }

//        public override RuleCondition Clone()
//        {
//            throw new NotImplementedException();
//        }

//        public override bool Evaluate(RuleExecution execution)
//        {
//            return this.condition(execution.ThisObject as T);
//        }
//    }

//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
//    public sealed class RuleAttribute : Attribute
//    {
//        private readonly string ruleName;

//        public string RuleName
//        {
//            get { return this.ruleName; }
//        }

//        public RuleAttribute(string ruleName)
//        {
//            this.ruleName = ruleName;
//        }
//    }
//}