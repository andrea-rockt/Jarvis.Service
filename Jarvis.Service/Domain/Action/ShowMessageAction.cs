using System;

namespace Jarvis.Service.Domain.Action
{
    public class ShowMessageAction : Action
    {

        public virtual string Message { get; set; }

        #region Overrides of Action

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}