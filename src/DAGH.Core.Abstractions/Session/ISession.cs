using System;

namespace DAGH.Core.Abstractions.Models.Session
{
    public interface ISession
    {
        Guid SessionId { get; }
    }
}