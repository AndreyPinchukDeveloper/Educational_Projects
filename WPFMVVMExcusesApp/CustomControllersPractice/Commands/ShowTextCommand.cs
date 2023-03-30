using CustomControllersPractice.Commands.Base;
using CustomControllersPractice.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControllersPractice.Commands
{
    internal class ShowTextCommand : CommandBase
    {
        private readonly AnalogClock _analogClock;
        private TimeChangedEventArgs timeEvent;
        public ShowTextCommand(AnalogClock analogClock)
        {
            _analogClock = analogClock;
        }

        public override void Execute(object parameter)
        {
            _analogClock.CurrentTime = timeEvent.NewTime.ToString("hh:mm:ss");
        }
    }
}
