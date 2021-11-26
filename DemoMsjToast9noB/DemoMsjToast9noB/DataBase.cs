using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoMsjToast9noB
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
