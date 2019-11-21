using DAGH.Core.Abstractions.Models.Session;
using System;

namespace DAGH.Core.Abstractions.Models
{
    public interface IQueuePackage
    {
        byte[] Data { get; set; }
        Guid IdPackage { get; set; }
        ISession Session { get; set; }
    }
}