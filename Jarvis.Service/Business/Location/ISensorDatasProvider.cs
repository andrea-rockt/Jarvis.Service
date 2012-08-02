using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jarvis.Service.Domain.Location;

namespace Jarvis.Service.Business.Location
{
    public interface ISensorDatasProvider
    {
        LocationSensorDatas GetCurrentSensorDatas();
    }
}
