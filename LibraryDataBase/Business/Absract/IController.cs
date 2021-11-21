using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryDataBase.Business.Absract
{
    public interface IController<T>
    {
        void SelectName(string name);
        void GetInfo();
        void Remove(string name);
        void Update(string name);
    }
}
