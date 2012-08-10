namespace Jarvis.Service.Domain.Action
{
    public class ExecuteProgramAction : Action
    {
        public virtual string CommandString { get; set; }

        public virtual string ExecuteInDirectory { get; set; }

        #region Overrides of Action

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}