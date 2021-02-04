using System;
using System.Collections.Generic;
using System.Text;

namespace ProbeTeam.Common.Domain.Interfaces.Services
{
    public interface ISerializerService
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string serializedObj);
    }
}
