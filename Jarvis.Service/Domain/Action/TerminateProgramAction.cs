using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jarvis.Service.Domain.Action
{
    public class TerminateProgramAction : Action
    {

        public virtual String ProcessName { get; set; }

        #region Overrides of Action

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
