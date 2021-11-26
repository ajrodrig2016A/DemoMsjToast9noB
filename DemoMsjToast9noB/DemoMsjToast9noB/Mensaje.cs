using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMsjToast9noB
{
    public interface Mensaje
    {
        void LongAlert(string mensaje);
        void ShortAlert(string mensaje);
    }
}
