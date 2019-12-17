using DAGH.Core.Abstractions.Models.Session;
using System;

namespace DAGH.Core.Abstractions.Session
{
    public interface ISessionCollection<T> where T : BaseSession
    {
        T AddSession(T session);

        T GetById(Guid id);

        T Remove(T session);

        void Clear();
    }
}